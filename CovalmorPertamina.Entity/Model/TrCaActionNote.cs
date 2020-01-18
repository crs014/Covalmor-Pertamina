using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;

namespace CovalmorPertamina.Entity.Model
{
    public class TrCaActionNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CreditApprovalId { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(191)]
        public string ActionNote { get; set; }

        [Required]
        [Range(0, 4)]
        [Column(TypeName = "tinyint")]
        public byte ActionType { get; set; }

        public int ActionBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DeletedAt { get; set; }

        [ForeignKey("CreditApprovalId")]
        [ScriptIgnore]
        public CreditApproval CreditApproval { get; set; }
    
        [ForeignKey("ActionBy")]
        public virtual User User { get; set; }
    }
}
