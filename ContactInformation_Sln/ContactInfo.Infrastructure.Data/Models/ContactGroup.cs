using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactInfo.Infrastructure.Data.Models
{
    public class ContactGroup
    {
        [Required]
        [Key]
        public int GroupID { get; set; }

        [Required]
        public string GroupName { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

    }
}
