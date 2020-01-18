using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Web.Controllers.Api;
using CovalmorPertamina.Web.Models;
using CovalmorPertamina.Web.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CovalmorPertamina.Testing
{
    [TestClass]
    public class TestSignatureController : TestBaseController
    {
        private SignatureController _signatureController;

        public TestSignatureController()
        {
            _signatureController = new SignatureController(_entityFactory);
        }

        [TestMethod]
        public async Task ReadListSignature_ShouldReturnHttpStatusCode200AndCountValue4()
        {
            HttpJsonApiResult<IEnumerable<SignatureModel>> data = await _signatureController.Get()
                as HttpJsonApiResult<IEnumerable<SignatureModel>>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(new List<SignatureModel>(data.DataValue).Count, 4);
        }

        [TestMethod]
        public async Task ReadSignatureWithParamterId2_ShouldReturnHttpStatusCode200AndSignatureModel()
        {
            HttpJsonApiResult<SignatureModel> data = await _signatureController.Get(2)
                as HttpJsonApiResult<SignatureModel>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Id, 2);
            Assert.AreEqual(data.DataValue.Name1, "Goku");
            Assert.AreEqual(data.DataValue.Name2, "Vegeta");
            Assert.AreEqual(data.DataValue.Position1, "Earth Saiyan");
            Assert.AreEqual(data.DataValue.Position2, "Prince Saiyan");
        }

        [TestMethod]
        public async Task ReadSignatureWithParamterId5NotFound_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _signatureController.Get(5)
                as HttpJsonApiResult<string>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task UpdateSignatureWithParameterId1_ShouldReturnHttpStatusCode200AndSignatureModel()
        {
            HttpJsonApiResult<SignatureModel> data = await _signatureController.Update(1, new SignatureRequest()
            {
                Name1 = "Goku",
                Name2 = "Vegeta",
                Position1 = "Earth Saiyan",
                Position2 = "Prince Saiyan",
                DocumentType = "CA"
            }) as HttpJsonApiResult<SignatureModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Id, 1);
            Assert.AreEqual(data.DataValue.Name1, "Goku");
            Assert.AreEqual(data.DataValue.Name2, "Vegeta");
            Assert.AreEqual(data.DataValue.Position1, "Earth Saiyan");
            Assert.AreEqual(data.DataValue.Position2, "Prince Saiyan");
        }

        [TestMethod]
        public async Task UpdateSignatureWithParameterId7NotFound_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _signatureController.Update(7, new SignatureRequest()
            {
                Name1 = "Goku",
                Name2 = "Vegeta",
                Position1 = "Earth Saiyan",
                Position2 = "Prince Saiyan",
                DocumentType = "CA"
            }) as HttpJsonApiResult<string>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task DeleteSignatureWithParameterId3_ShouldReturnHttpStatusCode200AndSignatureModel()
        {
            HttpJsonApiResult<SignatureModel> data = await _signatureController.Delete(3)
                as HttpJsonApiResult<SignatureModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Id, 3);
            Assert.AreEqual(data.DataValue.Name1, "Ramen");
            Assert.AreEqual(data.DataValue.Name2, "Burger");
            Assert.AreEqual(data.DataValue.Position1, "Japanese Noodle");
            Assert.AreEqual(data.DataValue.Position2, "USA Sandwich");
            Assert.AreEqual(data.DataValue.DocumentType, "CA");
        }

        [TestMethod]
        public async Task DeleteSignatureWithParameterId6NotFound_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _signatureController.Delete(6)
                as HttpJsonApiResult<string>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task CreateSignatureSuccess_ShouldReturnHttpStatusCode201AndSignatureModel()
        {
            HttpJsonApiResult<SignatureModel> data = await _signatureController.Post(new SignatureRequest()
            {
                Name1 = "Baru1",
                Name2 = "Baru2",
                Position1 = "Posisi1",
                Position2 = "Posisi2",
                DocumentType = "CA"
            }) as HttpJsonApiResult<SignatureModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.Created);
            Assert.AreEqual(data.DataValue.Name1, "Baru1");
            Assert.AreEqual(data.DataValue.Name2, "Baru2");
            Assert.AreEqual(data.DataValue.Position1, "Posisi1");
            Assert.AreEqual(data.DataValue.Position2, "Posisi2");
            Assert.AreEqual(data.DataValue.DocumentType, "CA");
        }
    }
}
