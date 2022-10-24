using System;
using System.ComponentModel.DataAnnotations;

namespace PhonebookProject.Domain
{
    public class Contact
    {
        public Guid ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
    }
}

 