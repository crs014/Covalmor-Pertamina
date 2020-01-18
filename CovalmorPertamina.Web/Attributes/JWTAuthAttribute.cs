using CovalmorPertamina.Common.Interfaces;
using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Common.Statics;
using CovalmorPertamina.Entity;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CovalmorPertamina.Web.Attributes
{
    public class JWTAuthAttribute : AuthorizeAttribute
    {
        private bool _isCanAccess;
        private EUserRole[] _roles;
        private IJWTService _jwtService;
        private IObjectService _objectService;
        private IJWTContainerModel _authModel;
        protected IDBCovalmor _db;

        public JWTAuthAttribute(EUserRole[] roles)
        {
            _roles = roles;
            _authModel = StaticJWTContainer.GetAuthModel();
            _jwtService = new JWTService();
            _isCanAccess = false;
            _objectService = new ObjectService<UserModel>();
            _jwtService.SetVariable(_authModel.SecretKey);
            _db = new DBCovalmor();
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Authorization == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                        new HttpJsonApiResult<string>("Unauthorized", actionContext.Request, HttpStatusCode.Unauthorized));
                }
                else
                {
                    string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                    if(_jwtService.IsTokenValid(authenticationToken))
                    {
                        List<Claim> claims = _jwtService.GetTokenClaims(authenticationToken).ToList();
                        int userId = Convert.ToInt32(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.NameIdentifier)).Value);
                        User user = _db.Users.Where(e => e.Id == userId).FirstOrDefault();
                        
                        foreach(EUserRole role in _roles)
                        {
                            if(user.Role == role)
                            {
                                _isCanAccess = true;
                                break;
                            }
                        }

                        if(_isCanAccess)
                        {
                            UserModel userData = new UserModel(user);
                            Thread.CurrentPrincipal = new GenericPrincipal(
                                new GenericIdentity(_objectService.SerializerObject(userData)), null);
                        }
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                            new HttpJsonApiResult<string>("Unauthorized", actionContext.Request, HttpStatusCode.Unauthorized));
                    }
                }
            }
            catch (Exception)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                       new HttpJsonApiResult<string>("Unauthorized", actionContext.Request, HttpStatusCode.Unauthorized));
            }
        }
    }
}