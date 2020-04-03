using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        //Data annotation
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        public bool isSubsribedToNewsletter { get; set; }
      
        public byte membershipTypeId { get; set; }
        
        public DateTime? dateOfBirth { get; set; }
        public static readonly byte unknown = 0;
        public static readonly byte payAsYouGo = 1;
    }
}