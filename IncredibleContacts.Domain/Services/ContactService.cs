using IncredibleContacts.Domain.Entities;
using IncredibleContacts.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IncredibleContacts.Domain.Services
{
    //FUNCTIONAL REQUIREMENTS / FEATURES: USE CASES
    public class ContactService
    {
        private readonly IContactRepository _repository;

        //Constructor
        public ContactService(IContactRepository repository)
        {
            this._repository = repository;
        }

        public void RegisterContact(Contact contact)
        {
            //Validação
            if (contact.Name.Length < 3)
                return; //Retorno e não cadastro nada

            contact.Id = Guid.NewGuid();
            _repository.Create(contact);
        }
        
        public void EditContact(Contact contact)
        {
            _repository.Update(contact);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _repository.ReadAll();
        }

        public Contact GetContactById(Guid id)
        {
            return GetAllContacts().FirstOrDefault(c => c.Id == id);
        }
        
        public void DeleteContact(Guid id)
        {
            _repository.Delete(id);
        }
 
        public IEnumerable<Contact> SearchByName(string name)
        {
            return _repository.ReadAll().Where(
                    contact => contact.Name
                        .ToLower()
                        .Contains(name.ToLower())
                );
        }
    }
}
