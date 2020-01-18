using CovalmorPertamina.Common.Interfaces;
using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Entity.Repository.Interfaces;
using CovalmorPertamina.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace CovalmorPertamina.Web.Controllers.Api
{
    public abstract class BaseApiController : ApiController
    {
        #region protected variable interface
        protected IObjectService _objectService;
        protected IFileUploadHandler _fileUploadHandler;
        protected IPdfService _pdfService;

        #region repository
        protected ICustomerRepository _customerRepository; 
        protected IProductRepository _productRepository; 
        protected ISignatureRepository _signatureRepository; 
        protected IStaticValueRepository _staticValueRepository; 
        protected ICreditApprovalRepository _creditApprovalRepository; 
        protected ICaCustomerDetailRepository _caCustomerDetailRepository; 
        protected ICreditScoringRepository _creditScoringRepository; 
        protected IQuantitativeAspectRepository _quantitativeAspectRepository; 
        protected ITrCaActionNoteRepository _trCaActionNoteRepository; 
        protected ITrCaNoteRepository _trCaNoteRepository; 
        protected ITrCaProductRepository _trCaProductRepository; 
        protected IUserRepository _userRepository;
        #endregion

        #endregion

        #region public method
        public BaseApiController()
        {
            _objectService = new ObjectService<UserModel>();
        }

        public void SetUserAuth(UserModel userModel)
        {
            _userAuth = userModel;
            _isTesting = true;
        }
        #endregion

        #region private variable
        private UserModel _userAuth;
        private bool _isTesting = false;
        #endregion

        #region protected method
        protected UserModel GetUserAuth() 
        {
            if (_isTesting)
            {
                return _userAuth;
            }
            else
            {
                return (UserModel)_objectService.DeserializerObject(Thread.CurrentPrincipal.Identity.Name);
            }
        }

        protected IHttpActionResult ReadFilePdf(string path)
        {
            IHttpActionResult response;
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            byte[] fileByte = File.ReadAllBytes(HttpContext.Current.Server.MapPath(path));
            responseMessage.Content = new ByteArrayContent(fileByte);
            responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response = ResponseMessage(responseMessage);
            return response;
        }

        protected string UploadSingleFile(string pathStorage, string fileName)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;
            if (file != null && file.ContentLength > 0)
            {
                var path = Path.Combine(
                    HttpContext.Current.Server.MapPath(pathStorage),
                    fileName
                );

                file.SaveAs(path);
            }
            return file != null ? pathStorage + "/" + fileName : null;
        }
        #endregion

        #region inner class
        protected class ItemMenu
        {
            public string Label { get; set; }
            public string ActionName { get; set; }
        }

        protected class MenuHeader
        {
            public string Label { get; set; }
            public string IconClass { get; set; }
            public List<ItemMenu> ItemMenu { get; set; } = new List<ItemMenu>();
        }
        #endregion
    }
}