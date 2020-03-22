using ContactInfo.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactInfo.Infrastructure.Data
{
    public interface IContactInfo
    {
        IEnumerable<Contact> GetAll();
        Contact GetById(int Id);
        void AddNewContact(Contact newContact);
        void UpdateContact(int Id,Contact newValues );
    }
}
