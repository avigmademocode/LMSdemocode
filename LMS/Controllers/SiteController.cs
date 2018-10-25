using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Repository.Data;
using LMS.Models;

namespace LMS.Controllers
{
    public class SiteController : Controller
    {
        SiteMasterData siteMasterData = new SiteMasterData();
        //SiteMasterDTO siteMasterDTO = new SiteMasterDTO();


        // GET: Site
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult view()
        {
            return View();
        }
        public JsonResult AddSiteDetail(SiteMasterDTO siteMasterDTO)
        {
            
            var Data = siteMasterData.AddSiteMasterDetails(siteMasterDTO);
            return new JsonResult { Data = Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetSiteDetailsData(SiteMasterDetailDTO siteMasterDTO)
        {

            var Data= siteMasterData.GetSiteMasterdetails(siteMasterDTO);
            return new JsonResult { Data = Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
    }
}