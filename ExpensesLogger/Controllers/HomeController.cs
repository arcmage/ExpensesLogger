using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ExpensesLogger.Models;

namespace ExpensesLogger.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Main()
        {
            var userID = _context.Users.Single(u => u.Id == "8c0bd739-b5a5-4460-a7a7-26f5ba94ccac");

            return View(userID);
        }

        public ActionResult EnterExpenses(int id)
        {
            var expensesInDb = _context.Expenses.SingleOrDefault(c => c.Id == id);

            return View(expensesInDb);
        }

        public ActionResult Update(Expense expense)
        {
            var expensesInDb = _context.Expenses.Single(e => e.Id == expense.Id && e.Date == expense.Date);

            expensesInDb.Food += expense.Food;
            expensesInDb.Clothing += expense.Clothing;
            expensesInDb.Electronics += expense.Electronics;
            expensesInDb.Gasoline += expense.Gasoline;
            expensesInDb.Travel += expense.Travel;
            expensesInDb.Other += expense.Other;

            _context.SaveChanges();
            
            return RedirectToAction("EnterExpenses", "Home", new {id = expensesInDb.Id});
        }

    }
}