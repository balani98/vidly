using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vidly.Dto
{
    public class MembershipTypeDto
    {
        public byte id { get; set; }
        public string membershipTypeName { get; set; }
        public short signUpFee { get; set; }

        public byte durationInMonths { get; set; }
        public byte discountRate { get; set; }
    }
}