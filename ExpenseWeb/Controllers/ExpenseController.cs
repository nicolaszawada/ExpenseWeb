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
                new Expense("Colruyt", 5),
                new Expense("Kapper", 10),
                new Expense("Test", 4),
                new Expense("Resto", 55),
                new Expense("Café", 105, new DateTime(2020,1,1)),
                new Expense("Pita", 10, new DateTime(2020,1,1)),
                new Expense("Fruit", 8, new DateTime(2020,2,1)),
            };
        }

        public IActionResult Index()
        {
            var ordered = _expenses.OrderBy(x => x.Amount);

            var max = ordered.Last();
            var least = ordered.First();


            ExpenseStatisticsViewModel vm = new ExpenseStatisticsViewModel();

            vm.MostExpensive = new ExpenseDetailViewModel()
            {
                Amount = max.Amount,
                Date = max.Date,
                Description = max.Description
            };

            vm.LeastExpensive = new ExpenseDetailViewModel()
            {
                Amount = least.Amount,
                Date = least.Date,
                Description = least.Description
            };

            var groupedExpensesPerDay = _expenses.GroupBy(x => x.Date.Date);

            var sumPerDay = new Dictionary<DateTime, decimal>();
            foreach(var group in groupedExpensesPerDay)
            {
                var sumFromGroup = group.ToList().Sum(x => x.Amount);
                sumPerDay.Add(group.Key, sumFromGroup);
            }

            var mostExpensiveDay = sumPerDay.OrderByDescending(x => x.Value).First();

            vm.DateMostExpensiveDay = mostExpensiveDay.Key;
            vm.SumMostExpensiveDay = mostExpensiveDay.Value;


            var groupedExpensesPerMonth = _expenses.GroupBy(x => new { x.Date.Month, x.Date.Year });

            return View();
        }
    }
}
