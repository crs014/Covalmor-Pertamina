using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository
{
    public class CreditApprovalRepository : ICreditApprovalRepository
    {
        private IDBCovalmor _db;

        public ERepository repository => ERepository.CreditApproval;

        public CreditApprovalRepository(IDBCovalmor db)
        {
            _db = db;
        }

        public Task<CreditApproval> Create(CreditApproval data)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Add(data);
                _db.SaveChanges();
                return creditApproval;
            });
        }

        public Task<CreditApproval> Delete(int id)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
                if (creditApproval != null)
                {
                    _db.CreditApprovals.Remove(creditApproval);
                    _db.SaveChanges();
                }
                return creditApproval;
            });
        }

        public IQueryable<CreditApproval> GetAll()
        {
            return _db.CreditApprovals;
        }

        public Task<CreditApproval> GetOne(int id)
        {
            return Task.Run(() => _db.CreditApprovals.Find(id));
        }

        public Task<CreditApproval> Update(int id, CreditApproval data)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
                if (creditApproval != null)
                {
                    //creditApproval.TicketNumber = data.TicketNumber;
                    creditApproval.MailNumber = data.MailNumber;
                    creditApproval.CustomerId = data.CustomerId;
                    creditApproval.TempoStart = data.TempoStart;
                    creditApproval.TempoEnd = data.TempoEnd;
                    creditApproval.LongTempo = data.LongTempo;
                    creditApproval.Volume = data.Volume;
                    creditApproval.Units = data.Units;
                    creditApproval.PeriodeVolume = data.PeriodeVolume;
                    creditApproval.SubmissionPeriod = data.SubmissionPeriod;
                    creditApproval.TransactionValue = data.TransactionValue;
                    creditApproval.CreditLimit = data.CreditLimit;
                    creditApproval.Payment = data.Payment;
                    creditApproval.Guarantee = data.Guarantee;
                    creditApproval.TermsOfDelivery = data.TermsOfDelivery;
                    creditApproval.Currency = data.Currency;
                    creditApproval.TransactionValueEstimatedPeriod = creditApproval.TransactionValue;
                    _db.SaveChanges();
                }
                return creditApproval;
            });
        }

        public Task<CreditApproval> UpdateStatus(int id, EStatusCredit statusCredit, bool isApprove = false)
        {
            return Task.Run(() =>
            { 
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
               
                if(creditApproval != null)
                {
                    creditApproval.Status = statusCredit;
                    if (isApprove)
                    {
                        if (statusCredit == EStatusCredit.AR)
                        {
                            creditApproval.SubmitArDate = DateTime.Now;
                        }
                        else if (statusCredit == EStatusCredit.CashBank)
                        {
                            creditApproval.SubmitCbDate = DateTime.Now;
                        }
                        else if (statusCredit == EStatusCredit.FBS)
                        {
                            creditApproval.SubmitFbsDate = DateTime.Now;
                        }
                        else if (statusCredit == EStatusCredit.ManagementRisk)
                        {
                            creditApproval.SubmitMrDate = DateTime.Now;
                        }
                        else if (statusCredit == EStatusCredit.KomiteCredit)
                        {
                            creditApproval.SubmitKKDate = DateTime.Now;
                        }
                    }
                    _db.SaveChanges();
                }
                return creditApproval;
            });
        }

        public Task<CreditApproval> AddCashBank(int id, string bankGaransi, string bankKonfirmasi)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
                if (creditApproval != null)
                {
                    if (bankGaransi != null)
                    {
                        creditApproval.BankGuaranteeDoc = bankGaransi;
                    }
                    
                    if(bankKonfirmasi != null)
                    {
                        creditApproval.BankConfirmationDoc = bankKonfirmasi;
                    }
                    _db.SaveChanges();
                }
                return creditApproval;
            });
        }

        public Task AddBankGaransi(int id, string bankGaransi)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
                if (creditApproval != null)
                {
                    if (bankGaransi != null)
                    {
                        creditApproval.BankGuaranteeDoc = bankGaransi;
                    }
                    _db.SaveChanges();
                }
            });
        }

        public Task AddCreditScoring(int id, string creditScoring)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
                if (creditApproval != null)
                {
                    creditApproval.CreditScoringDoc = creditScoring;
                    _db.SaveChanges();
                }
            });
        }

        public Task<CreditApproval> AddCreditSign(int id, string creditSign)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
                if (creditApproval != null)
                {
                    creditApproval.CreditApprovalDoc = creditSign;
                    _db.SaveChanges();
                }
                return creditApproval;
            });
        }

        public Task AddIntroductionMemo(int id, string introductionMemo)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
                if (creditApproval != null)
                {
                    if (introductionMemo != null)
                    {
                        creditApproval.IntroductionToMemo = introductionMemo;
                    }
                    _db.SaveChanges();
                }
            });
        }

        public Task AddDocLka(int id, string docLka)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
                if (creditApproval != null)
                {
                    if (docLka != null)
                    {
                        creditApproval.DocLka = docLka;
                    }
                    _db.SaveChanges();
                }
            });
        }

        public Task AddDocCas(int id, string docCas)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
                if (creditApproval != null)
                {
                    if (docCas != null)
                    {
                        creditApproval.DocCas = docCas;
                    }
                    _db.SaveChanges();
                }
            });
        }

        public Task AddDocBg(int id, string docBg)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
                if (creditApproval != null)
                {
                    if (docBg != null)
                    {
                        creditApproval.DocBg = docBg;
                    }
                    _db.SaveChanges();
                }
            });
        }

        public Task AddDocPml(int id, string docPml)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
                if (creditApproval != null)
                {
                    if (docPml != null)
                    {
                        creditApproval.DocPml = docPml;
                    }
                    _db.SaveChanges();
                }
            });
        }

        public Task AddBankKonfirmasiDoc(int id, string bankKonfirmasi)
        {
            return Task.Run(() =>
            {
                CreditApproval creditApproval = _db.CreditApprovals.Find(id);
                if (creditApproval != null)
                {
                    if (bankKonfirmasi != null)
                    {
                        creditApproval.BankConfirmationDoc = bankKonfirmasi;
                    }
                    _db.SaveChanges();
                }
            });
        }
    }
}
