using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CovalmorPertamina.Web.Models
{
    public class CreditApprovalModel
    {
        public CreditApprovalModel()
        {

        }

        public CreditApprovalModel(CreditApproval creditApproval)
        {
            if (creditApproval != null)
            {
                #region status 
                if (creditApproval.Status == EStatusCredit.DraftUser)
                {
                    Status = "Draft User";
                }
                else if (creditApproval.Status == EStatusCredit.AR)
                {
                    Status = "AR";
                }
                else if (creditApproval.Status == EStatusCredit.CashBank)
                {
                    Status = "Cash Bank";
                }
                else if (creditApproval.Status == EStatusCredit.FBS)
                {
                    Status = "FBS";
                }
                else if (creditApproval.Status == EStatusCredit.ManagementRisk)
                {
                    Status = "Management Risiko";
                }
                else if (creditApproval.Status == EStatusCredit.KomiteCredit)
                {
                    Status = "Komite Kredit";
                }
                else
                {
                    Status = "Completed";
                }
                #endregion
                Id = creditApproval.Id;
                TicketNumber = creditApproval.TicketNumber;
                MailNumber = creditApproval.MailNumber;
                TempoStart = creditApproval.TempoStart;
                TempoEnd = creditApproval.TempoEnd;
                LongTempo = creditApproval.LongTempo;
                Volume = creditApproval.Volume;
                Units = creditApproval.Units;
                PeriodeVolume = creditApproval.PeriodeVolume;
                SubmissionPeriod = creditApproval.SubmissionPeriod;
                TransactionValue = creditApproval.TransactionValue;
                CreditLimit = creditApproval.CreditLimit;
                Payment = creditApproval.Payment;
                Guarantee = creditApproval.Guarantee;
                IntroductionToMemo = creditApproval.IntroductionToMemo;
                DocLka = creditApproval.DocLka;
                DocCas = creditApproval.DocCas;
                DocBg = creditApproval.DocBg;
                DocPml = creditApproval.DocPml;
                BankGuaranteeDoc = creditApproval.BankGuaranteeDoc;
                BankConfirmationDoc = creditApproval.BankConfirmationDoc;
                FlagFine = creditApproval.FlagFine;
                TermsOfDelivery = creditApproval.TermsOfDelivery;
                FlagRead = creditApproval.FlagRead;
                Currency = creditApproval.Currency;
                TransactionValueEstimatedPeriod = creditApproval.TransactionValueEstimatedPeriod;
                SubmitArDate = creditApproval.SubmitArDate;
                SubmitCbDate = creditApproval.SubmitCbDate;
                SubmitFbsDate = creditApproval.SubmitFbsDate;
                SubmitMrDate = creditApproval.SubmitMrDate;
                SubmitKKDate = creditApproval.SubmitKKDate;
                if(creditApproval.User == null)
                {
                    creditApproval.User = new User();
                }
                Creator = new UserModel(creditApproval.User);
                if(creditApproval.Customer == null)
                {
                    creditApproval.Customer = new Customer();
                }
                Customer = new CustomerModel(creditApproval.Customer);
            }
        }

        public static IEnumerable<CreditApprovalModel> GetAll(IEnumerable<CreditApproval> creditApprovals)
        {
            return creditApprovals.Select(e => new CreditApprovalModel(e));
        }

        public int Id { get; set; }

        public string TicketNumber { get; set; }

        public string MailNumber { get; set; }

        public DateTime TempoStart { get; set; }

        public DateTime TempoEnd { get; set; }

        public string LongTempo { get; set; }

        public string Volume { get; set; }

        public string Units { get; set; }

        public string PeriodeVolume { get; set; }

        public string SubmissionPeriod { get; set; }

        public string TransactionValue { get; set; }

        public string CreditLimit { get; set; }

        public string Payment { get; set; }

        public string Guarantee { get; set; }

        public string IntroductionToMemo { get; set; }

        public string DocLka { get; set; }

        public string DocCas { get; set; }

        public string DocBg { get; set; }

        public string DocPml { get; set; }

        public string BankGuaranteeDoc { get; set; }

        public string BankConfirmationDoc { get; set; }

        public bool FlagFine { get; set; }

        public string TermsOfDelivery { get; set; }

        public string Status { get; set; }

        public bool FlagRead { get; set; }

        public string Currency { get; set; }

        public string TransactionValueEstimatedPeriod { get; set; }

        public DateTime? SubmitArDate { get; set; }

        public DateTime? SubmitCbDate { get; set; }

        public DateTime? SubmitFbsDate { get; set; }

        public DateTime? SubmitMrDate { get; set; }

        public DateTime? SubmitKKDate { get; set; }


        public UserModel Creator { get; set; }

        public CustomerModel Customer { get; set; }
    }
}