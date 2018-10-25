using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Repository.Data;
using LMS.Models;

namespace LMS.Controllers
{
    public class ProgramController : Controller
    {
        ProgramMasterData programMasterData = new ProgramMasterData();
        // GET: Program
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewProgram()
        {
            return View();
        }
        public JsonResult AddProgramsData(ProgramMasterDTO programMasterDTO)
        {
           
            var Data =programMasterData.AddProgramDetails(programMasterDTO);
            return new JsonResult { Data = Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetProgramsData(ProgramMasterDTO programMasterDTO)
        {
            var Data = programMasterData.GetProgramdetails(programMasterDTO);
            return new JsonResult { Data = Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
  

             public JsonResult getStatusDetailData(StatusMasterDTO statusMasterDTO)
             {
                StatusMasterData statusMasterData = new StatusMasterData();
                var Data = statusMasterData.GetStatusdetails(statusMasterDTO);
               return new JsonResult { Data = Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
              }
    }
}