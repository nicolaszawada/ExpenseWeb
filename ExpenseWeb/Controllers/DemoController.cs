using ExpenseWeb.Models;
using ExpenseWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseWeb.Controllers
{
    public class DemoController : Controller
    {
        private readonly IScopedService _scopedService;
        private readonly ITransientService _transientService;
        private readonly ISingletonService _singletonService;

        public DemoController(IScopedService scopedService, ITransientService transientService, 
            ISingletonService singletonService)
        {
            _scopedService = scopedService;
            _transientService = transientService;
            _singletonService = singletonService;
        }

        public IActionResult Index()
        {
            DemoIndexViewModel vm = new DemoIndexViewModel()
            {
                ScopedDate = _scopedService.ToonDatum(),
                SingletonDate = _singletonService.ToonDatum(),
                TransientDate = _transientService.ToonDatum()
            };

            return View(vm);
        }
    }
}
