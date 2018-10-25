using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Repository.Lib;
using LMS.Models;
using System.Data;

namespace LMS.Repository.Data
{
        public class ProgramMasterData
        {
            MyDataSourceFactory obj = new MyDataSourceFactory();

            public List<dynamic> AddProgramDetails(ProgramMasterDTO programMaster)
            {
                string insertProcedure = "[CreateProgramMaster]";

                Dictionary<string, string> input_parameters = new Dictionary<string, string>();

                input_parameters.Add("@ProgramId", 1 + "#bigint#" + programMaster.ProgramId);
                input_parameters.Add("@StatusId", 1 + "#bigint#" + programMaster.StatusId);
                input_parameters.Add("@Activity", 1 + "#nvarchar#" + programMaster.Activity);
                input_parameters.Add("@Facilitation", 1 + "#nvarchar#" + programMaster.Facilitation);
                input_parameters.Add("@UserNameCreditsId", 1 + "#nvarchar#" + programMaster.UserNameCreditsId);
                input_parameters.Add("@TimeFrame", 1 + "#datetime#" + programMaster.TimeFrame);
                input_parameters.Add("@FundamentalInfo", 1 + "#nvarchar#" + programMaster.FundamentalInfo);
                input_parameters.Add("@NoOfDays", 1 + "#int#" + programMaster.NoOfDays);
                input_parameters.Add("@CurrUserId", 1 + " #bigint# " + programMaster.CurrUserId);
                input_parameters.Add("@IsActive", 1 + "#bit#" + programMaster.IsActive);
                input_parameters.Add("@Type", 1 + "#int#" + programMaster.Type);
                input_parameters.Add("@ProgramIdOut", 2 + "#int#" + null);
                input_parameters.Add("@ReturnValue", 2 + "#int#" + null);



                return obj.SqlCRUD(insertProcedure, input_parameters);



            }
            public List<dynamic> GetProgramdetails(ProgramMasterDTO programMaster)
            {


                List<dynamic> objDynamic = new List<dynamic>();
                String insertProcedure = "[GetProgramMaster]";

                Dictionary<string, string> input_parameters = new Dictionary<string, string>();
                input_parameters.Add("@ProgramId", 1 + "#bigint#" + programMaster.ProgramId);
                input_parameters.Add("@Type", 1 + "#int#" + programMaster.Type);


                DataSet ds = obj.SelectSql(insertProcedure, input_parameters);

                var myEnumerable = ds.Tables[0].AsEnumerable();


                List<ProgramMasterDTO> pm =
                    (from item in myEnumerable
                     select new ProgramMasterDTO
                     {
                         ProgramId = item.Field<Int64>("ProgramId"),
                         StatusId = item.Field<Int64>("StatusId"),
                         Activity = item.Field<String>("Activity"),
                         Facilitation = item.Field<String>("Facilitation"),
                         UserNameCreditsId = item.Field<String>("UserNameCreditsId"),
                         TimeFrame= item.Field<DateTime>("TimeFrame"),
                         FundamentalInfo = item.Field<String>("FundamentalInfo"),
                         NoOfDays = item.Field<int>("NoOfDays"),

                     }).ToList();
                objDynamic.Add(pm);
                return objDynamic;
            }
        }
    
}