using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Repository.Lib;
using LMS.Models;
using System.Data;

namespace LMS.Repository.Data
{
    public class ProgramStudentRelationData
    {
        MyDataSourceFactory obj = new MyDataSourceFactory();

        public List<dynamic> AddProgStuRelationDetails(ProgramStudentRelationDTO programStudentRelation)
        {
            string insertProcedure = "[CreateProgramStudentRelation]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();

            input_parameters.Add("@PSRId", 1 + "#bigint#" + programStudentRelation.PSRId);
            input_parameters.Add("@StudentId", 1 + "#nvarchar#" + programStudentRelation.StudentId);
            input_parameters.Add("@ProgramStartDate", 1 + "#datetime#" + programStudentRelation.ProgramStartDate);
            input_parameters.Add("@ProgramEndDate", 1 + "#datetime#" + programStudentRelation.ProgramEndDate);
            input_parameters.Add("@ProgCompletedInPerc", 1 + "#int#" + programStudentRelation.ProgCompletedInPerc);
            input_parameters.Add("@CurrUserId", 1 + " #bigint# " + programStudentRelation.CurrUserId);
            input_parameters.Add("@IsActive", 1 + "#bit#" + programStudentRelation.IsActive);
            input_parameters.Add("@Type", 1 + "#int#" + programStudentRelation.Type);
            input_parameters.Add("@PSRIdOut", 2 + "#int#" + null);
            input_parameters.Add("@ReturnValue", 2 + "#int#" + null);



            return obj.SqlCRUD(insertProcedure, input_parameters);



        }
        public List<dynamic> GetProgStudRelationdetails(ProgramStudentRelationDTO programStudent)
        {


            List<dynamic> objDynamic = new List<dynamic>();
            String insertProcedure = "[GetProgramStudentRelation]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();
            input_parameters.Add("@PSRId", 1 + "#bigint#" + programStudent.PSRId);
            input_parameters.Add("@Type", 1 + "#int#" + programStudent.Type);


            DataSet ds = obj.SelectSql(insertProcedure, input_parameters);

            var myEnumerable = ds.Tables[0].AsEnumerable();


            List<ProgramStudentRelationDTO> ps =
                (from item in myEnumerable
                 select new ProgramStudentRelationDTO
                 {
                     PSRId = item.Field<Int64>("PSRId"),
                     StudentId = item.Field<Int64>("StudentId"),
                     ProgramStartDate = item.Field<DateTime>("ProgramStartDate"),
                     ProgramEndDate = item.Field<DateTime>("ProgramEndDate"),
                     ProgCompletedInPerc = item.Field<int>("ProgCompletedInPerc"),


                 }).ToList();
            objDynamic.Add(ps);
            return objDynamic;
        }
    }
}