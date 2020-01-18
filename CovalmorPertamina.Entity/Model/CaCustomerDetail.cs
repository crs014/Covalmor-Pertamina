using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovalmorPertamina.Entity.Model
{
    public class CaCustomerDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        public int CreditApprovalId { get; set; }

        public string CreatedBy { get; set; }

        [Required]
        [MaxLength]
        [Column(TypeName = "varchar")]
        public string JenisIndustri { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string Keterlambatan { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string Restrukturisasi { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string FasilitasKredit { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string LamaKerjaSama { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string VendorPemasuk { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string PosisiTawar { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string BadanUsaha { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string Affiliasi { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string KondisiIndustri { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string OpiniAudit { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string AuditKap { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int ScoreRiwayatPembayaran { get; set; }

        public int ScoreRiwayatRestrukturisasi { get; set; }

        public int ScoreFasilitasKreditBank { get; set; }

        public int ScoreLamaBekerjaSama { get; set; }

        public int ScoreVendorPemasok { get; set; }

        public int ScorePosisiTawarPertaminaCustomer { get; set; }

        public int ScoreBadanHukumUsaha { get; set; }

        public int ScoreNetworkingAP { get; set; }

        public int ScoreKondisiIndustriCustomer { get; set; }

        public int ScoreOpiniAudit { get; set; }

        public int ScoreAuditorTerdaftarOJK { get; set; }


        [ForeignKey("CreditApprovalId")]
        public virtual CreditApproval CreditApprovals { get; set; }
    }
}
