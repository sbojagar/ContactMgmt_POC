using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactInfo.Infrastructure.Data.Models.ViewModels
{
    public class ContactDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string ImageURL { get; set; }
        public string Email { get; set; }
        public string GroupName { get; set; }
    }
}
