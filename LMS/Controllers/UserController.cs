using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Repository.Data;
using LMS.Models;

namespace LMS.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult viewUserdata()
        {
            return View();
        }
        public JsonResult AddUserDetailData(UserDetailsDTO userDetails)
        {
            UserDetailsData userDetailsData = new UserDetailsData();
            var Data = userDetailsData.AddUserDetails(userDetails);
            return new JsonResult { Data = Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetUserDetailData(UserDetailsDTO userDetailsDTO)
        {
            UserDetailsData userDetailsData = new UserDetailsData();
            var data = userDetailsData.GetUserdetails(userDetailsDTO);
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

       
    }
}