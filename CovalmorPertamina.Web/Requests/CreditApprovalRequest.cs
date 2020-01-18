using CovalmorPertamina.Common.Statics;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace CovalmorPertamina.Web.Requests
{
    public class CreditApprovalRequest
    {
        private CreditApproval _creditApproval;

        public CreditApprovalRequest()
        {
            _creditApproval = new CreditApproval();
        }

        [Required(ErrorMessage = "Kolom kustomer tidak boleh kosong")]
        public int Customer
        {
            get
            {
                return _creditApproval.CustomerId;
            }
            set
            {
                _creditApproval.CustomerId = value;
            }
        }

        [Required(ErrorMessage = "Kolom nomor surat tidak boleh kosong")]
        [MaxLength(45, ErrorMessage = "Maksimal karakter 191 pada kolom nomor surat")]
        public string MailNumber 
        {
            get
            {
                return _creditApproval.MailNumber;
            }
            set
            {
                _creditApproval.MailNumber = value;
            } 
        }

        [Required(ErrorMessage = "Kolom volume tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom volume")]
        public string Volume
        {
            get
            {
                return _creditApproval.Volume;
            }
            set
            {
                _creditApproval.Volume = value;
            }
        }

   
        [Required(ErrorMessage = "Kolom satuan tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom satuan")]
        public string Units
        {
            get
            {
                return _creditApproval.Units;
            }
            set
            {
                _creditApproval.Units = value;
            } 
        }

        [Required(ErrorMessage = "Kolom periode volume tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom periode volume")]
        public string PeriodeVolume 
        {
            get
            {
                return _creditApproval.PeriodeVolume;
            }
            set
            {
                _creditApproval.PeriodeVolume = value;
            }
        }

        [Required(ErrorMessage = "Kolom lama tempo tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom lama tempo")]
        public string LongTempo 
        {
            get
            {
                return _creditApproval.LongTempo;
            }
            set
            {
                _creditApproval.LongTempo = value;
            } 
        }

        [Required(ErrorMessage = "Kolom periode penyerahan tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom periode penyerahan")]
        public string SubmissionPeriod
        {
            get
            {
                return _creditApproval.SubmissionPeriod;
            }
            set
            {
                _creditApproval.SubmissionPeriod = value;
            } 
        }

        public string OtherLongTempo { get; set; }

        [Required(ErrorMessage = "Kolom nilai transaksi tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom nilai transaksi")]
        public string TransactionValue 
        {
            get
            {
                return _creditApproval.TransactionValue;
            }
            set
            {
                _creditApproval.TransactionValue = value;
            } 
        }

        [Required(ErrorMessage = "Kolom kredit limit tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom kredit limit")]
        public string CreditLimit 
        {
            get
            {
                return _creditApproval.CreditLimit;
            }
            set
            {
                _creditApproval.CreditLimit = value;
            } 
        }

        [Required(ErrorMessage = "Kolom pembayaran tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom pembayaran")]
        public string Payment 
        {
            get 
            {
                return _creditApproval.Payment;
            }
            set
            {
                _creditApproval.Payment = value;
            } 
        }

        public string OtherPayment { get; set; } = "";

        public bool FlagFine 
        {
            get
            {
                return _creditApproval.FlagFine;
            }
            set
            {
                _creditApproval.FlagFine = value;
            } 
        }

        [Required(ErrorMessage = "Kolom bentuk jaminan tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom bentuk jaminan")]
        public string Guarantee 
        {
            get
            {
                return _creditApproval.Guarantee;
            }
            set
            {
                _creditApproval.Guarantee = value;
            } 
        }

        public string OtherGuarantee { get; set; } = "";

        [Required(ErrorMessage = "Kolom syarat penyerahan tidak boleh kosong")]
        [MaxLength(191, ErrorMessage = "Maksimal karakter 191 pada kolom syarat penyerahan")]
        public string TermsOfDelivery 
        {
            get
            {
                return _creditApproval.TermsOfDelivery;
            }
            set
            {
                _creditApproval.TermsOfDelivery = value;
            }
        }

        public string OtherTermsOfDelivery { get; set; } = "";

        public string Currency 
        {

            get
            {
                return _creditApproval.Currency;
            }
            set
            {
                _creditApproval.Currency = value;
            } 
        }

        //MasaPerkiraanNilaiTransaksi
        public string TransactionValueEstimatedPeriod 
        {
            get
            {
                return _creditApproval.TransactionValueEstimatedPeriod;
            }
            set
            {
                _creditApproval.TransactionValueEstimatedPeriod = value;
            }
        }
        
        [Required(ErrorMessage = "Kolom awal tempo tidak boleh kosong")]
        public DateTime TempoStart 
        {
            get
            {
                return _creditApproval.TempoStart;
            }
            set
            {
                _creditApproval.TempoStart = value;
            }
        }

        [Required(ErrorMessage = "Kolom akhir tempo tidak boleh kosong")]
        public DateTime TempoEnd 
        {
            get
            {
                return _creditApproval.TempoEnd;
            }
            set
            {
                _creditApproval.TempoEnd = value;
            } 
        }

        [Required(ErrorMessage = "kolom produk tidak boleh kosong")]
        public int[] Products { get; set; }

        public CreditApproval GetObject()
        {
            #region others
            if (LongTempo == ConstantValue.JatuhTempo.Other)
            {
                _creditApproval.LongTempo = OtherLongTempo;
            }

            if(Payment == ConstantValue.Bank.Other)
            {
                _creditApproval.Payment = OtherPayment;
            }

            if(Guarantee == ConstantValue.BentukJaminan.Other)
            {
                _creditApproval.Guarantee = OtherGuarantee;
            }

            if(TermsOfDelivery == ConstantValue.SyaratPenyerahan.Other)
            {
                _creditApproval.TermsOfDelivery = OtherTermsOfDelivery;
            }
            #endregion
            _creditApproval.Status = EStatusCredit.DraftUser;
            return _creditApproval;
        }
    }
}