using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Models
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "You should provide a FirstName value.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You should provide a LastName value.")]
        [MaxLength(70)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You should provide a Email value.")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You should provide a Birthdate value.")]
        [RegularExpression(@"/^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/")]
        public string Birthdate { get; set; }

        [Required(ErrorMessage = "You should provide a Address value.")]
        [MaxLength(100)]
        public AddressForCreationDto Address { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}

