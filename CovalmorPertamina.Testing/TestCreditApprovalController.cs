using CovalmorPertamina.Common.Services;
using CovalmorPertamina.Common.Statics;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
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
    public class TestCreditApprovalController : TestBaseController
    {
        private CreditApprovalController _creditApprovalController;

        public TestCreditApprovalController()
        {
            _creditApprovalController = new CreditApprovalController(_entityFactory, new PdfService());
        }

        [TestMethod]
        public async Task ReadListCreditApprovalSuccess_ShouldReturnHttpStatusCode200AndCountValue6()
        {
            HttpJsonApiResult<IEnumerable<CreditApprovalModel>> data = await _creditApprovalController.Get()
                as HttpJsonApiResult<IEnumerable<CreditApprovalModel>>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(new List<CreditApprovalModel>(data.DataValue).Count, 6);
        }

        [TestMethod]
        public async Task ReadCreditApprovalWithParameterIdIs2_ShouldReturnHttpStatusCode200()
        {
            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Get(2)
                as HttpJsonApiResult<CreditApprovalModel>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task ReadCreditApprovalWithParameterIdIs7_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _creditApprovalController.Get(7)
               as HttpJsonApiResult<string>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task ApproveCreditApprovalRoleUser_ShouldReturnHttpStatusCode200AndStatusCreditAR()
        {
            _creditApprovalController.SetUserAuth(new UserModel(new User() {
                Id = 1,
                Name = "User",
                Email = "user@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.User
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Approve(1, 
                new ActionNoteRequest()) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Status, "AR");
        }

        [TestMethod]
        public async Task ApproveCreditApprovalRoleAR_ShouldReturnHttpStatusCode200AndStatusCreditCashBank()
        {
            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 2,
                Name = "AR",
                Email = "AR@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.AR
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Approve(2,
                new ActionNoteRequest()) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Status, "Cash Bank");
        }

        [TestMethod]
        public async Task ApproveCreditApprovalRoleCashBank_ShouldReturnHttpStatusCode200AndStatusCreditFBS()
        {
            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 4,
                Name = "Cash Bank",
                Email = "cashbank@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.CashBank
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Approve(3,
                new ActionNoteRequest()) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Status, "FBS");
        }

        [TestMethod]
        public async Task ApproveCreditApprovalRoleFBS_ShouldReturnHttpStatusCode200AndStatusCreditManagementRisk()
        {
            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 5,
                Name = "FBS",
                Email = "fbs@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.FBS
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Approve(4,
                new ActionNoteRequest()) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Status, "Management Risiko");
        }

        [TestMethod]
        public async Task ApproveCreditApprovalRoleManagementRisk_ShouldReturnHttpStatusCode200AndStatusCreditKomiteCredit()
        {
            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 6,
                Name = "Management Risiko",
                Email = "ManagementRisiko@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.ManagementRisk
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Approve(5,
              new ActionNoteRequest()) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Status, "Komite Kredit");
        }

        [TestMethod]
        public async Task ApproveCreditApprovalRoleKomiteCredit_ShouldReturnHttpStatusCode200AndStatusCreditCompleted()
        {
            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 7,
                Name = "Komite Credit",
                Email = "KomiteCredit@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.KomiteCredit
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Approve(6,
              new ActionNoteRequest()) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Status, "Completed");
        }

        [TestMethod]
        public async Task RejectCreditApprovalRoleKomiteKredit_ShouldReturnHttpStatusCode200AndStatusCreditManagementRisiko()
        {
            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 7,
                Name = "Komite Credit",
                Email = "KomiteCredit@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.KomiteCredit
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Reject(6,
              new ActionNoteRequest()) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Status, "Management Risiko");
        }

        [TestMethod]
        public async Task RejectCreditApprovalRoleManagementRisiko_ShouldReturnHttpStatusCode200AndStatusCreditFBS()
        {
            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 6,
                Name = "Management Risiko",
                Email = "ManagementRisiko@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.ManagementRisk
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Reject(5,
              new ActionNoteRequest()) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Status, "FBS");
        }

        [TestMethod]
        public async Task RejectCreditApprovalRoleFBS_ShouldReturnHttpStatusCode200AndStatusCreditCashBank()
        {
            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 5,
                Name = "FBS",
                Email = "fbs@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.FBS
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Reject(4,
              new ActionNoteRequest()) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Status, "Cash Bank");
        }

        [TestMethod]
        public async Task RejectCreditApprovalRoleCashBank_ShouldReturnHttpStatusCode200AndStatusCreditAR()
        {
            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 4,
                Name = "cash bank",
                Email = "cashbank@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.CashBank
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Reject(3,
              new ActionNoteRequest()) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Status, "AR");
        }

        [TestMethod]
        public async Task RejectCreditApprovalRoleAR_ShouldReturnHttpStatusCode200AndStatusCreditDraftUser()
        {
            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 4,
                Name = "AR",
                Email = "ar@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.AR
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Reject(2,
              new ActionNoteRequest()) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(data.DataValue.Status, "Draft User");
        }

        [TestMethod]
        public async Task DeleteCreditApprovalWithParameterIdIs1_ShouldReturnHttpStatusCode200()
        {
            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Delete(1)
                as HttpJsonApiResult<CreditApprovalModel>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task DeleteCreditApprovalWithParameterIdIs7_ShouldReturnHttpStatusCode404()
        {
            HttpJsonApiResult<string> data = await _creditApprovalController.Delete(7)
                as HttpJsonApiResult<string>;
            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task CreateCreditApprovalSuccess_ShouldReturnHttpStatusCode201()
        {

            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.Admin
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Post(
                new CreditApprovalRequest() 
                { 
                    Products = new int[2] { 1, 2 } 
                }) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task UpdateCreditApprovalSuccess_ShouldReturnHttpStatusCode200()
        {

            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.Admin
            }));

            HttpJsonApiResult<CreditApprovalModel> data = await _creditApprovalController.Update(1, new CreditApprovalRequest()
            {
                Products = new int[2] { 1, 2 }
            }) as HttpJsonApiResult<CreditApprovalModel>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task UpdateCreditApprovalFailed_ShouldReturnHttpStatusCode404()
        {

            _creditApprovalController.SetUserAuth(new UserModel(new User()
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@covalmor1.com",
                Jabatan = "Karyawan",
                Password = PasswordHash.GetHash("12345678"),
                Role = EUserRole.Admin
            }));

            HttpJsonApiResult<string> data = await _creditApprovalController.Update(7, new CreditApprovalRequest()
            {
                Products = new int[2] { 1, 2 }
            }) as HttpJsonApiResult<string>;

            Assert.AreEqual(data.StatusCode, HttpStatusCode.NotFound);
        }
    }
}
