using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Repository.Lib;
using LMS.Models;
using System.Data;

namespace LMS.Repository.Data
{
    public class UserDetailsData
    {
        MyDataSourceFactory obj = new MyDataSourceFactory();

        public List<dynamic> AddUserDetails(UserDetailsDTO userDetailsDTO)
        {
            string insertProcedure = "[CreateUserMaster]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();

            input_parameters.Add("@UserId", 1 +"#bigint#"+ userDetailsDTO.UserId);
            input_parameters.Add("@UserName", 1 +"#nvarchar#"+ userDetailsDTO.UserName);
            input_parameters.Add("@Password", 1 +"#nvarchar#"+ userDetailsDTO.Password);
            input_parameters.Add("@FirstName", 1 +"#nvarchar#"+userDetailsDTO.FirstName);
            input_parameters.Add("@LastName", 1 +"#nvarchar#"+ userDetailsDTO.LastName);
            input_parameters.Add("@MobileNumber", 1 +"#bigint#"+ userDetailsDTO.MobileNumber);
            input_parameters.Add("@EmailId", 1 +"#nvarchar#"+userDetailsDTO.EmailId);
            input_parameters.Add("@NoOfAttempts", 1 +"#int#" + userDetailsDTO.NoOfAttempts);
            input_parameters.Add("@IsLoginActive", 1 + "#bit#" + userDetailsDTO.IsLoginActive);

            input_parameters.Add("@CurrUserId", 1 + " #bigint# " + userDetailsDTO.CurrUserId);
            input_parameters.Add("@IsActive", 1 + "#bit#" + userDetailsDTO.IsActive);
            input_parameters.Add("@Type", 1 + "#int#" + userDetailsDTO.Type);
            input_parameters.Add("@UserIdOut", 2 + "#int#" + null);
            input_parameters.Add("@ReturnValue", 2 + "#int#" + null);



            return obj.SqlCRUD(insertProcedure, input_parameters);


        }


        public List<dynamic> GetUserdetails(UserDetailsDTO user)
        {


            List<dynamic> objDynamic = new List<dynamic>();
            String insertProcedure = "[GetUserMaster]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();
            input_parameters.Add("@UserId", 1 + "#bigint#" + user.UserId);
            input_parameters.Add("@Type", 1 + "#int#" + user.Type);


            DataSet ds = obj.SelectSql(insertProcedure, input_parameters);

            var myEnumerable = ds.Tables[0].AsEnumerable();


            List<UserDetailsDTO> ud =
                (from item in myEnumerable
                 select new UserDetailsDTO
                 {
                     UserId = item.Field<Int64>("UserId"),
                     UserName = item.Field<String>("UserName"),
                     Password = item.Field<String>("Password"),
                     FirstName = item.Field<String>("FirstName"),
                     LastName = item.Field<String>("LastName"),
                     MobileNumber = item.Field<Int64>("MobileNumber"),
                     EmailId = item.Field<String>("EmailId"),
                     NoOfAttempts = item.Field<int>("NoOfAttempts"),
                     IsLoginActive = item.Field<Boolean>("IsLoginActive"),

                 }).ToList();
            objDynamic.Add(ud);
            return objDynamic;
        }
    }
}