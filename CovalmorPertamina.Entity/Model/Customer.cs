using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovalmorPertamina.Entity.Model
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string CustomerNo { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }

        [Required]
        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string NPWP { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        //public ICollection<CreditApproval> CreditApprovals { get; set; }
    }
}
