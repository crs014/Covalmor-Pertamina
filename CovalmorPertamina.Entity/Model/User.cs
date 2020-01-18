using CovalmorPertamina.Entity.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovalmorPertamina.Entity.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(191)]
        [Required]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        [Column(TypeName = "varchar")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [MaxLength(191)]
        [Column(TypeName = "varchar")]
        public string Jabatan { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public EUserRole Role { get; set; }

        public DateTime? EmailVerifiedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DeletedAt { get; set; }
    }
}
