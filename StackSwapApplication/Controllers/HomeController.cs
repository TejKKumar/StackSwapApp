using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Models;
using StackSwapApplication.Services;
using StackSwapApplication.ViewModels;
using System.Diagnostics;

namespace StackSwapApplication.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private IDataService _repo;

        public HomeController(IDataService repo)
        {
            this._repo = repo;
        }

        public IActionResult Index()
        {
            TestDataVM vm = new TestDataVM();
            vm.testCards = _repo.GetCards.AsEnumerable();
            vm.testUsers = _repo.GetUsers.AsEnumerable();
            return View(vm);
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

        public List<Card> SeeTestCards()
        {
            return _repo.GetCards.ToList();
        }

        public List<TradeUser> SeeTestUsers() 
        { 
            return _repo.GetUsers.ToList(); 
        }
    }
}