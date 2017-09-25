using HealthCareAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthCareAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult ReturnCode()
        {
            ViewBag.Title = "Return Code";
            ReturnCode returncode = new ReturnCode();
            ViewBag.ReturnCode = returncode.lstReturCode;
            return View();
        }
    }
}
