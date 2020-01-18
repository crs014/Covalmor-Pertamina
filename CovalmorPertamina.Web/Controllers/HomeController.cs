using CovalmorPertamina.Entity;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using CovalmorPertamina.Web.Attributes;
using Rotativa;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CovalmorPertamina.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICreditApprovalRepository _creditApprovalRepository;
        private ISignatureRepository _signatureRepository;

        public HomeController(IEntityFactory entityFactory)
        {
            _creditApprovalRepository = entityFactory.Repositories(ERepository.CreditApproval) as ICreditApprovalRepository;
            _signatureRepository = entityFactory.Repositories(ERepository.Signature) as ISignatureRepository;
        }

        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ActionName("NotaPengantarPdf")]
        public ActionResult NotaPengantarPdf(CreditApproval data)
        { 
            ViewBag.Credit = data;
            return new ViewAsPdf("~/Views/Pdf/Nota.cshtml");
        }

        [HttpGet]
        [ActionName("IdentitasCustomerPdf")]
        public ActionResult IdentitasCustomerPdf(CreditApproval creditApproval)
        {
           
            ViewBag.Data = creditApproval.CaCustomerDetails.FirstOrDefault();
            return new ViewAsPdf("~/Views/Pdf/IdentitasCustomer.cshtml");
        }

        [HttpGet]
        [ActionName("CreditApprovalPdf")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        public async Task<ActionResult> CreditApprovalPdf(int id)
        {
            CreditApproval creditApproval = await _creditApprovalRepository.GetOne(id);
            Signature signature = _signatureRepository.GetAll().Where(e => e.DocumentType == "CA").FirstOrDefault();
            List<string> products = creditApproval.TrCaProducts.Select(e => e.Product.MaterialName).ToList();
            ViewBag.Kredit = creditApproval;
            ViewBag.Produk = string.Join(", ", products.ToArray());
            ViewBag.Ttd = signature;
            return new ViewAsPdf("~/Views/Pdf/creditApproval.cshtml");
        }

        [HttpPost]
        [ActionName("UploadProduct")]
        [JWTAuth(new EUserRole[] {
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
        })]
        [ExcludeFromAntiForgeryValidation]
        public void UploadProduct()
        {
        }
    }
}