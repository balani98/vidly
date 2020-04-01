using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Customer
    {    public Customer()
        {
            Id = 0;
        }

        public int Id { get; set; } 
        //Data annotation
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        public bool isSubsribedToNewsletter { get; set; }
        public MembershipType membershipType { get; set; }
        public byte membershipTypeId { get; set; }
       [Min18YearsAge]
        public DateTime?  dateOfBirth { get; set; }
        public static readonly byte unknown = 0;
        public static readonly byte payAsYouGo = 1;

    }
}