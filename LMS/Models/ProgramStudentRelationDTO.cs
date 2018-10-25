using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class ProgramStudentRelationDTO
    {
        public Int64 PSRId { get; set; }
        public Int64 StudentId { get; set; }
        public DateTime ProgramStartDate { get; set; }
        public DateTime ProgramEndDate { get; set; }
        public int ProgCompletedInPerc { get; set; }
        public Boolean IsActive { get; set; }
        public Int64 CurrUserId { get; set; }
        public int Type { get; set; }
    }
}