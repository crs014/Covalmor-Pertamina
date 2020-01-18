using System.Web.Mvc;

namespace CovalmorPertamina.Web.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}