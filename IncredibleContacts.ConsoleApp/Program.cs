using IncredibleContacts.Domain.Entities;
using IncredibleContacts.Domain.Services;
using IncredibleContacts.Infrastructure.Repositories;
using System;

namespace IncredibleContacts.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ContactService(new ContactListRepository());
            int option = 0;

            do
            {
                Console.WriteLine("1 - Registrar Contato");
                Console.WriteLine("2 - Editar Contato");
                Console.WriteLine("3 - Imprimir Contatos");
                Console.WriteLine("4 - Remover Contato");
                Console.WriteLine("5 - Buscar Contato");
                Console.WriteLine("6 - Sair");
                option = int.Parse(Console.ReadLine());
                Console.Clear();
                Contact contact;

                switch (option)
                {
                    case 1:
                        contact = new Contact();
                        Console.WriteLine("Digite o nome do contato");
                        contact.Name = Console.ReadLine();
                        Console.WriteLine("Digite o número de telefone");
                        contact.PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Digite o email do contato");
                        contact.Email = Console.ReadLine();
                        service.RegisterContact(contact);
                        break;

                    case 2:
                        contact = new Contact();
                        Console.WriteLine("Digite o Id do contato que deseja editar");
                        contact.Id = Guid.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o novo nome");
                        contact.Name = Console.ReadLine();
                        Console.WriteLine("Digite o novo telefone");
                        contact.PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Digite o novo email");
                        contact.Email = Console.ReadLine();
                        service.EditContact(contact);
                        break;

                    case 3:
                        var contacts = service.GetAllContacts();
                        foreach(var curContact in contacts)
                        {
                            Console.WriteLine("Id: " + curContact.Id);
                            Console.WriteLine("Name: " + curContact.Name);
                            Console.WriteLine("Phone: " + curContact.PhoneNumber);
                            Console.WriteLine("Email: " + curContact.Email);
                            Console.WriteLine();
                        }
                        break;

                    case 4:
                        Console.WriteLine("Digite o Id do contato que deseja remover:");
                        var id = Guid.Parse(Console.ReadLine());
                        service.DeleteContact(id);
                        break;

                    case 5:
                        Console.WriteLine("Digite o nome do contato que está procurando:");
                        var name = Console.ReadLine();
                        var searchResult = service.SearchByName(name);
                        foreach (var curContact in searchResult)
                        {
                            Console.WriteLine("Id: " + curContact.Id);
                            Console.WriteLine("Name: " + curContact.Name);
                            Console.WriteLine("Phone: " + curContact.PhoneNumber);
                            Console.WriteLine("Email: " + curContact.Email);
                            Console.WriteLine();
                        }
                        break;

                }

                Console.WriteLine();
                Console.WriteLine("Digite ENTER para continuar...");
                Console.ReadKey();
                Console.Clear();

            } while (option != 6);
        }
    }
}
