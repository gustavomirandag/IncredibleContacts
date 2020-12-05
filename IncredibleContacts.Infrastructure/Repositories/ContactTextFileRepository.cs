using IncredibleContacts.Domain.Entities;
using IncredibleContacts.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IncredibleContacts.Infrastructure.Repositories
{
    public class ContactTextFileRepository : IContactRepository
    {
        public void Create(Contact contact)
        {
            var file = new StreamWriter(@"D:\Dados\contacts.csv",true);
            file.WriteLine(contact.Id + ";" + contact.Name + ";" + contact.PhoneNumber + ";" + contact.Email);
            file.Close();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> ReadAll()
        {
            var contacts = new List<Contact>();

            var file = new StreamReader(@"D:\Dados\contacts.csv");
            var line = file.ReadLine();

            while(line != null && line != "")
            {
                var contactFields = line.Split(';');
                var contact = new Contact();

                contact.Id = Guid.Parse(contactFields[0]);
                contact.Name = contactFields[1];
                contact.PhoneNumber = contactFields[2];
                contact.Email = contactFields[3];

                contacts.Add(contact);

                line = file.ReadLine();
            }
            file.Close();

            return contacts;
        }

        public void Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
