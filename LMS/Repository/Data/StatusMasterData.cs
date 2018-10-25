using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Repository.Lib;
using LMS.Models;
using System.Data;

namespace LMS.Repository.Data
{
    public class StatusMasterData
    {
        MyDataSourceFactory obj = new MyDataSourceFactory();
        public List<dynamic> AddProgramData(StatusMasterDTO statusMasterDTO)
        {
            string insertProcedure = "[CreateStatusMaster]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();
            input_parameters.Add("@statusId", 1 + "#bigint#"+statusMasterDTO.statusId );
            input_parameters.Add("@StatusName", 1 +"#varchar#"+statusMasterDTO.StatusName);
            input_parameters.Add("@CurrUserId", 1 + " #bigint# " + statusMasterDTO.CurrUserId);
            input_parameters.Add("@IsActive", 1 + "#bit#" + statusMasterDTO.IsActive);
            input_parameters.Add("@Type", 1 + "#int#" + statusMasterDTO.Type);
            input_parameters.Add("@UnitIdOut", 2 + "#int#" + null);
            input_parameters.Add("@ReturnValue", 2 + "#int#" + null);

            return obj.SqlCRUD(insertProcedure, input_parameters);
        }

        public List<dynamic> GetStatusdetails(StatusMasterDTO statusMasterDTO)
        {
            List<dynamic> objDynamic = new List<dynamic>();
            String insertProcedure = "[GetStatusMaster]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();

            input_parameters.Add("@statusId", 1 + "#bigint#" + statusMasterDTO.statusId);
            input_parameters.Add("@Type", 1 + "#int#" + statusMasterDTO.Type);

            DataSet ds = obj.SelectSql(insertProcedure, input_parameters);
            var myEnumerable = ds.Tables[0].AsEnumerable();


            List<StatusMasterDTO> sm =
                (from item in myEnumerable
                 select new StatusMasterDTO
                 {
                     statusId = item.Field<Int64>("statusId"),
                     StatusName =item.Field<String>("StatusName"),


                 }).ToList();
            objDynamic.Add(sm);
            return objDynamic;
        }
    }
}