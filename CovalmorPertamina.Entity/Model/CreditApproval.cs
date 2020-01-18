using CovalmorPertamina.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovalmorPertamina.Entity.Model
{
    public class CreditApproval
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(45)]
        [Column(TypeName = "varchar")]
        public string TicketNumber { get; set; }

        [Required]
        [MaxLength(45)]
        [Column(TypeName = "varchar")]
        public string MailNumber { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime TempoStart { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime TempoEnd { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string LongTempo { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string Volume { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string Units { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string PeriodeVolume { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string SubmissionPeriod { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string TransactionValue { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string CreditLimit { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string Payment { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string Guarantee { get; set; }

        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string IntroductionToMemo { get; set; }

        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string DocLka { get; set; }

        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string DocCas { get; set; }

        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string DocBg { get; set; }

        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string DocPml { get; set; }

        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string BankGuaranteeDoc { get; set; }

        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string BankConfirmationDoc { get; set; }

        [MaxLength(191, ErrorMessage = "Max length Credit Scoring Doc is 191 characters")]
        [Column(TypeName = "varchar")]
        public string CreditScoringDoc { get; set; }

        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string CreditApprovalDoc { get; set; }

        public bool FlagFine { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string TermsOfDelivery { get; set; }

        public EStatusCredit Status { get; set; }

        public bool FlagRead { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? SubmitArDate { get; set; }

        public DateTime? SubmitCbDate { get; set; }

        public DateTime? SubmitFbsDate { get; set; }
        
        public DateTime? SubmitMrDate { get; set; }

        public DateTime? SubmitKKDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        public string Currency { get; set; }

        public string TransactionValueEstimatedPeriod { get; set; }

        public virtual ICollection<TrCaActionNote> TrCaActionNote { get; set; }

        public virtual ICollection<TrCaProduct> TrCaProducts { get; set; }

        public virtual ICollection<TrCaNote> TrCaNotes { get; set; }

        public virtual ICollection<CaCustomerDetail> CaCustomerDetails { get; set; }

        public virtual ICollection<QuantitativeAspect> QuantitativeAspects { get; set; }

        public virtual ICollection<CreditScoring> CreditScorings { get; set; }
        
        [ForeignKey("CreatedBy")]
        public virtual User User { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
