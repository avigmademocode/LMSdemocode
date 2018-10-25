using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Repository.Lib;
using LMS.Models;
using System.Data;

namespace LMS.Repository.Data
{
    public class StudentProgDetailsData
    {
        MyDataSourceFactory obj = new MyDataSourceFactory();

        public List<dynamic> AddStudentProgDetails(StudentProgDetailsDTO studentProgDetails)
        {
            string insertProcedure = "[CreateStudentPersonalDetails]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();

            input_parameters.Add("@StudentId", 1 + "#bigint#" + studentProgDetails.StudentId);
            input_parameters.Add("@SPId", 1 + "#bigint#" + studentProgDetails.SPId);
            input_parameters.Add("@SightDisability", 1 + "#nvarchar#" + studentProgDetails.SightDisability);
            input_parameters.Add("@HearingDisability", 1 + "#nvarchar#" + studentProgDetails.HearingDisability);
            input_parameters.Add("@MovementDisability", 1 + "#nvarchar#" + studentProgDetails.MovementDisability);
            input_parameters.Add("@MentalDisability", 1 + "#nvarchar#" + studentProgDetails.MentalDisability);
            input_parameters.Add("@SelfCareDisability", 1 + "#nvarchar#" + studentProgDetails.SelfCareDisability);
            input_parameters.Add("@CommunicationDisability", 1 + "#nvarchar#" + studentProgDetails.CommunicationDisability);
            input_parameters.Add("@LearningProgramName", 1 + "#nvarchar#" + studentProgDetails.LearningProgramName);
            input_parameters.Add("@LearningProgramCategory", 1 + "#nvarchar#" + studentProgDetails.LearningProgramCategory);
            input_parameters.Add("@NameofPublicUniversity", 1 + "#nvarchar#" + studentProgDetails.NameofPublicUniversity);
            input_parameters.Add("@SAQAQualificationID", 1 + "#nvarchar#" + studentProgDetails.SAQAQualificationID);
            input_parameters.Add("@LearningProgStartDate", 1 + "#datetime#" + studentProgDetails.LearningProgStartDate);
            input_parameters.Add("@LearningProgEndDate", 1 + "#datetime#" + studentProgDetails.LearningProgEndDate);
            input_parameters.Add("@LearningSiteName", 1 + "#nvarchar#" + studentProgDetails.LearningSiteName);
            input_parameters.Add("@CurrUserId", 1 + " #bigint# " + studentProgDetails.CurrUserId);
            input_parameters.Add("@IsActive", 1 + "#bit#" + studentProgDetails.IsActive);
            input_parameters.Add("@Type", 1 + "#int#" + studentProgDetails.Type);
            input_parameters.Add("@StudentIdOut", 2 + "#int#" + null);
            input_parameters.Add("@ReturnValue", 2 + "#int#" + null);



            return obj.SqlCRUD(insertProcedure, input_parameters);



        }
        public List<dynamic> GetStudntProgdetails(StudentProgDetailsDTO student)
        {


            List<dynamic> objDynamic = new List<dynamic>();
            String insertProcedure = "[GetStudentProgDetails]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();
            input_parameters.Add("@StudentId", 1 + "#bigint#" + student.StudentId);
            input_parameters.Add("@Type", 1 + "#int#" + student.Type);


            DataSet ds = obj.SelectSql(insertProcedure, input_parameters);

            var myEnumerable = ds.Tables[0].AsEnumerable();


            List<StudentProgDetailsDTO> spd =
                (from item in myEnumerable
                 select new StudentProgDetailsDTO
                 {
                     StudentId = item.Field<Int64>("StudentId"),
                     SPId = item.Field<Int64>("SPId"),
                     SightDisability= item.Field<String>("SightDisability"),
                     HearingDisability = item.Field<String>("HearingDisability"),
                     MovementDisability= item.Field<String>("MovementDisability"),
                     MentalDisability = item.Field<String>("MentalDisability"),
                     SelfCareDisability = item.Field<String>("SelfCareDisability"),
                     CommunicationDisability = item.Field<String>("CommunicationDisability"),
                     LearningProgramName = item.Field<String>("LearningProgramName"),
                     LearningProgramCategory = item.Field<String>("LearningProgramCategory"),
                     NameofPublicUniversity = item.Field<String>("NameofPublicUniversity"),
                     SAQAQualificationID = item.Field<String>("SAQAQualificationID"),
                     LearningProgStartDate = item.Field<DateTime>("LearningProgStartDate"),
                     LearningProgEndDate = item.Field<DateTime>("LearningProgEndDate"),
                     LearningSiteName = item.Field<String>("LearningSiteName"),


                 }).ToList();
            objDynamic.Add(spd);
            return objDynamic;
        }
    }
}