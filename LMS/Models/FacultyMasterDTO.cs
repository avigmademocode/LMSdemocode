using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class FacultyMasterDTO
    {
        public Int64 FacultyId { get; set; }
        public String FacultyName { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int64 SitePhoneNumber { get; set; }
        public Int64 ContactPersonMobile { get; set; }
        public String ContactPersonEmailAddress { get; set; }
        public Boolean IsActive { get; set; }
        public Int64 CurrUserId { get; set; }
        public int Type { get; set; }
    }
}