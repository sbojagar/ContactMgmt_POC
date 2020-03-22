using ContactInfo.Infrastructure.Data.Models;
using ContactInfo.Infrastructure.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactInfo.Infrastructure.Data.Interfaces
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();

        Contact GetById(int Id);

        ContactDetails GetDetailsById(int Id);

        void AddContact(Contact _contact);

        void UpdateContact(Contact _contact);

        void DeleteContact(int id);



    }
}
