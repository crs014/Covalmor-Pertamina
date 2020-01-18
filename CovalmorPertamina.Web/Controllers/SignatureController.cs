using System.Web.Mvc;

namespace CovalmorPertamina.Web.Controllers
{
    public class SignatureController : Controller
    {
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}