﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactInfo.Infrastructure.Data.Models.ViewModels
{
    public class ContactsIndexModel
    {
        public IEnumerable<ContactsListingModel> Contacts { get; set; }
    }
}
