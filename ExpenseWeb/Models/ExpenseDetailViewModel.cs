using System;

namespace ExpenseWeb.Models
{
    public class ExpenseDetailViewModel
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
