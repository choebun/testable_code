using AccountingWeb.DataModels;
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
        public ActionResult Result(string year, string month, string budget)
        {
            using (var dbContext = new AccountingEntitiesProd())
            {
                var budgetObj = dbContext.Budgets.Find(year + month);

                if (budgetObj == null)
                {
                    dbContext.Budgets.Add(new Budget() { Amount = System.Convert.ToDecimal(budget), YearMonth = year + month });
                    ViewBag.Message = "Add new budget success";
                }
                else
                {
                    budgetObj.Amount = System.Convert.ToDecimal(budget);
                    ViewBag.Message = "Update budget success";
                }
                dbContext.SaveChanges();
            }

            ViewBag.Month = month;
            ViewBag.Year = year;
            ViewBag.Budget = budget;

            return View();
        }
    }
}