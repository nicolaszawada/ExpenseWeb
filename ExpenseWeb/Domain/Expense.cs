using System;

namespace ExpenseWeb.Domain
{
    public class Expense
    {
        public Expense(string description, decimal amount) : this(description, amount, DateTime.Now)
        {
        }

        public Expense(string description, decimal amount, DateTime date)
        {
            Description = description;
            Amount = amount;
            Date = date;
        }

        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
