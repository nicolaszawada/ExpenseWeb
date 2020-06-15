using ExpenseWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseWeb.Models
{
    public class ExpenseStatisticsViewModel
    {
        public ExpenseDetailViewModel MostExpensive { get; set; }

        public ExpenseDetailViewModel LeastExpensive { get; set; }


        public decimal SumMostExpensiveDay { get; set; }
        public DateTime DateMostExpensiveDay { get; set; }
    }
}
