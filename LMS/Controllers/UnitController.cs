using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Repository.Data;
using LMS.Models;
using System.Data;

namespace LMS.Controllers
{
    public class UnitController : Controller
    {
        // GET: Unit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewUnit()
        {
            return View();
        }

        public JsonResult AddUnitData(UnitMasterDTO  unitMasterDTO)
        {
            UnitMasterData unitMasterData = new UnitMasterData();
            var Data =unitMasterData.AddUnitMasterDetails(unitMasterDTO);
            return new JsonResult { Data = Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult GetUnitData(UnitMasterDTO unitMasterDTO)
        {
            DataSet ds = new DataSet();

            UnitMasterData unitMasterData = new UnitMasterData();
            ds = unitMasterData.GetUnitdetails(unitMasterDTO);
            string Data = Newtonsoft.Json.JsonConvert.SerializeObject(ds);
            return new JsonResult { Data = Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getUnitDetailData(UnitMasterDTO unitMasterDTO)
        {
            UnitMasterData unitMasterData = new UnitMasterData();
            var Data =unitMasterData.GetUnitDetailsData(unitMasterDTO);
             return new JsonResult { Data = Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
       
    }
}