using ContactInfo.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactInfo.Infrastructure.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactGroup> ContactGroups { get; set; }

    }
}
