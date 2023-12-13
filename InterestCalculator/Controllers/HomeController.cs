using InterestCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc.Rendering;
using static InterestCalculator.Models.CompoundInterestViewModel;

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
            var viewModel = new CompoundInterestViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(CompoundInterestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.CalculateCompoundInterest();
            }
            return View(viewModel);
        }

        public IActionResult CompoundInterest()
        {
            var frequencyOptions = Enum.GetValues(typeof(ContributionFrequency))
                                       .Cast<ContributionFrequency>()
                                       .Select(f => new SelectListItem
                                       {
                                           Text = f.ToString(),
                                           Value = ((int)f).ToString()
                                       })
                                       .ToList();

            var viewModel = new CompoundInterestViewModel
            {
                FrequencyOptions = new SelectList(frequencyOptions, "Value", "Text")
            };

            return View(viewModel);
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


        public IActionResult About()
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
