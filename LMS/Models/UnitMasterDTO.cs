using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class UnitMasterDTO
    {
        public Int64 UnitID { get; set; }
        public int UnitType { get; set; }
        public String UnitTitle { get; set; }
        public String NQFLevel { get; set; }
        public int Credits { get; set; }
        public Int64 NumberOfDaysRequiredToComplete { get; set; }
        public decimal AmountApprovedForTheUnit { get; set; }
        public Boolean IsActive { get; set; }
        public Int64 CurrUserId { get; set; }
        public int Type { get; set; }
    }
}