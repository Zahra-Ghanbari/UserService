using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Models
{
    public class AddressForCreationDto
    {
        [Required(ErrorMessage = "You should provide a State value.")]
        [MaxLength(50)]
        public string State { get; set; }
        [Required(ErrorMessage = "You should provide a City value.")]
        [MaxLength(50)]
        public string City { get; set; }
    }
}
