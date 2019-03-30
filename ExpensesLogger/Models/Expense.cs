using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpensesLogger.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public ExpenseType Type { get; set; }
        public int ExpenseTypeId { get; set; }  
        public double Total { get; set; }
    }
}