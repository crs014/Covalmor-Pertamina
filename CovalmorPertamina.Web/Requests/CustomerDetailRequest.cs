using CovalmorPertamina.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovalmorPertamina.Web.Requests
{
    public class CustomerDetailRequest
    {
        private CaCustomerDetail _caCustomerDetail;

        public CustomerDetailRequest()
        {
            _caCustomerDetail = new CaCustomerDetail();
        }

        public int CreditApprovalId 
        {
            get
            {
                return _caCustomerDetail.CreditApprovalId;
            }
            set
            {
                _caCustomerDetail.CreditApprovalId = value;
            } 
        }

        [Required(ErrorMessage = "Kolom jenis industri tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom jenis industri")]
        public string JenisIndustri 
        {
            get
            {
                return _caCustomerDetail.JenisIndustri;
            }
            set
            {
                _caCustomerDetail.JenisIndustri = value;
            } 
        }

        [Required(ErrorMessage = "kolom keterlambatan tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom keterlambatan")]
        public string Keterlambatan 
        {
            get
            {
                return _caCustomerDetail.Keterlambatan;
            }
            set
            {
                _caCustomerDetail.Keterlambatan = value;
            } 
        }

        [Required(ErrorMessage = "Kolom restrukturisasi tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom restrukturisasi")]
        public string Restrukturisasi 
        {
            get
            {
                return _caCustomerDetail.Restrukturisasi;
            }
            set
            {
                _caCustomerDetail.Restrukturisasi = value;
            } 
        }

        [Required(ErrorMessage = "Kolom fasilitas kredit tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom fasilitas kredit")]
        public string FasilitasKredit 
        {
            get
            {
                return _caCustomerDetail.FasilitasKredit;
            }
            set
            {
                _caCustomerDetail.FasilitasKredit = value;
            } 
        }

        [Required(ErrorMessage = "Kolom lama kerja sama tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom lama kerja sama")]
        public string LamaKerjaSama 
        {
            get
            {
                return _caCustomerDetail.LamaKerjaSama;
            }
            set
            {
                _caCustomerDetail.LamaKerjaSama = value;
            } 
        }

        [Required(ErrorMessage = "Kolom vendor pemasuk tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom vendor pemasuk")]
        public string VendorPemasuk 
        {
            get
            {
                return _caCustomerDetail.VendorPemasuk;
            }
            set
            {
                _caCustomerDetail.VendorPemasuk = value;
            } 
        }

        [Required(ErrorMessage = "Kolom posisi tawar tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom posisi tawar")]
        public string PosisiTawar 
        {
            get
            {
                return _caCustomerDetail.PosisiTawar;
            }
            set
            {
                _caCustomerDetail.PosisiTawar = value;
            } 
        }

        [Required(ErrorMessage = "Kolom badan usaha tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom badan usaha")]
        public string BadanUsaha 
        {
            get
            {
                return _caCustomerDetail.BadanUsaha;
            }
            set 
            {
                _caCustomerDetail.BadanUsaha = value;
            } 
        }

        [Required(ErrorMessage = "Kolom affiliasi tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom affiliasi")]
        public string Affiliasi 
        {
            get
            {
                return _caCustomerDetail.Affiliasi;
            }
            set
            {
                _caCustomerDetail.Affiliasi = value;
            } 
        }

        [Required(ErrorMessage = "Kolom kondisi industri tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom kondisi industri")]
        public string KondisiIndustri 
        {
            get
            {
                return _caCustomerDetail.KondisiIndustri;
            }
            set
            {
                _caCustomerDetail.KondisiIndustri = value;
            } 
        }

        [Required(ErrorMessage = "Kolom opini audit tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom opini audit")]
        public string OpiniAudit 
        {
            get
            {
                return _caCustomerDetail.OpiniAudit;
            }
            set
            {
                _caCustomerDetail.OpiniAudit = value;
            } 
        }

        [Required(ErrorMessage = "Kolom audit kap tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom audit kap")]
        public string AuditKap 
        {
            get
            {
                return _caCustomerDetail.AuditKap;
            }
            set
            {
                _caCustomerDetail.AuditKap = value;
            } 
        }

        public CaCustomerDetail GetObject() => _caCustomerDetail;
    }
}