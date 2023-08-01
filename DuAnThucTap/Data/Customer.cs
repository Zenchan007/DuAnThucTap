using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DuAnThucTap.Data
{
    [Table("Tbl_Customer")]
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name_Customer { get; set; } = null!;
        [Required]
        [Range(0, 100)]
        public int Age_Customer { get; set; }
        [Required]
        [MaxLength(500)]
        public string Address_Customer { get; set; } = null!;
        [AllowNull]
        [MaxLength(500)]
        public string Description_Customer { get; set; }
    }
}
