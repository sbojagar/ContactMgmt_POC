using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactInfo.ApplicationCore.Services;
using ContactInfo.Infrastructure.Data;
using ContactInfo.Infrastructure.Data.Models;
using ContactInfo.Infrastructure.Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ContactInfo.Web.Controllers
{
    public class ContactsController : Controller
    {
        //private IContactInfo _contacts;
        private ContactsService _service;
        //public ContactsController(IContactInfo contact)
        //{
        //    _contacts = contact;
        //}
        public IActionResult Index()
        {
            _service = new ContactsService();
            var contactModels = _service.GetAllContacts();
            var listingResult = contactModels
                .Select(result => new ContactsListingModel
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Mobile = result.Mobile,
                    Email = result.Email,
                    ImageURL = result.ImageURL
                });
            var model = new ContactsIndexModel()
            {
                Contacts = listingResult
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            _service = new ContactsService();
            //var model = _service.GetContactDetails(id);
            //return View(model);
            //if (id == null)
            //{
            //    return NotFound();
            //}
            ContactDetails contact = _service.GetContactDetails(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Contact _contact)
        {
            _service = new ContactsService();
            if (ModelState.IsValid)
            {
                _service.CreateContact(_contact);
                return RedirectToAction("Index");
            }
            return View(_contact);
        }

        
        public IActionResult Edit(int? id)
        {
            _service = new ContactsService();
            if (id == null)
            {
                return NotFound();
            }

            Contact editContact = _service.GetById(id);
            if (editContact == null) {
                return NotFound();
            }
            return View(editContact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind] Contact _contact)
        {
            _service = new ContactsService();
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid) 
            {
                _service.UpdateContact(_contact);
                return RedirectToAction("Index");
            }
            
            return View(_service);
        }

        public IActionResult Delete(int? id) {
            if (id == null)
            {
                return NotFound();
            }
            _service = new ContactsService();
            Contact editContact = _service.GetById(id);
            if (editContact == null)
            {
                return NotFound();
            }
            return View(editContact);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteContact(int id)
        {
            _service = new ContactsService();            
            _service.DeleteContact(id);

            return RedirectToAction("Index");
        }

    }
}