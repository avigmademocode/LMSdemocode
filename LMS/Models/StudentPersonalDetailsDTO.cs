using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class StudentPersonalDetailsDTO
    {
        public Int64 SPId { get; set; }
        public int RecordNo { get; set; }
        public String StudentName { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public Int64 IDNumber { get; set; }
        public String AlternateIDType { get; set; }
        public String AlternateIDNumber { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Equity { get; set; }
        public String HouseHoldLanguage { get; set; }
        public Int64 CellPhoneNumber { get; set; }
        public Int64 AlternatePhoneNumber { get; set; }
        public String LearnerContactEmail { get; set; }
        public String LearnerContactFacebookAccount { get; set; }
        public String LearnerContactTwitterAccount { get; set; }
        public String LearnerContactLinkedInAccount { get; set; }
        public String LearnerContactInstagramAccount { get; set; }
        public String ResidentialAddressLine1 { get; set; }
        public String ResidentialAddressLine2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public int PostalCode { get; set; }
        public String MunicipalDistrict { get; set; }
        public String Province { get; set; }
        public Boolean IsActive { get; set; }
        public Int64 CurrUserId { get; set; }
        public int Type { get; set; }

    }
}