using System;
using System.ComponentModel.DataAnnotations;


namespace Entity
{
    public class User
    {
        public User()
        {
            Id = System.Guid.NewGuid();
        }

        [Key]
        [Required]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
            (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(70)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You should provide a Birthdate value.")]
        [DataType(DataType.Date, ErrorMessage = "The BirthDate field is not a valid")]
        public DateTime BirthDate { get; set; }

        [Required]  
        public Address Address { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

    }
}
