using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovalmorPertamina.Entity.Model
{
    public class Signature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(191)]
        public string Name1 { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(191)]
        public string Name2 { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(191)]
        public string Position1 { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(191)]
        public string Position2 { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(191)]
        public string DocumentType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
