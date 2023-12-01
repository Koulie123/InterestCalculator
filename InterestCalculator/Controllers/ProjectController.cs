using Microsoft.AspNetCore.Mvc;

namespace InterestCalculator.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Project1()
        {
            return View();
        }
    }
}
