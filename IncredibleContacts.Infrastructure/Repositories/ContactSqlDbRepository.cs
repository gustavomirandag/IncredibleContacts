using IncredibleContacts.Domain.Entities;
using IncredibleContacts.Domain.Interfaces.Repositories;
using IncredibleContacts.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IncredibleContacts.Infrastructure.Repositories
{
    public class ContactSqlDbRepository : IContactRepository
    {
        private readonly ContactsDbContext _context;

        public ContactSqlDbRepository(ContactsDbContext context)
        {
            _context = context;
        }

        public void Create(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var contact = _context.Contacts.Find(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public IEnumerable<Contact> ReadAll()
        {
            return _context.Contacts;
        }

        public void Update(Contact contact)
        {
            _context.Update(contact);
            _context.SaveChanges();
        }
    }
}
