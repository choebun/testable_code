using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingWeb.Controllers
{
    public class testingController : Controller
    {
        // GET: testing
        public ActionResult testing()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [HttpPost]
        public ActionResult Result(string year, string month)
        {

            ViewBag.Message = "Your result page.";
            ViewBag.Month = month;
            ViewBag.Year = year;

            return View();
        }
    }
}