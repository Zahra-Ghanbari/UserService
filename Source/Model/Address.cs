using System.ComponentModel.DataAnnotations;

namespace Model
{
    [System.ComponentModel.DataAnnotations.Schema.ComplexType]
    public class Address
    {
        [Required()]
        [MaxLength(100)]
        public string Country { get; set; }
        [Required]
        [MaxLength(50)]
        public string State { get; set; }
        
        [MaxLength(50)]
        public string City { get; set; }
    }
}