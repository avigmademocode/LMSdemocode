using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class UserDetailsDTO
    {
        public Int64 UserId { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int64 MobileNumber { get; set; }
        public String EmailId { get; set; }
        public int NoOfAttempts { get; set; }
        public Boolean IsLoginActive { get; set; }
        public Boolean IsActive { get; set; }
        public int Type { get; set; }
        public Int64 CurrUserId { get; set; }

    }
}
