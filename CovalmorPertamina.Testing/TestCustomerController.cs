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
    public class TestCustomerController : TestBaseController
    {
        private CustomerController _customerController;

        public TestCustomerController()
        {
            _customerController = new CustomerController(_entityFactory);
        }

        [TestMethod]
        public async Task ReadListCustomer_ShouldReturnHttpStatusCode200AndCountValue4()
        {
            HttpJsonApiResult<IEnumerable<CustomerModel>> data = await _customerController.Get()
                as HttpJsonApiResult<IEnumerable<CustomerModel>>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(new List<CustomerModel>(data.DataValue).Count, 4);
        }

        [TestMethod]
        public async Task ReadCustomerWithParamterId2_ShouldReturnHttpStatusCode200AndCustomerModel()
        {
            HttpJsonApiResult<CustomerModel> data = await _customerController.Get(2)
                as HttpJsonApiResult<CustomerModel>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Id, 2);
            Assert.AreEqual(data.DataValue.CustomerNo, "4616111");
            Assert.AreEqual(data.DataValue.Name, "Cv Kamehameha Batam");
            Assert.AreEqual(data.DataValue.Email, "kamehamehabatam@mail.com");
            Assert.AreEqual(data.DataValue.Address, "Pulau roshi");
            Assert.AreEqual(data.DataValue.NPWP, "222333444");
        }

        [TestMethod]
        public async Task ReadCustomerWithParamterId5NotFound_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _customerController.Get(5)
                as HttpJsonApiResult<string>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task UpdateCustomerWithParameterId1_ShouldReturnHttpStatusCode200AndCustomerModel()
        {
            HttpJsonApiResult<CustomerModel> data = await _customerController.Update(1, new CustomerRequest()
            {
                CustomerNo = "12345678",
                Name = "Tukar123",
                Email = "tukar@mail.com",
                Address = "Tukar Alamat",
                NPWP = "22678910"
            }) as HttpJsonApiResult<CustomerModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Id, 1);
            Assert.AreEqual(data.DataValue.CustomerNo, "12345678");
            Assert.AreEqual(data.DataValue.Name, "Tukar123");
            Assert.AreEqual(data.DataValue.Email, "tukar@mail.com");
            Assert.AreEqual(data.DataValue.Address, "Tukar Alamat");
            Assert.AreEqual(data.DataValue.NPWP, "22678910");
        }

        [TestMethod]
        public async Task UpdateCustomerWithParameterId7NotFound_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _customerController.Update(7, new CustomerRequest()
            {
                CustomerNo = "12345678",
                Name = "Tukar123",
                Email = "tukar@mail.com",
                Address = "Tukar Alamat",
                NPWP = "22678910"
            }) as HttpJsonApiResult<string>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task DeleteCustomerWithParameterId3_ShouldReturnHttpStatusCode200AndCustomerModel()
        {
            HttpJsonApiResult<CustomerModel> data = await _customerController.Delete(3) 
                as HttpJsonApiResult<CustomerModel>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.CustomerNo, "3456789");
            Assert.AreEqual(data.DataValue.Name, "PT Santai Menyantai");
            Assert.AreEqual(data.DataValue.Email, "santai@mail.com");
            Assert.AreEqual(data.DataValue.Address, "Jalan malas");
            Assert.AreEqual(data.DataValue.NPWP, "55667788");
        }

        [TestMethod]
        public async Task DeleteCustomerWithParameterId6NotFound_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _customerController.Delete(6)
                as HttpJsonApiResult<string>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task CreateCustomerSuccess_ShouldReturnHttpStatusCode201AndCustomerModel()
        {
            HttpJsonApiResult<CustomerModel> data = await _customerController.Post(new CustomerRequest()
            {
                CustomerNo = "12345678",
                Name = "Pelanggan baru",
                Email = "baru@mail.com",
                Address = "Alamat Baru",
                NPWP = "1122334455"
            }) as HttpJsonApiResult<CustomerModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.Created);
            Assert.AreEqual(data.DataValue.CustomerNo, "12345678");
            Assert.AreEqual(data.DataValue.Name, "Pelanggan baru");
            Assert.AreEqual(data.DataValue.Email, "baru@mail.com");
            Assert.AreEqual(data.DataValue.Address, "Alamat Baru");
            Assert.AreEqual(data.DataValue.NPWP, "1122334455");
        }
    }
}
