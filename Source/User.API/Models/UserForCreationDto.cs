using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Models
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "You should provide a FirstName value.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You should provide a LastName value.")]
        [MaxLength(70)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You should provide an Email value.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You should provide a Birthdate value.")]
        [DataType(DataType.Date,ErrorMessage = "The BirthDate field is not a valid")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "You should provide a Address value.")]        
        public AddressForCreationDto Address { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}

