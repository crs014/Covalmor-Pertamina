using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovalmorPertamina.Entity.Model
{
    public class StaticValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(45)]
        public string TypeName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength]
        public string TextValue { get; set; }

        public int ColumnScore { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
