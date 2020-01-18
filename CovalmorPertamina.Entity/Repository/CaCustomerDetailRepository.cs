using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository
{
    public class CaCustomerDetailRepository : ICaCustomerDetailRepository
    {
        private IDBCovalmor _db;


        public CaCustomerDetailRepository(IDBCovalmor db)
        {
            _db = db;
        }

        public ERepository repository => ERepository.CaCustomerDetail;

        public Task<CaCustomerDetail> Create(CaCustomerDetail data)
        {
            return Task.Run(() =>
            {
                CaCustomerDetail customerDetail = _db.CaCustomerDetails.Add(data);
                _db.SaveChanges();
                return customerDetail;
            });
        }

        public Task<CaCustomerDetail> Delete(int id)
        {
            return Task.Run(() =>
            {
                CaCustomerDetail customerDetail = _db.CaCustomerDetails.Find(id);
                if(customerDetail != null)
                {
                    _db.CaCustomerDetails.Remove(customerDetail);
                    _db.SaveChanges();
                }
                return customerDetail;
            });
        }

        public IEnumerable<CaCustomerDetail> GetAll()
        {
            return _db.CaCustomerDetails;
        }

        public Task<CaCustomerDetail> GetOne(int id)
        {
            return Task.Run(() => _db.CaCustomerDetails.Find(id));
        }

        public Task<CaCustomerDetail> Update(int id, CaCustomerDetail data)
        {
            return Task.Run(() =>
            {
                CaCustomerDetail customerDetail = _db.CaCustomerDetails.Find(id);
                if(customerDetail != null)
                {
                    customerDetail.JenisIndustri = data.JenisIndustri;
                    customerDetail.Keterlambatan = data.Keterlambatan;
                    customerDetail.Restrukturisasi = data.Restrukturisasi;
                    customerDetail.FasilitasKredit = data.FasilitasKredit;
                    customerDetail.LamaKerjaSama = data.LamaKerjaSama;
                    customerDetail.VendorPemasuk = data.VendorPemasuk;
                    customerDetail.PosisiTawar = data.PosisiTawar;
                    customerDetail.BadanUsaha = data.BadanUsaha;
                    customerDetail.Affiliasi = data.Affiliasi;
                    customerDetail.KondisiIndustri = data.KondisiIndustri;
                    customerDetail.OpiniAudit = data.OpiniAudit;
                    customerDetail.AuditKap = data.AuditKap;
                    customerDetail.UpdatedAt = DateTime.UtcNow;
                    customerDetail.ScoreRiwayatPembayaran = data.ScoreRiwayatPembayaran;
                    customerDetail.ScoreRiwayatRestrukturisasi = data.ScoreRiwayatRestrukturisasi;
                    customerDetail.ScoreFasilitasKreditBank = data.ScoreFasilitasKreditBank;
                    customerDetail.ScoreLamaBekerjaSama = data.ScoreLamaBekerjaSama;
                    customerDetail.ScoreVendorPemasok = data.ScoreVendorPemasok;
                    customerDetail.ScorePosisiTawarPertaminaCustomer = data.ScorePosisiTawarPertaminaCustomer;
                    customerDetail.ScoreBadanHukumUsaha = data.ScoreBadanHukumUsaha;
                    customerDetail.ScoreNetworkingAP = data.ScoreNetworkingAP;
                    customerDetail.ScoreKondisiIndustriCustomer = data.ScoreKondisiIndustriCustomer;
                    customerDetail.ScoreOpiniAudit = data.ScoreOpiniAudit;
                    customerDetail.ScoreAuditorTerdaftarOJK = data.ScoreAuditorTerdaftarOJK;
                    _db.SaveChanges();
                }
                return customerDetail;
            });
        }
    }
}
