using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IncredibleContacts.Domain.Entities;
using IncredibleContacts.Infrastructure.Contexts;
using IncredibleContacts.Domain.Services;

namespace IncredibleContacts.WebApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService _service;

        public ContactsController(ContactService service)
        {
            _service = service;
        }

        // GET: Contacts
        public IActionResult Index()
        {
            return View(_service.GetAllContacts());
        }

        // GET: Contacts/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var contact = _service.GetContactById(id.Value);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,PhoneNumber,Email")] Contact contact)
        {
            _service.RegisterContact(contact);

            return RedirectToAction(nameof(Index));
        }

        // GET: Contacts/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var contact = _service.GetContactById(id.Value);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name,PhoneNumber,Email")] Contact contact)
        {
            if (id != contact.Id)
                return NotFound();

            _service.EditContact(contact);

            return RedirectToAction(nameof(Index));
        }

        // GET: Contacts/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var contact = _service.GetContactById(id.Value);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _service.DeleteContact(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
