using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ExpensesLogger.Models;
using Microsoft.AspNet.Identity;

namespace ExpensesLogger.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private string userId;

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
            userId = User.Identity.GetUserId();
            var userExpenses = _context.Expenses.Single(u => u.UserId.Equals(userId));

            return View(userExpenses);
        }

        public ActionResult EnterExpenses(int id, DateTime searchDate)
        {
            var expensesInDb = _context.Expenses.SingleOrDefault(c => c.Id == id && c.Date == searchDate);
            
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
            
            return RedirectToAction("EnterExpenses", "Home", new {id = expensesInDb.Id, searchDate= expensesInDb.Date});
        }

    }
}