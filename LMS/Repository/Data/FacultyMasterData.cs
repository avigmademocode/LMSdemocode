using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Repository.Lib;
using LMS.Models;
using System.Data;

namespace LMS.Repository.Data
{
    
        public class FacultyMasterData
        {
            MyDataSourceFactory obj = new MyDataSourceFactory();

            public List<dynamic> AddFacultyDetails(FacultyMasterDTO facultyMaster)
            {
                string insertProcedure = "[CreateFacultyMaster]";

                Dictionary<string, string> input_parameters = new Dictionary<string, string>();

                input_parameters.Add("@FacultyId", 1 + "#bigint#" + facultyMaster.FacultyId);
                input_parameters.Add("@FacultyName", 1 + "#nvarchar#" + facultyMaster.FacultyName);
                input_parameters.Add("@FirstName", 1 + "#nvarchar#" + facultyMaster.FirstName);
                input_parameters.Add("@LastName", 1 + "#nvarchar#" + facultyMaster.LastName);
                input_parameters.Add("@SitePhoneNumber", 1 + "#bigint#" + facultyMaster.SitePhoneNumber);
                input_parameters.Add("@ContactPersonMobile", 1 + "#bigint#" + facultyMaster.ContactPersonMobile);
                input_parameters.Add("@ContactPersonEmailAddress", 1 + "#nvarchar#" + facultyMaster.ContactPersonEmailAddress);
                input_parameters.Add("@CurrUserId", 1 + " #bigint# " + facultyMaster.CurrUserId);
                input_parameters.Add("@IsActive", 1 + "#bit#" + facultyMaster.IsActive);
                input_parameters.Add("@Type", 1 + "#int#" + facultyMaster.Type);
                input_parameters.Add("@FacultyIdOut", 2 + "#int#" + null);
                input_parameters.Add("@ReturnValue", 2 + "#int#" + null);



                return obj.SqlCRUD(insertProcedure, input_parameters);



            }
            public List<dynamic> GetFacultydetails(FacultyMasterDTO faculty)
            {


                List<dynamic> objDynamic = new List<dynamic>();
                String insertProcedure = "[GetFacultyMaster]";

                Dictionary<string, string> input_parameters = new Dictionary<string, string>();
                input_parameters.Add("@FacultyId", 1 + "#bigint#" + faculty.FacultyId);
                input_parameters.Add("@Type", 1 + "#int#" + faculty.Type);


                DataSet ds = obj.SelectSql(insertProcedure, input_parameters);

                var myEnumerable = ds.Tables[0].AsEnumerable();


                List<FacultyMasterDTO> fm =
                    (from item in myEnumerable
                     select new FacultyMasterDTO
                     {
                         FacultyId = item.Field<Int64>("FacultyId"),
                         FacultyName = item.Field<String>("FacultyName"),
                         FirstName = item.Field<String>("FirstName"),
                         LastName = item.Field<String>("LastName"),
                         SitePhoneNumber= item.Field<Int64>("SitePhoneNumber"),
                         ContactPersonMobile= item.Field<Int64>("ContactPersonMobile"),
                         ContactPersonEmailAddress= item.Field<String>("ContactPersonEmailAddress"),
                        


                     }).ToList();
                objDynamic.Add(fm);
                return objDynamic;
            }
        }
    
}