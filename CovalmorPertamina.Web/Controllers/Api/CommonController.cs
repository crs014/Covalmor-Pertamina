using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Common.Statics;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Web.Attributes;
using CovalmorPertamina.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Http;

namespace CovalmorPertamina.Web.Controllers.Api
{
    [JWTAuth(new EUserRole[] {
        EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
        EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk
    })]
    public class CommonController : BaseApiController
    {
        [HttpGet]
        [ActionName("1TKOPNT")]
        public string Get1TKOPNTPDF()
        {
            byte[] fileByte = File.ReadAllBytes(ConstantValue.FilePath.BasePdf1TKOPNTPathFile);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("2TKOCA")]
        public string Get2TKOCA()
        {
            byte[] fileByte = File.ReadAllBytes(ConstantValue.FilePath.BasePdf2TKOCAPathFile);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("3TKI")]
        public string Get3TKI()
        {
            byte[] fileByte = File.ReadAllBytes(ConstantValue.FilePath.BasePdf3TKIPathFile);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("4SKO")]
        public string Get4SKO()
        {
            byte[] fileByte = File.ReadAllBytes(ConstantValue.FilePath.BasePdf4SKOPathFile);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("5LKPBP")]
        public string Get5LKPBP()
        {
            byte[] fileByte = File.ReadAllBytes(ConstantValue.FilePath.BasePdf5LKPBPPathFile);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("6SPKK")]
        public string Get6SPKK()
        {
            byte[] fileByte = File.ReadAllBytes(ConstantValue.FilePath.BasePdf6SPKKPathFile);
            return Convert.ToBase64String(fileByte);
        }

        [HttpGet]
        [ActionName("MenuItem")]
        public IHttpActionResult MenuItem()
        {
            try
            {
                UserModel userAuth = GetUserAuth();
                List<MenuHeader> listItemMenu = new List<MenuHeader>();

                if (userAuth != null)
                {
                    if (userAuth.UserRole == EUserRole.Admin)
                    {
                        #region admin
                        listItemMenu.Add(new MenuHeader()
                        {
                            Label = "Kredit",
                            IconClass = "fa fa-credit-card",
                            ItemMenu = new List<ItemMenu>()
                        {
                            new ItemMenu()
                            {
                                Label = "List Credit Approval",
                                ActionName = Url.Link("Default", new { Controller = "Credit", Action = "Index" })
                            }
                        }
                        });
                        listItemMenu.Add(new MenuHeader()
                        {
                            Label = "Master",
                            IconClass = "fa fa-database",
                            ItemMenu = new List<ItemMenu>()
                        {
                            new ItemMenu()
                            {
                                Label = "User",
                                ActionName = Url.Link("Default", new { Controller = "User", Action = "Index" })
                            },
                            new ItemMenu()
                            {
                                Label = "Customer",
                                ActionName = Url.Link("Default", new { Controller = "Customer", Action = "Index" })
                            },
                            new ItemMenu()
                            {
                                Label = "Product",
                                ActionName = Url.Link("Default", new { Controller = "Product", Action = "Index" })
                            },
                            new ItemMenu()
                            {
                                Label = "Tanda Tangan",
                                ActionName = Url.Link("Default", new { Controller = "Signature", Action = "Index" })
                            },
                        }
                        });
                        #endregion
                    }
                    else if (userAuth.UserRole == EUserRole.User)
                    {
                        #region user
                        listItemMenu.Add(new MenuHeader()
                        {
                            Label = "Kredit",
                            IconClass = "fa fa-credit-card",
                            ItemMenu = new List<ItemMenu>()
                        {
                            new ItemMenu()
                            {
                                Label = "New Request",
                                ActionName = Url.Link("Default", new { Controller = "Credit", Action = "Create" })
                            },
                            new ItemMenu()
                            {
                                Label = "List Credit Approval",
                                ActionName = Url.Link("Default", new { Controller = "Credit", Action = "Index" })
                            }
                        }
                        });
                        #endregion
                    }
                    else if (userAuth.UserRole == EUserRole.AR || userAuth.UserRole == EUserRole.CashBank
                        || userAuth.UserRole == EUserRole.FBS || userAuth.UserRole == EUserRole.ManagementRisk
                        || userAuth.UserRole == EUserRole.KomiteCredit)
                    {
                        #region ar, cashbank, fbs, managementrisk, komitekredit
                        listItemMenu.Add(new MenuHeader()
                        {
                            Label = "Kredit",
                            IconClass = "fa fa-credit-card",
                            ItemMenu = new List<ItemMenu>()
                        {
                            new ItemMenu()
                            {
                                Label = "List Credit Approval",
                                ActionName = Url.Link("Default", new { Controller = "Credit", Action = "Index" })
                            }
                        }
                        });
                        #endregion
                    }
                }
                return new HttpJsonApiResult<List<MenuHeader>>(
                    listItemMenu, Request, HttpStatusCode.OK);
            }
            catch(Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }
    }
}