using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool isSubsribedToNewsletter { get; set; }
        public MembershipType membershipType { get; set; }
        public byte membershipTypeId { get; set; }

    }
}