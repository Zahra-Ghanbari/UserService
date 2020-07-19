using System;
using System.ComponentModel.DataAnnotations;


namespace Entity
{
    public class User
    {
        public User()
        {
            Id = new Guid();
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
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"/^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/")]
        public string Birthdate { get; set; }

        [Required]
        [MaxLength(100)]
        public Address Address { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

    }
}
