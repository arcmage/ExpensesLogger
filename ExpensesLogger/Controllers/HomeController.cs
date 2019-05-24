using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ExpensesLogger.Models;
using ExpensesLogger.ViewModels;
using Microsoft.Ajax.Utilities;
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

        [Authorize]
        public ActionResult ChooseDate()
        {
            return View();
        }

        [Authorize]
        public ActionResult EnterExpenses(DateTime searchDate)
        {
            // Get the user ID and Search date
            userId = User.Identity.GetUserId();
            var userExpenses = _context.Expenses.SingleOrDefault(u => u.UserId.Equals(userId) && u.Date == searchDate);

            // For old expenses query the result from DB
            if(userExpenses != null)
                return View(userExpenses);

            // Create new record for the new expense
            var newExpense = new Expense
            {
                Date = searchDate,
                UserId = userId
            };
            
            _context.Expenses.Add(newExpense);
            _context.SaveChanges();

            return View(newExpense);
            
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult UpdateExpenses(Expense expense)
        {
            var expensesInDb = _context.Expenses.SingleOrDefault(e => e.Id == expense.Id && e.Date == expense.Date);

            expensesInDb.Food += expense.Food;
            expensesInDb.Clothing += expense.Clothing;
            expensesInDb.Electronics += expense.Electronics;
            expensesInDb.Gasoline += expense.Gasoline;
            expensesInDb.Travel += expense.Travel;
            expensesInDb.Other += expense.Other;

            _context.SaveChanges();
            
            return RedirectToAction("EnterExpenses", "Home", new {id = expensesInDb.Id, searchDate= expensesInDb.Date});
        }

        [Authorize]
        public ActionResult StatHandler()
        {
            return View();
        }

        [Authorize]
        public ActionResult ShowStat(DateTime from, DateTime to)
        {
            userId = User.Identity.GetUserId();
            var period = _context.Expenses.Where(e => e.Date >= from && e.Date <= to && e.UserId.Equals(userId)).ToList();

            var statistics = new Statistics();

            var foodSum = 0.0;
            var clothingSum = 0.0;
            var electronicsSum = 0.0;
            var gasolineSum = 0.0;
            var travelSum = 0.0;
            var otherSum = 0.0;
            foreach (var expense in period)
            {
                foodSum += expense.Food;
                clothingSum += expense.Clothing;
                electronicsSum += expense.Electronics;
                gasolineSum += expense.Gasoline;
                travelSum += expense.Travel;
                otherSum += expense.Other;
            }

            statistics.Food = foodSum / period.Count;
            statistics.Clothing = clothingSum / period.Count;
            statistics.Electronics = electronicsSum / period.Count;
            statistics.Gasoline = gasolineSum / period.Count;
            statistics.Travel = travelSum / period.Count;
            statistics.Other = otherSum / period.Count;

            return View(statistics);
        }
    }
}