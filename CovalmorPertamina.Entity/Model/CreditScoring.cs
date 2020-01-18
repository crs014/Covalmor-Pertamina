using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovalmorPertamina.Entity.Model
{
    public class CreditScoring
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int CreditApporvalId { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string CustomerName { get; set; }

        public string CustomerSap { get; set; }

        public string TypeIndustry { get; set; }

        public string Score { get; set; }

        [ForeignKey("CreditApporvalId")]
        public CreditApproval CreditApproval { get; set; }

    }
}
