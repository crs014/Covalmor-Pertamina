using CovalmorPertamina.Entity.Enum;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CovalmorPertamina.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index()
        {   
            ViewBag.Roles = new List<object>()
            {
                    new { Id = EUserRole.Admin, Name = "Admin" },
                    new { Id = EUserRole.User, Name = "User"},
                    new { Id = EUserRole.AR, Name = "AR" },
                    new { Id = EUserRole.CashBank, Name = "Cash Bank" },
                    new { Id = EUserRole.FBS, Name = "FBS" },
                    new { Id = EUserRole.ManagementRisk, Name = "Management Risiko" },
                    new { Id = EUserRole.KomiteCredit, Name = "Komite Kredit" },
            };
            return View();
        }
    }
}