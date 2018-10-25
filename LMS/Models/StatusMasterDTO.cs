using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class StatusMasterDTO
    {
        public Int64 statusId { get; set; }
        public String StatusName { get; set; }
        public Boolean IsActive { get; set; }
        public Int64 CurrUserId { get; set; }
        public int Type { get; set; }
    }
}