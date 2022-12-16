using DataAccess.Implementation;
using DataAccess.Model;
using GenericMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GenericMVC.Controllers
{
    public class HomeController : Controller
    {
        Breed breed = new Breed();
        GenericRepositoryImplementation<Breed> a = new GenericRepositoryImplementation<Breed>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Welcome(int numTimes = 2)
        {
            IEnumerable<Breed> c = a.GetAll();
            foreach (var item in c)
            {
                ViewBag.Message = item.Id + " " + item.Name;
            }

            ViewBag.NumTimes = numTimes;
            return View();
        }
        public IActionResult Index(int numTimes=1)
        {
            return View();
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