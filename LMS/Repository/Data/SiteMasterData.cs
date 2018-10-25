using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Repository.Lib;
using LMS.Models;
using System.Data;

namespace LMS.Repository.Data
{
    public class SiteMasterData
    {
        MyDataSourceFactory obj = new MyDataSourceFactory();

        public List<dynamic> AddSiteMasterDetails(SiteMasterDTO siteMaster)
        {
            string insertProcedure = "[CreateSiteMaster]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();

            input_parameters.Add("@LearningSiteId", 1 + "#bigint#" + siteMaster.LearningSiteId);
            input_parameters.Add("@LearningSiteName", 1 + "#nvarchar#" + siteMaster.LearningSiteName);
            input_parameters.Add("@SitePhysicalAddressLine1", 1 + "#nvarchar#" + siteMaster.SitePhysicalAddressLine1);
            input_parameters.Add("@AddressLine2", 1 + "#nvarchar#" + siteMaster.AddressLine2);
            input_parameters.Add("@City", 1 + "#int#" + siteMaster.City);
            input_parameters.Add("@LearningSiteMunicipalDistrict", 1 + "#nvarchar#" + siteMaster.LearningSiteMunicipalDistrict);
            input_parameters.Add("@State", 1 + "#int#" + siteMaster.State);
            input_parameters.Add("@PostalCode", 1 + "#bigint#" + siteMaster.PostalCode);
            input_parameters.Add("@LearningSiteProvince", 1 + "#nvarchar#" + siteMaster.LearningSiteProvince);
            input_parameters.Add("@GPSLatitude", 1 + "#decimal#" + siteMaster.GPSLatitude);
            input_parameters.Add("@GPSLongitude", 1 + "#decimal#" + siteMaster.GPSLongitude);
            input_parameters.Add("@LocatedInMetros", 1 + "#bit#" + siteMaster.LocatedInMetros);
            input_parameters.Add("@Rural", 1 + "#bit#" + siteMaster.Rural);
            input_parameters.Add("@CurrUserId", 1 + " #bigint# " + siteMaster.CurrUserId);
            input_parameters.Add("@IsActive", 1 + "#bit#" + siteMaster.IsActive);
            input_parameters.Add("@Type", 1 + "#int#" + siteMaster.Type);
            input_parameters.Add("@LearningSiteIdOut", 2 + "#int#" + null);
            input_parameters.Add("@ReturnValue", 2 + "#int#" + null);



            return obj.SqlCRUD(insertProcedure, input_parameters);



        }
        public List<dynamic> GetSiteMasterdetails(SiteMasterDetailDTO siteMaster)
        {


            List<dynamic> objDynamic = new List<dynamic>();
            String insertProcedure = "[GetSiteMaster]";

            Dictionary<string, string> input_parameters = new Dictionary<string, string>();
            input_parameters.Add("@LearningSiteId", 1 + "#bigint#" + siteMaster.LearningSiteId);
            input_parameters.Add("@Type", 1 + "#int#" + siteMaster.Type);


            DataSet ds = obj.SelectSql(insertProcedure, input_parameters);

            var myEnumerable = ds.Tables[0].AsEnumerable();


            List<SiteMasterDetailDTO> sm =
                (from item in myEnumerable
                 select new SiteMasterDetailDTO
                 {
                     LearningSiteId = item.Field<Int64>("LearningSiteId"),
                     LearningSiteName = item.Field<String>("LearningSiteName"),
                     SitePhysicalAddressLine1 = item.Field<String>("SitePhysicalAddressLine1"),
                     AddressLine2 = item.Field<String>("AddressLine2"),
                     City = item.Field<int>("City"),
                     LearningSiteMunicipalDistrict = item.Field<String>("LearningSiteMunicipalDistrict"),
                     State = item.Field<int>("State"),
                     PostalCode = item.Field<Int64>("PostalCode"),
                     LearningSiteProvince = item.Field<String>("LearningSiteProvince"),
                     GPSLatitude = item.Field<Decimal>("GPSLatitude"),
                     GPSLongitude = item.Field < Decimal>("GPSLatitude"),
                     LocatedInMetros = item.Field<Boolean>("LocatedInMetros"),
                     Rural =item.Field<Boolean>("Rural"),
                     CityName=item.Field<String>("CityName"),
                     StateName=item.Field<String>("StateName"),
                     IsActive=item.Field<Boolean>("IsActive"),
                     //CityName= Convert.ToString(item.Field<int>("City")),
                    // StateName = Convert.ToString(item.Field<int>("State")),


                 }).ToList();
            objDynamic.Add(sm);
            return objDynamic;
        }



    }
}