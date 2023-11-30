using InterestCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InterestCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index()
        {
            var viewModel = new CompoundInterestModelYear();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(CompoundInterestModelYear viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.SimplenterestCalculationTotal();
            }
            return View(viewModel);
        }

        public IActionResult CompoundInterest()
        {
            return View(new CompoundInterestViewModel());
        }
        [HttpPost]
        public IActionResult CompoundInterest(CompoundInterestViewModel viewModel)
        {
            viewModel.CalculateCompoundInterest();
            return View(viewModel);
        }


        public IActionResult SimpleInterest()
        {
            var viewModel = new SimpleInterestViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SimpleInterest(SimpleInterestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.SimpleInterestCalculation();
            }
            return View(viewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
