using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Address
    {
        [Required]
        [MaxLength(50)]
        public string State { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
    }
}