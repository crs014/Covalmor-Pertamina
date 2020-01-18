using CovalmorPertamina.Common.Interfaces;
using CovalmorPertamina.Entity;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using CovalmorPertamina.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CovalmorPertamina.Web.Controllers
{
    public class CreditController : Controller
    {
        private ICreditApprovalRepository _creditApprovalRepository;

        public CreditController(IEntityFactory entityFactory)
        {
            _creditApprovalRepository = entityFactory.Repositories(ERepository.CreditApproval) as ICreditApprovalRepository;
        }

        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Detail")]
        public async Task<ActionResult> Detail(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            List<string> products = creditApproval.TrCaProducts.Select(e => e.Product.MaterialName).ToList();
            ViewBag.Credit = creditApproval;
            //ViewBag.QuantitativeAspects = creditApproval.QuantitativeAspects.FirstOrDefault();
            ViewBag.CustomerDetail = creditApproval.CaCustomerDetails.Count();
            ViewBag.CustomerDetailObj = creditApproval.CaCustomerDetails.FirstOrDefault();
            ViewBag.Nota = creditApproval.TrCaNotes.FirstOrDefault();
            ViewBag.Products = string.Join(", ", products.ToArray());
            return View();
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create()
        {
            ViewBag.Credit = new CreditApproval();
            ViewBag.Products = new List<int>().ToArray();
            ViewBag.Id = 0;
            ViewBag.Url = Url.RouteUrl("DefaultApi", new { httproute = "", controller = "CreditApproval", action = "Create" });
            ViewBag.FormType = "POST";
            ViewBag.Title = "Request Kredit";
            return View("~/Views/Credit/Form.cshtml");
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<ActionResult> Edit(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            List<int> products = creditApproval.TrCaProducts.Select(e => e.ProductId).ToList();
            ViewBag.Credit = creditApproval;
            ViewBag.Products = products.ToArray();
            ViewBag.Id = id;
            ViewBag.Url = Url.RouteUrl("DefaultApi", new { httproute = "", controller = "CreditApproval", action = "Update", id = id });
            ViewBag.FormType = "PATCH";
            ViewBag.Title = "Edit Kredit";
            return View("~/Views/Credit/Form.cshtml");
        }

        [HttpGet]
        [ActionName("CreateCustomerDetail")]
        public async Task<ActionResult> CreateCustomerDetail(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            ViewBag.Credit = creditApproval;
            ViewBag.CustomerDetail = new CaCustomerDetail();
            ViewBag.Title = "Customer Detail";
            ViewBag.FormType = "POST";
            ViewBag.Url = Url.RouteUrl("DefaultApi", new { httproute = "", controller = "CustomerDetail", action = "Create" });
            return View("~/Views/Credit/CustomerDetailForm.cshtml");
        }

        [HttpGet]
        [ActionName("EditCustomerDetail")]
        public async Task<ActionResult> EditCustomerDetail(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            ViewBag.Credit = creditApproval;
            ViewBag.CustomerDetail = creditApproval.CaCustomerDetails;
            ViewBag.Title = "Edit Customer Detail";
            ViewBag.FormType = "PATCH";
            ViewBag.Url = Url.RouteUrl("DefaultApi", new
            {
                httproute = "",
                controller = "CustomerDetail",
                action = "Update",
                id = creditApproval.CaCustomerDetails.FirstOrDefault().Id
            });
            return View("~/Views/Credit/CustomerDetailForm.cshtml");
        }

        [HttpGet]
        [ActionName("CashBank")]
        public async Task<ActionResult> CreateCashBank(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            ViewBag.Credit = creditApproval;
            ViewBag.Title = "Cash Bank";
            return View("~/Views/Credit/CashBankForm.cshtml");
        }

        [HttpGet]
        [ActionName("EditCashBank")]
        public async Task<ActionResult> EditCashBank(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            ViewBag.Credit = creditApproval;
            ViewBag.Title = "Edit Cash Bank";
            return View("~/Views/Credit/CashBankForm.cshtml");
        }

        [HttpGet]
        [ActionName("FbsEntry")]
        public async Task<ActionResult> FbsEntry(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            ViewBag.Credit = creditApproval;
            ViewBag.Note = new TrCaNote();
            ViewBag.Title = "Create Fbs Entry";
            ViewBag.Url = Url.RouteUrl("DefaultApi", new { httproute = "", controller = "TrCaNote", action = "Create" });
            ViewBag.FormType = "POST";
            return View("~/Views/Credit/FbsEntryForm.cshtml");
        }

        [HttpGet]
        [ActionName("EditFbsEntry")]
        public async Task<ActionResult> EditFbsEntry(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            ViewBag.Credit = creditApproval;
            ViewBag.Note = creditApproval.TrCaNotes.FirstOrDefault();
            ViewBag.Title = "Edit Fbs Entry";
            ViewBag.Url = Url.RouteUrl("DefaultApi", new { 
                httproute = "", 
                controller = "TrCaNote", 
                action = "Update", 
                id = creditApproval.Id 
            });
            ViewBag.FormType = "PATCH";
            return View("~/Views/Credit/FbsEntryForm.cshtml");
        }

        [HttpGet]
        [ActionName("FbsForm")]
        public async Task<ActionResult> FbsForm(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            ViewBag.Credit = creditApproval;
            ViewBag.Title = "Fbs Form";
            return View("~/Views/Credit/FbsForm.cshtml");
        }

        [HttpGet]
        [ActionName("SignedCredit")]
        public async Task<ActionResult> SignedCredit(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            ViewBag.Credit = creditApproval;
            ViewBag.Title = "Signed Credit";
            return View("~/Views/Credit/SignedCreditForm.cshtml");
        }
    }
}