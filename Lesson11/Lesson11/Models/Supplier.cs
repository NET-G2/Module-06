using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson11.Models
{
    [Table(nameof(Supplier))]
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Supplier's name is required.")]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please, provide valid phone number.")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Company { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
