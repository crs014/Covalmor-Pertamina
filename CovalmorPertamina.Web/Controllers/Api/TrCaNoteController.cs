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
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace CovalmorPertamina.Web.Controllers.Api
{
    public class TrCaNoteController : BaseApiController
    {

        public TrCaNoteController(IEntityFactory entityFactory)
        {
            _trCaNoteRepository = entityFactory.Repositories(ERepository.TrCaNote) as ITrCaNoteRepository;
        }

        [HttpGet]
        [ActionName("Index")]
        [JWTAuth(new EUserRole[] { EUserRole.FBS })]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                TrCaNote trCaNote = await _trCaNoteRepository.GetOneByCreditId(id);
                if(trCaNote == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<TrCaNoteModel>(
                    new TrCaNoteModel(trCaNote), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("Create")]
        [JWTAuth(new EUserRole[] { EUserRole.FBS })]
        public async Task<IHttpActionResult> Post([FromBody]TrCaNoteRequest data)
        {
            try
            {
                TrCaNote trCaNoteData = data.GetObject();
                trCaNoteData.CreatedBy = GetUserAuth().Name;
                TrCaNote trCaNote = await _trCaNoteRepository.Create(trCaNoteData);
                return new HttpJsonApiResult<TrCaNoteModel>(
                   new TrCaNoteModel(trCaNote), Request, HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPatch]
        [ActionName("Update")]
        [JWTAuth(new EUserRole[] { EUserRole.FBS })]
        public async Task<IHttpActionResult> Update(int id, [FromBody]TrCaNoteRequest data)
        {
            try
            {
                TrCaNote trCaNote = await _trCaNoteRepository.UpdateByCreditId(id, data.GetObject());
                if(trCaNote == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<TrCaNoteModel>(
                    new TrCaNoteModel(trCaNote), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                    "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }
    }
}