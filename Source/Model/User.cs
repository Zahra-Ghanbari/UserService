using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class User
    {

        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
    }
}
