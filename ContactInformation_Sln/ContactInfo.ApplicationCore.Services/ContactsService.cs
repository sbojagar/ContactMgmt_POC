using ContactInfo.Infrastructure.Data.Interfaces;
using ContactInfo.Infrastructure.Data.Models;
using ContactInfo.Infrastructure.Data.Models.ViewModels;
using ContactInfo.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactInfo.ApplicationCore.Services
{
    
    public class ContactsService
    {
        private readonly IContactRepository _contactRepository;

        public ContactsService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public ContactsService():this(new ContactRepository()){
        }

        public IEnumerable<Contact> GetAllContacts()
        {
           return  _contactRepository.GetAll();
        }

        public Contact GetById(int? Id) {
            return GetAllContacts()
                    .FirstOrDefault(contact => contact.Id == Id);
        }

        public ContactDetails GetContactDetails(int Id)
        {
            return _contactRepository.GetDetailsById(Id);


        }

        public void CreateContact(Contact _contact)
        {
            _contactRepository.AddContact(_contact);
        }

        public void UpdateContact(Contact _contact)
        {
            _contactRepository.UpdateContact(_contact);
        }

        public void DeleteContact(int id)
        {
            _contactRepository.DeleteContact(id);
        }

    }
}
