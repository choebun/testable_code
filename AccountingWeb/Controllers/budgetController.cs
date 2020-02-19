using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingWeb.Controllers
{
    public class budgetController : Controller
    {
        // GET: budget
        public ActionResult create()
        {
            return View();
        }
    }
}