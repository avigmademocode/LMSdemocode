using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Repository.Lib;
using LMS.Models;
using System.Data;

namespace LMS.Repository.Data
{
    public class StudentPersonalDetailsData
    {
        MyDataSourceFactory obj = new MyDataSourceFactory();

        public List<dynamic> AddStudentPersonalDetails(StudentPersonalDetailsDTO studentPersonalDetails)
        {
            string insertProcedure = "[CreateStudentPersonalDetails]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();

            input_parameters.Add("@SPId", 1 + "#bigint#" + studentPersonalDetails.SPId);
            input_parameters.Add("@RecordNo", 1 + "#int#" + studentPersonalDetails.RecordNo);
            input_parameters.Add("@StudentName", 1 + "#nvarchar#" + studentPersonalDetails.StudentName);
           
            input_parameters.Add("@FirstName", 1 + "#nvarchar#" + studentPersonalDetails.FirstName);
            input_parameters.Add("@MiddleName", 1 + "#nvarchar#" + studentPersonalDetails.MiddleName);
            input_parameters.Add("@LastName", 1 + "#nvarchar#" + studentPersonalDetails.LastName);
            input_parameters.Add("@IDNumber", 1 + "#bigint#" + studentPersonalDetails.IDNumber);
            input_parameters.Add("@AlternateIDType", 1 + "#nvarchar#" + studentPersonalDetails.AlternateIDType);
            input_parameters.Add("@AlternateIDNumber", 1 + "#nvarchar#" + studentPersonalDetails.AlternatePhoneNumber);
            input_parameters.Add("@Gender", 1 + "#int#" + studentPersonalDetails.Gender);
            input_parameters.Add("@DateOfBirth", 1 + "#datetime#" + studentPersonalDetails.DateOfBirth);
            input_parameters.Add("@Equity", 1 + "#nvarchar#" + studentPersonalDetails.Equity);
            input_parameters.Add("@HouseHoldLanguage", 1 + "#nvarchar#" + studentPersonalDetails.HouseHoldLanguage);
            input_parameters.Add("@CellPhoneNumber", 1 + "#bigint#" + studentPersonalDetails.CellPhoneNumber);
            input_parameters.Add("@AlternatePhoneNumber", 1 + "#bigint#" + studentPersonalDetails.AlternatePhoneNumber);
            input_parameters.Add("@LearnerContactEmail", 1 + "#nvarchar#" + studentPersonalDetails.LearnerContactEmail);
            input_parameters.Add("@LearnerContactFacebookAccount", 1 + "#nvarchar#" + studentPersonalDetails.LearnerContactFacebookAccount);
            input_parameters.Add("@LearnerContactTwitterAccount", 1 + "#nvarchar#" + studentPersonalDetails.LearnerContactTwitterAccount);
            input_parameters.Add("@LearnerContactLinkedInAccount", 1 + "#nvarchar#" + studentPersonalDetails.LearnerContactLinkedInAccount);
            input_parameters.Add("@LearnerContactInstagramAccount", 1 + "#nvarchar#" + studentPersonalDetails.LearnerContactInstagramAccount);
            input_parameters.Add("@ResidentialAddressLine1", 1 + "#nvarchar#" + studentPersonalDetails.ResidentialAddressLine1);
            input_parameters.Add("@ResidentialAddressLine2", 1 + "#nvarchar#" + studentPersonalDetails.ResidentialAddressLine2);
            input_parameters.Add("@City", 1 + "#nvarchar#" + studentPersonalDetails.City);
            input_parameters.Add("@State", 1 + "#nvarchar#" + studentPersonalDetails.State);
            input_parameters.Add("@PostalCode", 1 + "#int#" + studentPersonalDetails.PostalCode);
            input_parameters.Add("@MunicipalDistrict", 1 + "#nvarchar#" + studentPersonalDetails.MunicipalDistrict);
            input_parameters.Add("@Province", 1 + "#nvarchar#" + studentPersonalDetails.Province);
            input_parameters.Add("@CurrUserId", 1 + " #bigint# " + studentPersonalDetails.CurrUserId);
            input_parameters.Add("@IsActive", 1 + "#bit#" + studentPersonalDetails.IsActive);
            input_parameters.Add("@Type", 1 + "#int#" + studentPersonalDetails.Type);
            input_parameters.Add("@SPIdOut", 2 + "#int#" + null);
            input_parameters.Add("@ReturnValue", 2 + "#int#" + null);



            return obj.SqlCRUD(insertProcedure, input_parameters);



        }
        public List<dynamic> GetStudntPersnldetails(StudentPersonalDetailsDTO student)
        {


            List<dynamic> objDynamic = new List<dynamic>();
            String insertProcedure = "[GetStudentPersonalDetails]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();
            input_parameters.Add("@SPId", 1 + "#bigint#" + student.SPId);
            input_parameters.Add("@Type", 1 + "#int#" + student.Type);


            DataSet ds = obj.SelectSql(insertProcedure, input_parameters);

            var myEnumerable = ds.Tables[0].AsEnumerable();


            List<StudentPersonalDetailsDTO> spd =
                (from item in myEnumerable
                 select new StudentPersonalDetailsDTO
                 {
                     SPId = item.Field<Int64>("SPId"),
                     RecordNo = item.Field<int>("RecordNo"),
                     StudentName = item.Field<String>("StudentName"),
                     FirstName = item.Field<String>("FirstName"),
                     MiddleName = item.Field<String>("MiddleName"),
                     LastName = item.Field<String>("LastName"),
                     IDNumber =item.Field<Int64>("IDNumber"),
                     AlternateIDType = item.Field<String>("AlternateIDType"),
                     AlternateIDNumber = item.Field<String>("AlternateIDNumber"),
                     Gender = item.Field<int>("Gender"),
                     DateOfBirth = item.Field<DateTime>("DateOfBirth"),
                     Equity = item.Field<String>("Equity"),
                     HouseHoldLanguage = item.Field<String>("HouseHoldLanguage"),
                     CellPhoneNumber = item.Field<Int64>("CellPhoneNumber"),
                     AlternatePhoneNumber =item.Field<Int64>("AlternatePhoneNumber"),
                     LearnerContactEmail = item.Field<String>("LearnerContactEmail"),
                     LearnerContactFacebookAccount = item.Field<String>("LearnerContactFacebookAccount"),
                     LearnerContactTwitterAccount = item.Field<String>("LearnerContactTwitterAccount"),
                     LearnerContactLinkedInAccount = item.Field<String>("LearnerContactLinkedInAccount"),
                     LearnerContactInstagramAccount = item.Field<String>("LearnerContactInstagramAccount"),
                     ResidentialAddressLine1 = item.Field<String>("ResidentialAddressLine1"),
                     ResidentialAddressLine2 = item.Field<String>("ResidentialAddressLine2"),
                     City = item.Field<String>("City"),
                     State = item.Field<String>("State"),
                     PostalCode = item.Field<int>("PostalCode"),
                     MunicipalDistrict = item.Field<String>("MunicipalDistrict"),
                     Province = item.Field<String>("Province"),
                     

                 }).ToList();
            objDynamic.Add(spd);
            return objDynamic;
        }
    }
}