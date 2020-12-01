using System;
using System.Collections.Generic;
using System.Text;

namespace IncredibleContacts.Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } // Marina
    }
}
