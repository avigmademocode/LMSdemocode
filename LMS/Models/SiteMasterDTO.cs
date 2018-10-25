using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class SiteMasterDTO
    {
        public Int64 LearningSiteId { get; set; }
        public String LearningSiteName { get; set; }
        public String SitePhysicalAddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public int City { get; set; }
        public String LearningSiteMunicipalDistrict { get; set; }
        public int State { get; set; }
        public Int64 PostalCode { get; set; }
        public String LearningSiteProvince { get; set; }
        public Decimal GPSLatitude { get; set; }
        public Decimal GPSLongitude { get; set; }
        public Boolean LocatedInMetros { get; set; }
        public Boolean Rural { get; set; }
        public Boolean IsActive { get; set; }
        public Int64 CurrUserId { get; set; }
        public int Type { get; set; }
    
    }


    public class SiteMasterDetailDTO
    {
        public Int64 LearningSiteId { get; set; }
        public String LearningSiteName { get; set; }
        public String SitePhysicalAddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public int City { get; set; }
        public String LearningSiteMunicipalDistrict { get; set; }
        public int State { get; set; }
        public Int64 PostalCode { get; set; }
        public String LearningSiteProvince { get; set; }
        public Decimal GPSLatitude { get; set; }
        public Decimal GPSLongitude { get; set; }
        public Boolean LocatedInMetros { get; set; }
        public Boolean Rural { get; set; }

        public String CityName { get; set; }
        public String StateName { get; set; }

        public Boolean IsActive { get; set; }
        public Int64 CurrUserId { get; set; }
        public int Type { get; set; }

    }
}