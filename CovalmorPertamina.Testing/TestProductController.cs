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
    public class TestProductController : TestBaseController
    {
        private ProductController _productController;

        public TestProductController()
        {
            _productController = new ProductController(_entityFactory);
        }

        [TestMethod]
        public async Task ReadListProduct_ShouldReturnHttpStatusCode200AndCountValue4()
        {
            HttpJsonApiResult<IEnumerable<ProductModel>> data = await _productController.Get()
                as HttpJsonApiResult<IEnumerable<ProductModel>>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(new List<ProductModel>(data.DataValue).Count, 4);
        }

        [TestMethod]
        public async Task ReadProductWithParamterId2_ShouldReturnHttpStatusCode200AndProductModel()
        {
            HttpJsonApiResult<ProductModel> data = await _productController.Get(2)
                as HttpJsonApiResult<ProductModel>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Id, 2);
            Assert.AreEqual(data.DataValue.MaterialNo, "002");
            Assert.AreEqual(data.DataValue.MaterialGroup, "002");
            Assert.AreEqual(data.DataValue.MaterialName, "Pertalite");
        }

        [TestMethod]
        public async Task ReadProductWithParamterId5NotFound_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _productController.Get(5)
                as HttpJsonApiResult<string>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task UpdateProductWithParameterId1_ShouldReturnHttpStatusCode200AndProductModel()
        {
            HttpJsonApiResult<ProductModel> data = await _productController.Update(1, new ProductRequest()
            {
                MaterialNo = "000",
                MaterialName = "Ketukar",
                MaterialGroup = "000"
            }) as HttpJsonApiResult<ProductModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Id, 1);
            Assert.AreEqual(data.DataValue.MaterialNo, "000");
            Assert.AreEqual(data.DataValue.MaterialName, "Ketukar");
            Assert.AreEqual(data.DataValue.MaterialGroup, "000");
        }

        [TestMethod]
        public async Task UpdateProductWithParameterId7NotFound_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _productController.Update(7, new ProductRequest()
            {
                MaterialNo = "000",
                MaterialName = "Ketukar",
                MaterialGroup = "000"
            }) as HttpJsonApiResult<string>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task DeleteProductWithParameterId3_ShouldReturnHttpStatusCode200AndProductModel()
        {
            HttpJsonApiResult<ProductModel> data = await _productController.Delete(3)
                as HttpJsonApiResult<ProductModel>;
            
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Id, 3);
            Assert.AreEqual(data.DataValue.MaterialNo, "003");
            Assert.AreEqual(data.DataValue.MaterialGroup, "003");
            Assert.AreEqual(data.DataValue.MaterialName, "Solar");
        }

        [TestMethod]
        public async Task DeleteProductWithParameterId6NotFound_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _productController.Delete(6)
                as HttpJsonApiResult<string>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task CreateProductSuccess_ShouldReturnHttpStatusCode201AndProductModel()
        {
            HttpJsonApiResult<ProductModel> data = await _productController.Post(new ProductRequest()
            {
                MaterialNo = "000",
                MaterialName = "Baru",
                MaterialGroup = "000"
            }) as HttpJsonApiResult<ProductModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.Created);
            Assert.AreEqual(data.DataValue.MaterialNo, "000");
            Assert.AreEqual(data.DataValue.MaterialName, "Baru");
            Assert.AreEqual(data.DataValue.MaterialGroup, "000");
        }
    }
}
