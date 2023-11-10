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
        private ICatalogueService _catRepo;

        public HomeController(IDataService repo, ICatalogueService catRepo)
        {
            this._repo = repo;
            this._catRepo = catRepo;
        }

        public IActionResult Index()
        {
            TestDataVM vm = new TestDataVM();
            vm.testCards = _repo.GetCards.AsEnumerable();
            vm.testUsers = _repo.GetUsers.AsEnumerable();
            vm.testCatalogueItems = _catRepo.GetCatalogueItems();
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


        public void MakePurchace(CatalogueItem cItem, TradeUser purchaser)
        {
            Card newCard;
            
            _catRepo.CreateCard(out newCard, cItem);

            //Pass newCard and purchaser to the purchase transaction service 
            //Inject code here 

            //this saves the changes 
            _repo.UpdateEntity(purchaser);
            
        }
    }
}