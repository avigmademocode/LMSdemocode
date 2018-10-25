using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class ProgramMasterDTO
    {
        public Int64 ProgramId { get; set; }
        public Int64 StatusId { get; set; }
        public String Activity { get; set; }
        public String Facilitation { get; set; }
        public String UserNameCreditsId { get; set; }
        public DateTime TimeFrame { get; set; }
        public String FundamentalInfo { get; set; }
        public int NoOfDays { get; set; }
        public Boolean IsActive { get; set; }
        public Int64 CurrUserId { get; set; }
        public int Type { get; set; }
    }
}