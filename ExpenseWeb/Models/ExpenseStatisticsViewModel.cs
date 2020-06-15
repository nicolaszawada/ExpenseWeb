using System;
using System.Collections.Generic;

namespace ExpenseWeb.Models
{
    public class ExpenseStatisticsViewModel
    {
        public ExpenseDetailViewModel MostExpensive { get; set; }
        public ExpenseDetailViewModel LeastExpensive { get; set; }
        public (DateTime day, decimal sum) MostExpensiveDay { get; set; }
        public Dictionary<string, decimal> SumPerMonth { get; set; }
        public (string category, decimal sum) MostExpensiveCategory { get; set; }
        public (string category, decimal sum) LeastExpensiveCategory { get; set; }
    }
}
