using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class AttendanceDTO
    {
        public Int64 AttendanceId { get; set; }
        public Int64 CourseSubId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 BatchId { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public String TimeFormat { get; set; }
        public Int64 AttendanceType { get; set; }
        public Boolean IsActive { get; set; }
        public Int64 CurrUserId { get; set; }
        public int Type { get; set; }
    }
}