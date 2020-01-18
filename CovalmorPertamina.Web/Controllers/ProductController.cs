using System.Web.Mvc;

namespace CovalmorPertamina.Web.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}