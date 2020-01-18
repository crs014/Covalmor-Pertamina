using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Common.Statics;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Web.Controllers.Api;
using CovalmorPertamina.Web.Models;
using CovalmorPertamina.Web.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace CovalmorPertamina.Testing
{
    [TestClass]
    public class TestTrCaNoteController : TestBaseController
    {
        private TrCaNoteController _trCaNoteController;

        public TestTrCaNoteController()
        {
            _trCaNoteController = new TrCaNoteController(_entityFactory);
        }

        [TestMethod]
        public async Task ReadTrCaNoteSuccess_ShouldReturnHttpStatusCode200()
        {
            HttpJsonApiResult<TrCaNoteModel> data = await _trCaNoteController.Get(1)
                as HttpJsonApiResult<TrCaNoteModel>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task ReadTrCaNoteFailed_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _trCaNoteController.Get(4)
              as HttpJsonApiResult<string>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task CreateTrCaNoteSuccess_ShouldReturnHttpStatusCode201()
        {
            _trCaNoteController.SetUserAuth(new UserModel(new User()
            {
                Id = 5,
                Name = "FBS",
                Email = "fbs@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.FBS
            }));

            HttpJsonApiResult<TrCaNoteModel> data = await _trCaNoteController.Post(new TrCaNoteRequest()
            {
                CreditApprovalId = 3,
                Perihal = "testing",
                Isi = "Hahahahahaha"
            }) as HttpJsonApiResult<TrCaNoteModel>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task UpdatedTrCaNoteSuccess_ShouldReturnHttpStatusCode200()
        {
            HttpJsonApiResult<TrCaNoteModel> data = await _trCaNoteController.Update(1, new TrCaNoteRequest()
            {
                Perihal = "testing",
                Isi = "Hahahahahaha"
            }) as HttpJsonApiResult<TrCaNoteModel>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task UpdatedTrCaNoteFailed_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _trCaNoteController.Update(7, new TrCaNoteRequest()
            {
                Perihal = "testing",
                Isi = "Hahahahahaha"
            }) as HttpJsonApiResult<string>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

    }
}
