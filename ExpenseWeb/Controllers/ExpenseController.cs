using ExpenseWeb.Domain;
using ExpenseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpenseWeb.Controllers
{
    public class ExpenseController : Controller
    {
        private List<Expense> _expenses;

        public ExpenseController()
        {
            _expenses = new List<Expense>()
            {
                new Expense("Colruyt", 5, "Winkel"),
                new Expense("Kapper", 10, "Beauty"),
                new Expense("Test", 4, "Test"),
                new Expense("Resto", 55, "Genieten"),
                new Expense("Café", 105, new DateTime(2020,1,1), "Genieten"),
                new Expense("Pita", 10, new DateTime(2020,1,1), "Eten"),
                new Expense("Fruit", 8, new DateTime(2020,2,1), "Eten"),
            };
        }

        public IActionResult Index()
        {
            var vm = new ExpenseStatisticsViewModel();

            // Most & least expensive expense
            var leastExpensive = _expenses.OrderBy(x => x.Amount).First();
            var mostExpensive = _expenses.OrderBy(x => x.Amount).Last();

            vm.LeastExpensive = new ExpenseDetailViewModel()
            {
                Amount = leastExpensive.Amount,
                Date = leastExpensive.Date,
                Description = leastExpensive.Description
            };

            vm.MostExpensive = new ExpenseDetailViewModel()
            {
                Amount = mostExpensive.Amount,
                Description = mostExpensive.Description,
                Date = mostExpensive.Date
            };

            // Most expensive DAY
            var groupedExpensesPerDay = _expenses.GroupBy(x => x.Date.Date);
            var sumPerDay = new Dictionary<DateTime, decimal>();
            foreach (var group in groupedExpensesPerDay)
            {
                var sumFromGroup = group.ToList().Sum(expense => expense.Amount);
                sumPerDay.Add(group.Key, sumFromGroup);
            }

            var mostExpensiveDay = sumPerDay.OrderByDescending(x => x.Value).First();
            vm.MostExpensiveDay = (mostExpensiveDay.Key, mostExpensiveDay.Value);

            // Expenses per month
            var groupedExpensesPerMonth = _expenses.GroupBy(expense => new { expense.Date.Month, expense.Date.Year });
            var sumPerMonth = new Dictionary<string, decimal>();
            foreach(var group in groupedExpensesPerMonth)
            {
                var sumFromMonth = group.ToList().Sum(x => x.Amount);
                sumPerMonth.Add($"{group.Key.Month}/{group.Key.Year}", sumFromMonth);
            }
            vm.SumPerMonth = sumPerMonth;

            // Most & least expensive category
            var groupedCategories = _expenses.GroupBy(expense => expense.Category);
            var sumPerCategory = new Dictionary<string, decimal>();
            foreach(var group in groupedCategories)
            {
                var sumPerGroupedCategory = group.ToList().Sum(x => x.Amount);
                sumPerCategory.Add(group.Key, sumPerGroupedCategory);
            }

            var mostExpensiveCat = sumPerCategory.OrderBy(x => x.Value).Last();
            var leastExpensiveCat = sumPerCategory.OrderBy(x => x.Value).First();

            vm.LeastExpensiveCategory = (leastExpensiveCat.Key, leastExpensiveCat.Value);
            vm.MostExpensiveCategory = (mostExpensiveCat.Key, mostExpensiveCat.Value);

            return View();
        }
    }
}
