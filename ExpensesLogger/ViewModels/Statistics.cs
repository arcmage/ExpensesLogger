using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpensesLogger.ViewModels
{
    public class Statistics
    {
        public double Food { get; set; }
        public double Clothing { get; set; }
        public double Electronics { get; set; }
        public double Gasoline { get; set; }
        public double Travel { get; set; }
        public double Other { get; set; }
    }
}