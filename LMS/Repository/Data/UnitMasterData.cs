using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Repository.Lib;
using LMS.Models;
using System.Data;

namespace LMS.Repository.Data
{
    public class UnitMasterData
    {
        MyDataSourceFactory obj = new MyDataSourceFactory();

        public List<dynamic> AddUnitMasterDetails(UnitMasterDTO unitMaster)
        {
            string insertProcedure = "[CreateUnitMaster]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();

            input_parameters.Add("@UnitID", 1 + "#bigint#" + unitMaster.UnitID);
            input_parameters.Add("@UnitType", 1 + "#int#" + unitMaster.UnitType);
            input_parameters.Add("@UnitTitle", 1 + "#nvarchar#" + unitMaster.UnitTitle);
            input_parameters.Add("@NQFLevel", 1 + "#nvarchar#" + unitMaster.NQFLevel);
            input_parameters.Add("@Credits", 1 + "#int#" + unitMaster.Credits);
            input_parameters.Add("@NumberOfDaysRequiredToComplete", 1 + "#bigint#" + unitMaster.NumberOfDaysRequiredToComplete);
            input_parameters.Add("@AmountApprovedForTheUnit", 1 + "#decimal#" + unitMaster.AmountApprovedForTheUnit);
            input_parameters.Add("@CurrUserId", 1 + " #bigint# " + unitMaster.CurrUserId);
            input_parameters.Add("@IsActive", 1 + "#bit#" + unitMaster.IsActive);
            input_parameters.Add("@Type", 1 + "#int#" + unitMaster.Type);
            input_parameters.Add("@UnitIdOut", 2 + "#int#" + null);
            input_parameters.Add("@ReturnValue", 2 + "#int#" + null);



            return obj.SqlCRUD(insertProcedure, input_parameters);



        }

        public List<dynamic> GetUnitDetailsData(UnitMasterDTO unitMasterDTO)
        {
            List<dynamic> objDynamic = new List<dynamic>();
            String insertProcedure = "[GetUnitMaster]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();

            input_parameters.Add("@UnitID", 1 + "#bigint#" + unitMasterDTO.UnitID);
            input_parameters.Add("@Type", 1 + "#int#" + unitMasterDTO.Type);

            DataSet ds = obj.SelectSql(insertProcedure, input_parameters);
            var myEnumerable = ds.Tables[0].AsEnumerable();


            List<UnitMasterDTO> um =
                (from item in myEnumerable
                 select new UnitMasterDTO
                 {
                     UnitID = item.Field<Int64>("UnitID"),
                     UnitType = item.Field<int>("UnitType"),
                     UnitTitle = item.Field<String>("UnitTitle"),
                     NQFLevel = item.Field<String>("NQFLevel"),
                     Credits = item.Field<int>("Credits"),
                     NumberOfDaysRequiredToComplete = item.Field<Int64>("NumberOfDaysRequiredToComplete"),
                     AmountApprovedForTheUnit = item.Field<decimal>("AmountApprovedForTheUnit"),

                 }).ToList();
            objDynamic.Add(um);
            return objDynamic;
        }



        public DataSet GetUnitdetails(UnitMasterDTO unitMasterDTO)
        {
            List<dynamic> objDynamic = new List<dynamic>();
            String insertProcedure = "[GetUnitMaster]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();

            input_parameters.Add("@UnitID", 1 + "#bigint#" + unitMasterDTO.UnitID);
            input_parameters.Add("@Type", 1 + "#int#" + unitMasterDTO.Type);

            DataSet ds = obj.SelectSql(insertProcedure, input_parameters);



            return ds;
        }
    }
}