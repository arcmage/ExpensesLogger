using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpensesLogger.Models
{
    public class ExpenseType
    {
        public int Id { get; set; }
        public string[] Items = {"Food","Clothing", "Electronics", "Gasoline", "Travel", "Other"};
    }
}