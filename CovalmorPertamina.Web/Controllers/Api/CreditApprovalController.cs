using CovalmorPertamina.Common.Interfaces;
using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Common.Statics;
using CovalmorPertamina.Entity;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using CovalmorPertamina.Web.Attributes;
using CovalmorPertamina.Web.Models;
using CovalmorPertamina.Web.Models.DataTable;
using CovalmorPertamina.Web.Requests;
using JQDT.WebAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace CovalmorPertamina.Web.Controllers.Api
{
    public class CreditApprovalController : BaseApiController
    {
        public CreditApprovalController(IEntityFactory entityFactory, IPdfService pdfService)
        {
            _creditApprovalRepository = entityFactory.Repositories(ERepository.CreditApproval) as ICreditApprovalRepository;
            _trCaActionNoteRepository = entityFactory.Repositories(ERepository.TrCaActionNote) as ITrCaActionNoteRepository;
            _trCaProductRepository = entityFactory.Repositories(ERepository.TrCaProduct) as ITrCaProductRepository;
            _signatureRepository = entityFactory.Repositories(ERepository.Signature) as ISignatureRepository;
            _pdfService = pdfService;
        }

        [HttpGet]
        [ActionName("Index")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                IEnumerable<CreditApproval> creditApprovals = await Task.FromResult(_creditApprovalRepository.GetAll().ToList());
                return new HttpJsonApiResult<IEnumerable<CreditApprovalModel>>(
                    CreditApprovalModel.GetAll(creditApprovals), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("datatable")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        [JQDataTable]
        public async Task<IHttpActionResult> GetDataTable()
        {
            try
            {
                IQueryable<CreditApprovalDataTableModel> creditApprovals = await Task.FromResult(_creditApprovalRepository.GetAll()
                    .Select(e => new CreditApprovalDataTableModel() { 
                        Id = e.Id,
                        CustomerName = e.Customer.Name,
                        PeriodeVolume = e.PeriodeVolume,
                        TransactionValueEstimatedPeriod = e.TransactionValueEstimatedPeriod,
                        CreditLimit = e.CreditLimit,
                        Creator = e.User.Name,
                        Status = e.Status.ToString()
                    })); 

                return Ok(creditApprovals);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [ActionName("Index")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
                if (creditApproval == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<CreditApprovalModel>(
                    new CreditApprovalModel(creditApproval), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("Create")]
        [JWTAuth(new EUserRole[] { EUserRole.User })]
        public async Task<IHttpActionResult> Post([FromBody]CreditApprovalRequest data)
        {
            try
            {
                CreditApproval dataCreditApproval = data.GetObject();
                dataCreditApproval.CreatedBy = GetUserAuth().Id;
                dataCreditApproval.TicketNumber = GetUserAuth().Id.ToString() + ((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();
                CreditApproval creditApproval = await _creditApprovalRepository.Create(dataCreditApproval);
                List<TrCaProduct> trCaProducts = new List<TrCaProduct>();
                foreach (int item in data.Products)
                {
                    TrCaProduct newTrCaProduct = new TrCaProduct();
                    newTrCaProduct.CreditApprovalId = creditApproval.Id;
                    newTrCaProduct.ProductId = item;
                    trCaProducts.Add(newTrCaProduct);
                }
                await _trCaProductRepository.MultipleCreate(trCaProducts);
                return new HttpJsonApiResult<CreditApprovalModel>(
                    new CreditApprovalModel(creditApproval), Request, HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPatch]
        [ActionName("Update")]
        [JWTAuth(new EUserRole[] { EUserRole.User })]
        public async Task<IHttpActionResult> Update(int id, [FromBody]CreditApprovalRequest data)
        {
            try
            {    
                CreditApproval creditApproval = await _creditApprovalRepository.Update(id, data.GetObject());
                if (creditApproval != null)
                {

                    if (data.Products != null || data.Products.Count() != 0)
                    {
                        bool isDeleted = await _trCaProductRepository.DeleteByCreditId(id);
                        if (isDeleted)
                        {
                            List<TrCaProduct> trCaProducts = new List<TrCaProduct>();
                            foreach (int item in data.Products)
                            {
                                TrCaProduct newTrCaProduct = new TrCaProduct();
                                newTrCaProduct.CreditApprovalId = id;
                                newTrCaProduct.ProductId = item;
                                trCaProducts.Add(newTrCaProduct);
                            }
                            await _trCaProductRepository.MultipleCreate(trCaProducts);
                        }
                    }
                    return new HttpJsonApiResult<CreditApprovalModel>(
                        new CreditApprovalModel(creditApproval), Request, HttpStatusCode.OK);
                }
                return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("UploadIntroductionMemo")]
        [JWTAuth(new EUserRole[] { EUserRole.User })]
        public async Task<IHttpActionResult> UploadIntroductionMemo(int id)
        {
            try
            {
                string introductionToMemoFileName = string.Format("IntroductionToMemo-{0}.pdf", id.ToString());
                string uploadFilePath = UploadSingleFile(ConstantValue.FilePath.MemoPengantarPath, introductionToMemoFileName);
                if (uploadFilePath == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                await _creditApprovalRepository.AddIntroductionMemo(id, introductionToMemoFileName);
                return new HttpJsonApiResult<string>(uploadFilePath, Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("UploadDocLka")]
        [JWTAuth(new EUserRole[] { EUserRole.User })]
        public async Task<IHttpActionResult> UploadDocLka(int id)
        {
            try
            {
                string docLkaFileName = string.Format("DocLka-{0}.pdf", id.ToString());
                string uploadFilePath = UploadSingleFile(ConstantValue.FilePath.DocLkaPath, docLkaFileName);
                if(uploadFilePath == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                await _creditApprovalRepository.AddDocLka(id, docLkaFileName);
                return new HttpJsonApiResult<string>(uploadFilePath, Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("UploadDocCas")]
        [JWTAuth(new EUserRole[] { EUserRole.User })]
        public async Task<IHttpActionResult> UploadDocCas(int id)
        {
            try
            {
                string docCasFileName = string.Format("DocCas-{0}.pdf", id.ToString());
                string uploadFilePath = UploadSingleFile(ConstantValue.FilePath.DocCasPath, docCasFileName);
                if (uploadFilePath == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                await _creditApprovalRepository.AddDocCas(id, docCasFileName);
                return new HttpJsonApiResult<string>(uploadFilePath, Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("UploadDocBg")]
        [JWTAuth(new EUserRole[] { EUserRole.User })]
        public async Task<IHttpActionResult> UploadDocBg(int id)
        {
            try
            {
                string docBgFileName = string.Format("DocBg-{0}.pdf", id.ToString());
                string uploadFilePath = UploadSingleFile(ConstantValue.FilePath.DocBgPath, docBgFileName);
                if (uploadFilePath == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                await _creditApprovalRepository.AddDocBg(id, docBgFileName);
                return new HttpJsonApiResult<string>(uploadFilePath, Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("UploadDocPml")]
        [JWTAuth(new EUserRole[] { EUserRole.User })]
        public async Task<IHttpActionResult> UploadDocPml(int id)
        {
            try
            {
                string docPmlFileName = string.Format("DocPml-{0}.pdf", id.ToString());
                string uploadFilePath = UploadSingleFile(ConstantValue.FilePath.DocPmlPath, docPmlFileName);
                if (uploadFilePath == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                await _creditApprovalRepository.AddDocPml(id, docPmlFileName);
                return new HttpJsonApiResult<string>(uploadFilePath, Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [ActionName("Delete")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin })]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                CreditApproval creditApproval = await _creditApprovalRepository.Delete(id);
                if (creditApproval == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<CreditApprovalModel>(
                    new CreditApprovalModel(creditApproval), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("Approve")]
        [JWTAuth(new EUserRole[] {
            EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk })]
        public async Task<IHttpActionResult> Approve(int id, [FromBody] ActionNoteRequest actionNoteRequest)
        {
            try
            {
                EUserRole userRole = GetUserAuth().UserRole;
                UserModel getUser = GetUserAuth();
                EStatusCredit statusCredit;

                if (userRole == EUserRole.User)
                {
                    statusCredit = EStatusCredit.AR;
                }
                else if (userRole == EUserRole.AR)
                {
                    statusCredit = EStatusCredit.CashBank;
                }
                else if (userRole == EUserRole.CashBank)
                {
                    statusCredit = EStatusCredit.FBS;
                }
                else if (userRole == EUserRole.FBS)
                {
                    statusCredit = EStatusCredit.ManagementRisk;
                }
                else if (userRole == EUserRole.ManagementRisk)
                {
                    statusCredit = EStatusCredit.KomiteCredit;
                }
                else
                {
                    statusCredit = EStatusCredit.Completed;
                }

                
                CreditApproval creditApproval = await _creditApprovalRepository.UpdateStatus(id, statusCredit, true);

                if (creditApproval == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }

                TrCaActionNote trCaActionNote = await _trCaActionNoteRepository.Create(new TrCaActionNote()
                {
                    CreditApprovalId = creditApproval.Id,
                    ActionNote = actionNoteRequest.ActionNote,
                    ActionType = 1,
                    ActionBy = getUser.Id
                });
                //send email here
                return new HttpJsonApiResult<CreditApprovalModel>(new CreditApprovalModel(creditApproval), 
                    Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("Reject")]
        [JWTAuth(new EUserRole[] {
            EUserRole.AR, EUserRole.CashBank, EUserRole.FBS,
            EUserRole.KomiteCredit, EUserRole.ManagementRisk })]
        public async Task<IHttpActionResult> Reject(int id, [FromBody] ActionNoteRequest actionNoteRequest)
        {
            try
            {
                EUserRole userRole = GetUserAuth().UserRole;
                UserModel getUser = GetUserAuth();
                EStatusCredit statusCredit;
                if (userRole == EUserRole.AR)
                {
                    statusCredit = EStatusCredit.DraftUser;
                }
                else if (userRole == EUserRole.CashBank)
                {
                    statusCredit = EStatusCredit.AR;
                }
                else if (userRole == EUserRole.FBS)
                {
                    statusCredit = EStatusCredit.CashBank;
                }
                else if (userRole == EUserRole.ManagementRisk)
                {
                    statusCredit = EStatusCredit.FBS;
                }
                else
                {
                    statusCredit = EStatusCredit.ManagementRisk;
                }

                CreditApproval creditApproval = await _creditApprovalRepository.UpdateStatus(id, statusCredit);

                if (creditApproval == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }

                TrCaActionNote trCaActionNote = await _trCaActionNoteRepository.Create(new TrCaActionNote()
                {
                    CreditApprovalId = creditApproval.Id,
                    ActionNote = actionNoteRequest.ActionNote,
                    ActionType = 0,
                    ActionBy = getUser.Id
                });
                //send email here
                return new HttpJsonApiResult<CreditApprovalModel>(new CreditApprovalModel(creditApproval), Request, HttpStatusCode.OK);

            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                   "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("BankGaransiDoc")]
        [JWTAuth(new EUserRole[] { EUserRole.CashBank })]
        public async Task<IHttpActionResult> BankGaransiDoc(int id)
        {
            try
            {
                string bankGaransiDoc = string.Format("BankGaransiDoc-{0}.pdf", id.ToString());
                string uploadFilePath = UploadSingleFile(ConstantValue.FilePath.BankGaransiDocPath, bankGaransiDoc);
                if (uploadFilePath == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                await _creditApprovalRepository.AddBankGaransi(id, bankGaransiDoc);
                return new HttpJsonApiResult<string>(uploadFilePath, Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                   "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("BankKonfirmasiDoc")]
        [JWTAuth(new EUserRole[] { EUserRole.CashBank })]
        public async Task<IHttpActionResult> BankKonfirmasiDoc(int id)
        {
            try
            {
                string bankKonfirmasiDoc = string.Format("BankKonfirmasiDoc-{0}.pdf", id.ToString());
                string uploadFilePath = UploadSingleFile(ConstantValue.FilePath.BankKonfirmasiDocPath, bankKonfirmasiDoc);
                if (uploadFilePath == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                await _creditApprovalRepository.AddBankKonfirmasiDoc(id, bankKonfirmasiDoc);
                return new HttpJsonApiResult<string>(uploadFilePath, Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                   "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("CreditScoring")]
        [JWTAuth(new EUserRole[] { EUserRole.CashBank })]
        public async Task<IHttpActionResult> UploadCreditScoring(int id)
        {
            try
            {
                string creditScoringDoc = string.Format("CreditScoring-{0}.pdf", id.ToString());
                string uploadFilePath = UploadSingleFile(ConstantValue.FilePath.CreditScoringDocPath, creditScoringDoc);
                if (uploadFilePath == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                await _creditApprovalRepository.AddCreditScoring(id, creditScoringDoc);
                return new HttpJsonApiResult<string>(uploadFilePath, Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                   "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("SignedCredit")]
        [JWTAuth(new EUserRole[] { EUserRole.KomiteCredit })]
        public async Task<IHttpActionResult> UploadSignedCredit(int id) 
        {
            try
            {
                string creditSignDoc = string.Format("CreditSign-{0}.pdf", id.ToString());
                string uploadFilePath = UploadSingleFile(ConstantValue.FilePath.CreditSignPath, creditSignDoc);
                if (uploadFilePath == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                await _creditApprovalRepository.AddCreditSign(id, creditSignDoc);
                return new HttpJsonApiResult<string>(uploadFilePath, Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                   "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }
            
        [HttpGet]
        [ActionName("MemoPengantarPdf")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<string> PdfMemoPengantar(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            string path = Path.Combine(ConstantValue.FilePath.MemoPengantarBasePath, creditApproval.IntroductionToMemo);
            byte[] fileByte = File.ReadAllBytes(path);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("DocLkaPdf")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<string> PdfDocLka(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            string path = Path.Combine(ConstantValue.FilePath.DocLkaBasePath, creditApproval.DocLka);
            byte[] fileByte = File.ReadAllBytes(path);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("DocCasPdf")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<string> PdfDocCas(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            string path = Path.Combine(ConstantValue.FilePath.DocCasBasePath, creditApproval.DocCas);
            byte[] fileByte = File.ReadAllBytes(path);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("DocPmlPdf")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<string> PdfDocPml(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            string path = Path.Combine(ConstantValue.FilePath.DocPmlBasePath, creditApproval.DocPml);
            byte[] fileByte = File.ReadAllBytes(path);
            return Convert.ToBase64String(fileByte);
        }
        
        [HttpGet]
        [ActionName("BankKonfirmasiPdf")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<string> PdfBankKonfirmasi(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            string path = Path.Combine(ConstantValue.FilePath.BankKonfirmasiDocBasePath, creditApproval.BankConfirmationDoc);
            byte[] fileByte = File.ReadAllBytes(path);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("BankGaransiPdf")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<string> PdfBankGaransi(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            string path = Path.Combine(ConstantValue.FilePath.BankGaransiDocBasePath, creditApproval.BankGuaranteeDoc);
            byte[] fileByte = File.ReadAllBytes(path);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("SignCreditPdf")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<string> PdfSignCredit(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            string path = Path.Combine(ConstantValue.FilePath.CreditSignBasePath, creditApproval.CreditApprovalDoc);
            byte[] fileByte = File.ReadAllBytes(path);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("CreditScoringPdf")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<string> PdfCreditScoring(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            string path = Path.Combine(ConstantValue.FilePath.CreditScoringDocBasePath, creditApproval.CreditScoringDoc);
            byte[] fileByte = File.ReadAllBytes(path);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("IdentitasCustomerPdf")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<string> IdentitasCustomerPdf(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            CaCustomerDetail customerDetail = creditApproval.CaCustomerDetails.FirstOrDefault();
            string path = Path.Combine(ConstantValue.FilePath.TemplatePath, ConstantValue.FilePath.IdentitasCustomerPdf);
            byte[] fileByte = File.ReadAllBytes(path);
            using(MemoryStream memory = new MemoryStream())
            {
                _pdfService.CreateDocumentA4FromMemoryStream(memory);
                _pdfService.ReadPdf(memory, fileByte);
                _pdfService.SetPdfField("JenisIndustri", customerDetail.JenisIndustri);
                _pdfService.SetPdfField("Keterlambatan", customerDetail.Keterlambatan);
                _pdfService.SetPdfField("Restrukturisasi", customerDetail.Restrukturisasi);
                _pdfService.SetPdfField("FasilitasKredit", customerDetail.FasilitasKredit);
                _pdfService.SetPdfField("LamaKerjaSama", customerDetail.LamaKerjaSama);
                _pdfService.SetPdfField("VendorPemasuk", customerDetail.VendorPemasuk);
                _pdfService.SetPdfField("PosisiTawar", customerDetail.PosisiTawar);
                _pdfService.SetPdfField("BadanUsaha", customerDetail.BadanUsaha);
                _pdfService.SetPdfField("Affiliasi", customerDetail.Affiliasi);
                _pdfService.SetPdfField("KondisiIndustri", customerDetail.KondisiIndustri);
                _pdfService.SetPdfField("OpiniAudit", customerDetail.OpiniAudit);
                _pdfService.SetPdfField("AuditKap", customerDetail.AuditKap);
                _pdfService.ClosePdf();
                return Convert.ToBase64String(memory.ToArray());
            }
        }
    
        [HttpGet]
        [ActionName("UserNotePdf")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<string> UserNotePdf(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            TrCaNote trCaNote = creditApproval.TrCaNotes.FirstOrDefault();
            string path = Path.Combine(ConstantValue.FilePath.TemplatePath, ConstantValue.FilePath.UserNotePdf);
            byte[] fileByte = File.ReadAllBytes(path);
            using (MemoryStream memory = new MemoryStream())
            {
                _pdfService.CreateDocumentA4FromMemoryStream(memory);
                _pdfService.ReadPdf(memory, fileByte);
                _pdfService.SetPdfField("Perihal", trCaNote.Perihal);
                _pdfService.SetPdfField("Isi", string.Format("{0}. Demikian disampaikan, atas perhatian dan kerja samanya kami ucapkan terima kasih.", trCaNote.Isi));
                _pdfService.SetPdfField("Jabatan", creditApproval.User.Jabatan);
                _pdfService.SetPdfField("UserName", creditApproval.User.Name);
                _pdfService.ClosePdf();
                return Convert.ToBase64String(memory.ToArray());
            }
        }

        [HttpPost]
        [ActionName("CreditApprovalPdf")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<string> CreditApprovalPdf(int id, [FromBody] CreditApprovalPdfRequest pdfRequest)
        {
            string titleCredit = "CREDIT APPROVAL";
            string jaminan = "Tanpa Jaminan";
            string sanksi = "Tidak";
            Signature signature = await _signatureRepository.GetOne(pdfRequest.TtdId);
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            string path = Path.Combine(ConstantValue.FilePath.TemplatePath, ConstantValue.FilePath.CreditApprovalPdf);
            string products = string.Join(", ", creditApproval.TrCaProducts.Select(e => e.Product.MaterialName).ToArray());
            byte[] fileByte = File.ReadAllBytes(path);
            if(creditApproval.Guarantee != ConstantValue.BentukJaminan.Option1)
            {
                titleCredit = "CREDIT APPROVAL (DENGAN JAMINAN)";
                jaminan = "Dengan Jaminan";
            }
            if (creditApproval.FlagFine)
            {
                sanksi = "Ya";
            }
            using(MemoryStream memory = new MemoryStream())
            {
                _pdfService.CreateDocumentA4FromMemoryStream(memory);
                _pdfService.ReadPdf(memory, fileByte);
                _pdfService.SetPdfField("Title", titleCredit);
                _pdfService.SetPdfField("NomorTanggal", string.Format("Nomor {0} Tgl. {1}", creditApproval.MailNumber, creditApproval.CreatedAt.ToString("dd-MM-yyyy")));
                _pdfService.SetPdfField("NamaPerusahaan", creditApproval.Customer.Name);
                _pdfService.SetPdfField("CustomerID", creditApproval.Customer.CustomerNo);
                _pdfService.SetPdfField("Alamat", creditApproval.Customer.Address);
                _pdfService.SetPdfField("Jaminan", string.Format("Untuk diberikan Fasilitas Penjualan Non Tunai {0} atas pembelian produk dari PT Pertamina(Persero) dengan ketentuan sebagai berikut :", jaminan));
                _pdfService.SetPdfField("JangkaWaktu", string.Format("{0} s.d {1}", creditApproval.TempoStart.ToString("dd-MM-yyyy"), creditApproval.TempoEnd.ToString("dd-MM-yyyy")));
                _pdfService.SetPdfField("Produk", products);
                _pdfService.SetPdfField("PerkiraanVolume", string.Format("{0} {1} per {2}",creditApproval.Volume, creditApproval.Units, creditApproval.PeriodeVolume));
                _pdfService.SetPdfField("PerkiraanNilai", string.Format("{0} {1} / {2}", creditApproval.Currency, creditApproval.TransactionValue, creditApproval.PeriodeVolume));
                _pdfService.SetPdfField("CreditLimit", string.Format("{0} {1}", creditApproval.Currency, creditApproval.CreditLimit));
                _pdfService.SetPdfField("MasaPerkiraanNilai", creditApproval.TransactionValueEstimatedPeriod);
                _pdfService.SetPdfField("MekanismePembayaran", string.Format("Melalui {0}", creditApproval.Payment));
                _pdfService.SetPdfField("BentukJaminan", string.Format("Melalui {0}", creditApproval.Guarantee));
                _pdfService.SetPdfField("Sanksi", sanksi);
                _pdfService.SetPdfField("SyaratPenyerahan", creditApproval.TermsOfDelivery);
                if(signature != null)
                {
                    _pdfService.SetPdfField("Posisi1", signature.Position1);
                    _pdfService.SetPdfField("Posisi2", signature.Position2);
                    _pdfService.SetPdfField("Nama1", signature.Name1);
                    _pdfService.SetPdfField("Nama2", signature.Name2);
                }
     
                _pdfService.ClosePdf();
                return Convert.ToBase64String(memory.ToArray());
            }
        }
    }
}