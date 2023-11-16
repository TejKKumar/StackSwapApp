using Microsoft.AspNetCore.Mvc;
using StackSwapApplication.Models;
using StackSwapApplication.Services;
using StackSwapApplication.ViewModels;

namespace StackSwapApplication.Controllers
{
    public class TradeController : Controller
    {
        public IDataService _repo;
        public IUserSession _userSession;   
       public TradeController(IDataService repo, IUserSession userSession)
        {
            _repo = repo;
            _userSession = userSession;
        }

        public IActionResult MakeTrade()
        {
            try
            {
                if (!_userSession.GetUserSession())
                {
                    TempData["Error"] = "Invalid Username or Password";
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    var cards = _repo.GetCards;
                    return View(cards);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "User");
            }

        }

        [HttpGet] //Get Method to get a view of all the users 
        public IActionResult ViewUsers() 
        {

            var userList = _repo.GetUsers;
            return View(userList);
        }

        [HttpPost] //Post action called to view a particular user that redirects to another view // This used to validate the user Id before redirecting
        public IActionResult ViewUsers(uint Id)
        {
            return Id != 0 ? RedirectToAction("ViewUserCards","Trade", new {Id = Id}) : View();
        }


        [HttpGet] //Gets The Page to View User Cards to Initiate a Trade
       public IActionResult ViewUserCards(uint Id)
        {
            ViewCardsVM vm = new ViewCardsVM();

            var Seller = _repo.GetUsers.Single(u => u.Id == Id);
            var SellerCards = _repo.GetCards.Where(c => c.OwnerID == Id).AsEnumerable();

            TradeUser? Buyer = _userSession.GetCurrentUser();
            var BuyerCards = _repo.GetCards.Where(c => c.Id == Seller.Id);

            vm.Buyer = Buyer;
            vm.BuyerCards = BuyerCards;

            vm.Seller = Seller;
            vm.SellerCards = SellerCards;
            return View(vm);
        }


    }
}
