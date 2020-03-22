using ContactInfo.Infrastructure.Data;
using ContactInfo.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactInfo.ApplicationCore.Services
{
    public class ContactService : IContactInfo
    {
        private ContactContext _context;
        public ContactService(ContactContext context)
        {
            _context = context;
        }
        public void AddNewContact(Contact newContact)
        {
            _context.Add(newContact);
            _context.SaveChanges();
        }

        public IEnumerable<Contact> GetAll()
        {
            return _context.Contacts;
                //.Include(asset => asset.FirstName)
                //.Include(asset => asset.Mobile);
        }

        public Contact GetById(int Id)
        {
            return _context.Contacts
                .Include(asset => asset.FirstName)
                .Include(asset => asset.Mobile).FirstOrDefault(asset => asset.Id == Id);
        }

        public void UpdateContact(int Id, Contact newValues)
        {
            throw new NotImplementedException();
        }
    }
}
