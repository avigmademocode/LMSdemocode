using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class StudentProgDetailsDTO
    {
        public Int64 StudentId { get; set; }
        public Int64 SPId { get; set; }
        public String StudentName { get; set; }
        public String SightDisability { get; set; }
        public String HearingDisability { get; set; }
        public String MovementDisability { get; set; }
        public String MentalDisability { get; set; }
        public String SelfCareDisability { get; set; }
        public String CommunicationDisability { get; set; }
        public String LearningProgramName { get; set; }
        public String LearningProgramCategory { get; set; }
        public String NameofPublicUniversity { get; set; }
        public String SAQAQualificationID { get; set; }
        public DateTime LearningProgStartDate { get; set; }
        public DateTime LearningProgEndDate { get; set; }
        public String LearningSiteName { get; set; }
        public Boolean IsActive { get; set; }
        public Int64 CurrUserId { get; set; }
        public int Type { get; set; }

    }
}