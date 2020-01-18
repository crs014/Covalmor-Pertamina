using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovalmorPertamina.Entity.Model
{
    public class TrCaNote
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CreditApprovalId { get; set; }

        [Required]
        public DateTime TanggalNota { get; set; }

        [Required]
        [MaxLength(45)]
        [Column(TypeName = "varchar")]
        public string Perihal { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Isi { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DeletedAt { get; set; }

        [ForeignKey("CreditApprovalId")]
        public CreditApproval CreditApproval { get; set; }
    }
}
