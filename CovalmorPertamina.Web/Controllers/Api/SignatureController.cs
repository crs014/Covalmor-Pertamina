using CovalmorPertamina.Common.Services;
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
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace CovalmorPertamina.Web.Controllers.Api
{
    public class SignatureController : BaseApiController
    {
        public SignatureController(IEntityFactory entityFactory)
        {
            _signatureRepository = entityFactory.Repositories(ERepository.Signature) as ISignatureRepository;
        }

        [HttpGet]
        [ActionName("Index")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin })]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                IQueryable<Signature> signatures = await Task.FromResult(_signatureRepository.GetAll());
                return new HttpJsonApiResult<IEnumerable<SignatureModel>>(
                    SignatureModel.GetAll(signatures), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [ActionName("Index")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin })]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Signature signature = await _signatureRepository.GetOne(id);
                if(signature == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<SignatureModel>(
                   new SignatureModel(signature), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("datatable")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin })]
        [JQDataTable]
        public async Task<IHttpActionResult> GetDataTable()
        {
            try
            {
                IQueryable<SignatureDataTableModel> signatures = await Task.FromResult(_signatureRepository.GetAll()
                    .OrderByDescending(e => e.UpdatedAt)
                    .Select(e => new SignatureDataTableModel() 
                    {
                        Id = e.Id,
                        Name1 = e.Name1,
                        Position1 = e.Position1,
                        Name2 = e.Name2,
                        Position2 = e.Position2,
                        DocumentType = e.DocumentType
                    }));
                return Ok(signatures);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("Create")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin })]
        public async Task<IHttpActionResult> Post([FromBody]SignatureRequest data)
        {
            try
            {
                Signature signature = await _signatureRepository.Create(data.GetObject());
                return new HttpJsonApiResult<SignatureModel>(
                    new SignatureModel(signature), Request, HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPatch]
        [ActionName("Update")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin })]
        public async Task<IHttpActionResult> Update(int id, [FromBody]SignatureRequest data)
        {
            try
            {
                Signature signature = await _signatureRepository.Update(id, data.GetObject());
                if (signature == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<SignatureModel>(
                    new SignatureModel(signature), Request, HttpStatusCode.OK);
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
                Signature signature = await _signatureRepository.Delete(id);
                if (signature == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<SignatureModel>(
                    new SignatureModel(signature), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }
    }
}