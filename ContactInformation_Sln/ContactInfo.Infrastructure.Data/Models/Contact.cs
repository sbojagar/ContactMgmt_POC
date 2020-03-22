using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactInfo.Infrastructure.Data.Models
{
    public class Contact
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string ImageURL { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
        //public virtual ContactGroup ContactGroups  {get;set;}
        public int ContactsGroupsGroupId { get; set; }
    }
}
