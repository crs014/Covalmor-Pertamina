using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Testing.Db;
using CovalmorPertamina.Web.Controllers.Api;
using CovalmorPertamina.Web.Models;
using CovalmorPertamina.Entity.Model.Auth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Net;
using CovalmorPertamina.Web.Requests;
using CovalmorPertamina.Entity.Enum;
using System.Collections.Generic;
using System.Web.Http;
using CovalmorPertamina.Entity.Model;

namespace CovalmorPertamina.Testing
{
    [TestClass]
    public class TestUserController : TestBaseController
    {
        private UserController _userController;

        public TestUserController()
        {
            _userController = new UserController(_entityFactory);
        }

        private Task<IHttpActionResult> _UserLogin()
        {
            return _userController.Login(new LoginData()
            {
                Email = "admin@covalmor1.com",
                Password = "12345678"
            });
        }

        [TestMethod]
        public async Task UserLoginSuccess_ShouldReturnHttpStatusCode200()
        {
            HttpJsonApiResult<DataToken> data = await _UserLogin() as HttpJsonApiResult<DataToken>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task RefreshTokenSuccess_ShouldReturnHttpStatusCode200()
        {
            HttpJsonApiResult<DataToken> data = await _UserLogin() as HttpJsonApiResult<DataToken>;
            HttpJsonApiResult<DataToken> refreshData = await _userController.RefreshToken(new RefreshData()
            {
                RefreshToken = data.DataValue.RefreshToken
            }) as HttpJsonApiResult<DataToken>;
            Assert.AreEqual(refreshData.StatusCode, HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task UserLoginNotFound_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _userController.Login(new LoginData()
            {
                Email = "nothing@covalmor1.com",
                Password = "123456"
            }) as HttpJsonApiResult<string>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task ReadListUser_ShouldReturnHttpStatusCode200AndCountValue4()
        {
            HttpJsonApiResult<IEnumerable<UserModel>> data = await _userController.Get()
                as HttpJsonApiResult<IEnumerable<UserModel>>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(new List<UserModel>(data.DataValue).Count, 4);
        }

        [TestMethod]
        public async Task ReadUserWithParameterIdIs2_ShouldReturnHttpStatusCode200AndUserModel()
        {
            HttpJsonApiResult<UserModel> data = await _userController.Get(2) 
                as HttpJsonApiResult<UserModel>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Id, 2);
            Assert.AreEqual(data.DataValue.Name, "AR");
            Assert.AreEqual(data.DataValue.Email, "ar@covalmor1.com");
            Assert.AreEqual(data.DataValue.Jabatan, "Management Resiko");
            Assert.AreEqual(data.DataValue.Role, "AR");
            Assert.AreEqual(data.DataValue.UserRole, EUserRole.AR);
        }

        [TestMethod]
        public async Task ReadUserWithParameterIdIs5NotFound_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _userController.Get(5)
                as HttpJsonApiResult<string>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task UpdateUserWithParameterIdIs3_ShouldReturnHttpStatusCode200AndUserModel()
        {
            HttpJsonApiResult<UserModel> data = await _userController.Update(3, new UserUpdateRequest()
            {
                Name = "Tukar Nama",
                Email = "tukaremail@mail.com",
                Jabatan = "Tukar jabatan",
                Role = EUserRole.Admin
            }) as HttpJsonApiResult<UserModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Name, "Tukar Nama");
            Assert.AreEqual(data.DataValue.Email, "tukaremail@mail.com");
            Assert.AreEqual(data.DataValue.Jabatan, "Tukar jabatan");
            Assert.AreEqual(data.DataValue.Role, "Admin");
            Assert.AreEqual(data.DataValue.UserRole, EUserRole.Admin);
        }

        [TestMethod]
        public async Task UpdateUserWithParameterIdIs6NotFound_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _userController.Update(6, new UserUpdateRequest()
            {
                Name = "Tukar Nama",
                Email = "tukaremail@mail.com",
                Jabatan = "Tukar jabatan",
                Role = EUserRole.Admin
            }) as HttpJsonApiResult<string>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task DeleteUserWithParameterIdIs4_ShoulReturnHttpStatusCode200AndUserModel()
        {
            HttpJsonApiResult<UserModel> data = await _userController.Delete(4)
                as HttpJsonApiResult<UserModel>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Id, 4);
            Assert.AreEqual(data.DataValue.Name, "FBS");
            Assert.AreEqual(data.DataValue.Email, "fbs@covalmor1.com");
            Assert.AreEqual(data.DataValue.Jabatan, "Keuangan");
            Assert.AreEqual(data.DataValue.Role, "FBS");
            Assert.AreEqual(data.DataValue.UserRole, EUserRole.FBS);
        }

        [TestMethod]
        public async Task DeleteUserWithParameterIdIs7NotFound_ShoulReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _userController.Delete(7)
                as HttpJsonApiResult<string>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task CreateUserSuccess_ShouldReturnHttpStatusCode201AndUserModel()
        {
            HttpJsonApiResult<UserModel> data = await _userController.Post(new UserRequest()
            {
                Name = "ucok",
                Email = "ucok@covalmor1.com",
                Password = "12345678",
                Jabatan = "Karyawan",
                Role = EUserRole.User
            }) as HttpJsonApiResult<UserModel>;

            UserModel userModel = data.DataValue;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.Created);
            Assert.AreEqual(userModel.Name, "ucok");
            Assert.AreEqual(userModel.Email, "ucok@covalmor1.com");
            Assert.AreEqual(userModel.Jabatan, "Karyawan");
            Assert.AreEqual(userModel.Role, "User");
            Assert.AreEqual(userModel.UserRole, EUserRole.User);
        }
        
        [TestMethod]
        public void ReadSelfSuccess_ShouldReturnHttpStatusCode200AndUserModel()
        {
            _userController.SetUserAuth(new UserModel(new User()
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@covalmor1.com",
                Jabatan = "Komisaris",
                Role = EUserRole.Admin
            }));

            HttpJsonApiResult<UserModel> data = _userController.Self() 
                as HttpJsonApiResult<UserModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Id, 1);
            Assert.AreEqual(data.DataValue.Name, "Admin");
            Assert.AreEqual(data.DataValue.Email, "admin@covalmor1.com");
            Assert.AreEqual(data.DataValue.Jabatan, "Komisaris");
            Assert.AreEqual(data.DataValue.UserRole, EUserRole.Admin);
        }
    }
}
