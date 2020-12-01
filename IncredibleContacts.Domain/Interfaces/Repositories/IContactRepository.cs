using IncredibleContacts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncredibleContacts.Domain.Interfaces.Repositories
{
    public interface IContactRepository
    {
        //REPOSITÓRIO é apenas para trabalhar com PERSISTÊNCIA
        //Ou seja: CRUD - CREATE, READ, UPDATE and DELETE

        void Create(Contact contact);
        IEnumerable<Contact> ReadAll();
        void Update(Contact contact);
        void Delete(Guid id);
    }
}
