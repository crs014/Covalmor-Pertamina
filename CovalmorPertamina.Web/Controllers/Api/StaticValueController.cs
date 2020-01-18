using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Entity;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using CovalmorPertamina.Web.Attributes;
using CovalmorPertamina.Web.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace CovalmorPertamina.Web.Controllers.Api
{
    public class StaticValueController : BaseApiController
    {
        public StaticValueController(IEntityFactory entityFactory)
        {
            _staticValueRepository = entityFactory.Repositories(ERepository.StaticValue) as IStaticValueRepository;
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
                IEnumerable<StaticValue> staticValues = await Task.FromResult(_staticValueRepository.GetAll());
                return new HttpJsonApiResult<IEnumerable<StaticValueModel>>(
                    StaticValueModel.GetAll(staticValues), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }
    }
}