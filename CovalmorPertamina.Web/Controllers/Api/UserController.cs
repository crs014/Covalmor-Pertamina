using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Entity;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Model.Auth;
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
    public class UserController : BaseApiController
    {
        public UserController(IEntityFactory entityFactory)
        {
            _userRepository = entityFactory.Repositories(ERepository.User) as IUserRepository;
            _trCaActionNoteRepository = entityFactory.Repositories(ERepository.TrCaActionNote) as ITrCaActionNoteRepository;
        }

        [HttpGet]
        [ActionName("Index")]
        [JWTAuth(new EUserRole[] { EUserRole.Admin })]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                IQueryable<User> users = await Task.FromResult(_userRepository.GetAll());
                return new HttpJsonApiResult<IEnumerable<UserModel>>(
                    UserModel.GetAll(users), Request, HttpStatusCode.OK);
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
                IQueryable<UserDataTableModel> users = await Task.FromResult(_userRepository.GetAll()
                    .OrderByDescending(e => e.UpdatedAt)
                    .Select(e => new UserDataTableModel() { 
                        Id = e.Id,
                        Name = e.Name,
                        Email = e.Email,
                        Role = e.Role.ToString()
                    }));
                return Ok(users);
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
                User user = await _userRepository.GetOne(id);
                if (user == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<UserModel>(
                    new UserModel(user), Request, HttpStatusCode.OK);
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
        public async Task<IHttpActionResult> Post([FromBody]UserRequest data)
        {
            try
            {
                User user = await _userRepository.Create(data.GetObject());
                return new HttpJsonApiResult<UserModel>(
                    new UserModel(user), Request, HttpStatusCode.Created);
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
        public async Task<IHttpActionResult> Update(int id, [FromBody]UserUpdateRequest data)
        {
            try
            {
                User user = await _userRepository.Update(id, data.GetObject());
                if (user == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<UserModel>(
                    new UserModel(user), Request, HttpStatusCode.OK);
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
                IEnumerable<TrCaActionNote> trCaActionNotes = await Task.FromResult(_trCaActionNoteRepository.DeleteByCreatedBy(id));
                User user = await _userRepository.Delete(id);
                if (user == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<UserModel>(
                    new UserModel(user), Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                   "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IHttpActionResult> Login([FromBody] LoginData login)
        {
            try
            {
                DataToken dataToken = await _userRepository.UserLogin(login);
                if (dataToken == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<DataToken>(dataToken, Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                   "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ActionName("RefreshToken")]
        public async Task<IHttpActionResult> RefreshToken([FromBody] RefreshData refreshData)
        {
            try
            {
                DataToken dataToken = await _userRepository.RefreshToken(refreshData.RefreshToken);
                if (dataToken == null)
                {
                    return new HttpJsonApiResult<string>("Not Found", Request, HttpStatusCode.NotFound);
                }
                return new HttpJsonApiResult<DataToken>(dataToken, Request, HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpJsonApiResult<string>(
                   "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [ActionName("Self")]
        [JWTAuth(new EUserRole[] { 
            EUserRole.Admin, EUserRole.User, EUserRole.AR, EUserRole.CashBank,
            EUserRole.FBS, EUserRole.KomiteCredit, EUserRole.ManagementRisk 
        })]
        public IHttpActionResult Self()
        {
            try
            {
                UserModel userModel = GetUserAuth();
                return new HttpJsonApiResult<UserModel>(GetUserAuth(), Request, HttpStatusCode.OK);
            }
            catch(Exception)
            {
                return new HttpJsonApiResult<string>(
                   "Internal Server Error", Request, HttpStatusCode.InternalServerError);
            }
        }
    }
}