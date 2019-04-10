using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpensesLogger.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Food { get; set; }
        public double Clothing { get; set; }
        public double Electronics { get; set; }
        public double Gasoline { get; set; }
        public double Travel { get; set; }
        public double Other { get; set; }
        public string UserId { get; set; }
    }
}