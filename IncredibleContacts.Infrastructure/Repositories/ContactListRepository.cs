using IncredibleContacts.Domain.Entities;
using IncredibleContacts.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using IncredibleContacts.Domain;
using System.Linq;

namespace IncredibleContacts.Infrastructure.Repositories
{
    public class ContactListRepository : IContactRepository
    {
        //Representa o BANCO DE DADOS, mas é uma Lista.
        private static List<Contact> Contacts = new List<Contact>();

        public void Create(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void Delete(Guid id)
        {
            var listContact = Contacts.Find(c => c.Id == id);
            Contacts.Remove(listContact);
        }

        public IEnumerable<Contact> ReadAll()
        {
            return Contacts;
        }

        public void Update(Contact contact)
        {
            //Encontro o contato que será atualizado usando o ID
            var listContact = Contacts.Find(c => c.Id == contact.Id);
            //listContact = Contacts.Where(c => c.Id == contact.Id).First();

            //Atualizo o contato que está na lista
            listContact.Name = contact.Name;
            listContact.PhoneNumber = contact.PhoneNumber;
            listContact.Email = contact.Email;
           
        }
    }
}
