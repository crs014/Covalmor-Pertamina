using CovalmorPertamina.Common.Interfaces;
using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Entity;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using CovalmorPertamina.Web.Attributes;
using CovalmorPertamina.Web.Models;
using CovalmorPertamina.Web.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CovalmorPertamina.Web.Controllers.Api
{
    public class CustomerDetailController : BaseApiController
    {
        public CustomerDetailController(IEntityFactory entityFactory)
        {
            _caCustomerDetailRepository = entityFactory.Repositories(ERepository.CaCustomerDetail) as ICaCustomerDetailRepository;
        }
        
        [HttpGet]
        [ActionName("Index")]
        [JWTAuth(new EUserRole[] { EUserRole.AR })]
        public async Task<IHttpActionResult> Get(int id)
        {
            try 
            {
                CaCustomerDetail caCustomerDetail = await _caCustomerDetailRepository.GetOne(id);
                if(caCustomerDetail == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<CustomerDetailModel>(
                    new CustomerDetailModel(caCustomerDetail), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("Create")]
        [JWTAuth(new EUserRole[] { EUserRole.AR })]
        public async Task<IHttpActionResult> Post([FromBody]CustomerDetailRequest data)
        {
            try
            {
                CaCustomerDetail dataCaCustomerDetail = data.GetObject();
                dataCaCustomerDetail.CreatedBy = GetUserAuth().Name;

                CaCustomerDetail caCustomerDetail = await _caCustomerDetailRepository.Create(dataCaCustomerDetail);
                return new HttpJsonApiResult<CustomerDetailModel>(
                   new CustomerDetailModel(caCustomerDetail), Request, HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPatch]
        [ActionName("Update")]
        [JWTAuth(new EUserRole[] { EUserRole.AR })]
        public async Task<IHttpActionResult> Update(int id, [FromBody]CustomerDetailRequest data)
        {
            try
            {
                CaCustomerDetail caCustomerDetail = await _caCustomerDetailRepository.Update(id, data.GetObject());
                if (caCustomerDetail == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<CustomerDetailModel>(
                    new CustomerDetailModel(caCustomerDetail), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [ActionName("Delete")]
        [JWTAuth(new EUserRole[] { EUserRole.AR })]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                CaCustomerDetail caCustomerDetail = await _caCustomerDetailRepository.Delete(id);
                if (caCustomerDetail == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<CustomerDetailModel>(
                    new CustomerDetailModel(caCustomerDetail), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }
    }
}