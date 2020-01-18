using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovalmorPertamina.Entity.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(191)]
        public string MaterialNo { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(191)]
        public string MaterialName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(191)]
        public string MaterialGroup { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<TrCaProduct> TrCaProducts { get; set; }
    }
}
