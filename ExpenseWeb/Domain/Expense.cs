using System;

namespace ExpenseWeb.Domain
{
    public class Expense
    {
        public Expense(string description, decimal amount, string category) : this(description, amount, DateTime.Now, category)
        {
        }

        public Expense(string description, decimal amount, DateTime date, string category)
        {
            Description = description;
            Amount = amount;
            Date = date;
            Category = category;
        }

        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
    }
}
