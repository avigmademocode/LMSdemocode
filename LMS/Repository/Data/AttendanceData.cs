using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Repository.Lib;
using LMS.Models;
using System.Data;


namespace LMS.Repository.Data
{
    public class AttendanceData
    {
        MyDataSourceFactory obj = new MyDataSourceFactory();

        public List<dynamic> AddAttendanceDetails(AttendanceDTO attendanceDTO)
        {
            string insertProcedure = "[CreateAttendance]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();

            input_parameters.Add("@AttendanceId", 1 + "#bigint#" + attendanceDTO.AttendanceId);
            input_parameters.Add("@CourseSubId", 1 + "#bigint#" + attendanceDTO.CourseSubId);
            input_parameters.Add("@UserId", 1 + "#bigint#" + attendanceDTO.UserId);
            input_parameters.Add("@DateTime", 1 + "#datetime#" + attendanceDTO.DateTime);
            input_parameters.Add("@FromDate", 1 + "#datetime#" + attendanceDTO.FromDate);
            input_parameters.Add("@ToDate", 1 + "#datetime#" + attendanceDTO.ToDate);
            input_parameters.Add("@TimeFormat", 1 + "#nvarchar#" + attendanceDTO.TimeFormat);
            input_parameters.Add("@AttendanceType", 1 + "#bigint#" + attendanceDTO.AttendanceType);
            input_parameters.Add("@CurrUserId", 1 + " #bigint# " + attendanceDTO.CurrUserId);
            input_parameters.Add("@IsActive", 1 + "#bit#" + attendanceDTO.IsActive);
            input_parameters.Add("@Type", 1 + "#int#" + attendanceDTO.Type);
            input_parameters.Add("@AttendanceIdOut", 2 + "#int#" + null);
            input_parameters.Add("@ReturnValue", 2 + "#int#" + null);



            return obj.SqlCRUD(insertProcedure, input_parameters);



        }
        public List<dynamic> GetAttendancedetails(AttendanceDTO attendance)
        {


            List<dynamic> objDynamic = new List<dynamic>();
            String insertProcedure = "[GetAttendance]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();
            input_parameters.Add("@AttendanceId", 1 + "#bigint#" + attendance.AttendanceId);
            input_parameters.Add("@Type", 1 + "#int#" + attendance.Type);


            DataSet ds = obj.SelectSql(insertProcedure, input_parameters);

            var myEnumerable = ds.Tables[0].AsEnumerable();


            List<AttendanceDTO> at =
                (from item in myEnumerable
                 select new AttendanceDTO
                 {
                     AttendanceId = item.Field<Int64>("AttendanceId"),
                     CourseSubId = item.Field<Int64>("CourseSubId"),
                     UserId = item.Field<Int64>("UserId"),
                     BatchId = item.Field<Int64>("BatchId"),
                     DateTime = item.Field<DateTime>("DateTime"),
                     FromDate = item.Field<DateTime>("FromDate"),
                     ToDate = item.Field<DateTime>("ToDate"),
                     TimeFormat = item.Field<String>("TimeFormat"),
                     AttendanceType = item.Field<Int64>("AttendanceType"),
                  
                 }).ToList();
            objDynamic.Add(at);
            return objDynamic;
        }
    }
}