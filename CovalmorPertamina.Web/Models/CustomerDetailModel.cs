using CovalmorPertamina.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovalmorPertamina.Web.Models
{
    public class CustomerDetailModel
    {

        private CaCustomerDetail _customerDetail;

        public CustomerDetailModel()
        {
            _customerDetail = new CaCustomerDetail();
        }

        public CustomerDetailModel(CaCustomerDetail customerDetail)
        {
            _customerDetail = customerDetail;
        }

        public static IEnumerable<CustomerDetailModel> GetAll(IEnumerable<CaCustomerDetail> customerDetails)
        {
            return customerDetails.Select(e => new CustomerDetailModel(e));
        }

        public int Id => _customerDetail.Id;

        public int CreditApprovalId => _customerDetail.CreditApprovalId;

        public string CreatedBy => _customerDetail.CreatedBy;

        public string JenisIndustri => _customerDetail.JenisIndustri;

        public string Keterlambatan => _customerDetail.Keterlambatan;

        public string Restrukturisasi => _customerDetail.Restrukturisasi;

        public string FasilitasKredit => _customerDetail.FasilitasKredit;

        public string LamaKerjaSama => _customerDetail.LamaKerjaSama;

        public string VendorPemasuk => _customerDetail.VendorPemasuk;

        public string PosisiTawar => _customerDetail.PosisiTawar;

        public string BadanUsaha => _customerDetail.BadanUsaha;

        public string Affiliasi => _customerDetail.Affiliasi;

        public string KondisiIndustri => _customerDetail.KondisiIndustri;

        public string OpiniAudit => _customerDetail.OpiniAudit;

        public string AuditKap => _customerDetail.AuditKap;

        public DateTime CreatedAt => _customerDetail.CreatedAt;

        public DateTime UpdatedAt => _customerDetail.UpdatedAt;
    }
}