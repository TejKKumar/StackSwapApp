using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StackSwapApplication.Models;
using StackSwapApplication.Services;
using StackSwapApplication.Services.DataServices;
//using StackSwapApplication.Services.TradeServices;
//using StackSwapApplication.Services.UserManagment;
using StackSwapApplication.ViewModels;
using System.Diagnostics;

namespace StackSwapApplication.Controllers
{
    public class TradeController : Controller
    {
        private IDataService _repo;
        private IUserSession _userSession;
        private ITradeService _tradeService;
        private ICatalogueService _catalogueService;
        public TradeController(IDataService repo, IUserSession userSession, ITradeService tradeService, ICatalogueService catService)
        {
            _repo = repo;
            _userSession = userSession;
            _tradeService = tradeService;
            _catalogueService = catService;
        }


        [HttpGet]
        public IActionResult ViewRequests()
        {
            if (!_userSession.GetUserSession())
            {
                TempData["Error"] = "Invalid Username or Password";
                return RedirectToAction("Login", "User");
            }
            else
            {
                uint loggedId = _userSession.GetCurrentUser().Id;

                IEnumerable<Trade> tradeRequests = _repo.GetTrades.Where(t => t.SellerId == loggedId && t.IsAccepted == false);
                return View(tradeRequests);
            }

        }

        [HttpPost]
        public IActionResult ViewRequests(uint? Id)
        {
            return Id != null || Id != 0 ? RedirectToAction("ProcessTrade", "Trade", new { Id = Id }) : View();

        }

        [HttpGet]
        public IActionResult ProcessTrade(uint Id)
        {
            Trade trade = _repo.GetTrades.Single(t => t.Id == Id);
            TradeUser Me = _repo.GetUsers.Single(u => u.Id == trade.SellerId);
            TradeUser Bidder = _repo.GetUsers.Single(u => u.Id == trade.BuyerId);

            List<Card> MyCards = new List<Card>();
            List<Card> BidderCards = new List<Card>();

            trade.buyerCardsInfo.ForEach(bc =>
            {
                var Card = _repo.GetCards.Single(c => c.Id == bc.CardId);
                BidderCards.Add(Card);
            });

            trade.sellerCardsInfo.ForEach(sc =>
            {
                var Card = _repo.GetCards.Single(c => c.Id == sc.CardId);
                MyCards.Add(Card);
            });

            TradeViewModel vm = new TradeViewModel()
            {
                Trade = trade,
                Me = Me,
                Bidder = Bidder,
                MyCards = MyCards.AsEnumerable(),
                BidderCards = BidderCards.AsEnumerable(),
            };


            return View(vm);
        }

        [HttpGet]
        public  IActionResult ViewMyCards()
        {
            if (!_userSession.GetUserSession())
            {
                TempData["Error"] = "Invalid Username or Password";
                return RedirectToAction("Login", "User");
            }
            else
            {
                TradeUser u = _userSession.GetCurrentUser();

                IEnumerable<Card> Cards = _repo.GetCards.Where(c => c.OwnerID == u.Id).AsEnumerable();

                ViewBag.MyCards = Cards;

                return View();  
            }
        }

        [HttpGet]
        public IActionResult AcceptTrade(uint Id)
        {
            AcceptTradeViewModel vm = null;
            if (Id != null || Id != 0)
            {
                vm = _tradeService.AcceptTrade(Id);
            }


            return View(vm);


        }

        [HttpGet]
        public IActionResult RejectTrade(uint Id)
        {
            RejectTradeViewModel vm = null;
            if (Id != null || Id != 0)
            {
                vm = _tradeService.RejectTrade(Id);
            }

            return View(vm);

        }

        public IActionResult Index()
        {
            if (!_userSession.GetUserSession())
            {
                TempData["Error"] = "Invalid Username or Password";
                return RedirectToAction("Login", "User");
            }
            else
            {
                uint? id = _userSession.GetCurrentUser().GetId;

                if(id != null)
                {
                   TradeUser? u = _repo.GetUsers.SingleOrDefault(u => u.Id == id);
                    var c = _catalogueService.GetCatalogueItems().Take(5);
                    ViewBag.Catalogue = c;
                   return View(u);
                }
                else
                {
                    return RedirectToAction("Login", "User");
                } 
                   
                
            }
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
            var loggedUser = _userSession.GetCurrentUser();
            if (loggedUser != null)
            {
                uint loggedId = loggedUser.Id;
                var userList = _repo.GetUsers.Where(u => u.Id != loggedId);
                return View(userList);
            }

            else
            {
                return RedirectToAction("Login", "User");
            }
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
            vm.Seller = Seller;
            List<Card> SellerCards = _repo.GetCards.Where(c => c.OwnerID == Seller.Id && c.Available == true).ToList();

            SellerCards.ForEach(c =>
            {
                CardCheckBox check = new CardCheckBox()
                {
                    Card = c,
                    CardId = c.Id,

                };
                vm.SellerCards.Add(check);
            });

            //vm.BCards = vm.BuyerCards.AsEnumerable();


            TradeUser? Buyer = _userSession.GetCurrentUser();
            List<Card> BuyerCards = _repo.GetCards.Where(c => c.OwnerID == Buyer.Id && c.Available == true).ToList();

            vm.Buyer = Buyer;

            BuyerCards.ForEach(c =>
            {
                CardCheckBox check = new CardCheckBox()
                {
                    Card = c,
                    CardId = c.Id,
                };
                vm.BuyerCards.Add(check);
            });

           // vm.SCards = vm.SellerCards.AsEnumerable();

            
            
            return View(vm);
        }

        [HttpPost]
        public IActionResult ViewUserCards(ViewCardsVM vm)
        {
            
            List<uint> buyerCardIDs = new List<uint>();
            List<uint> sellerCardIDs = new List<uint>();

            vm.BuyerCards.ForEach(c =>
            {
                if (c.IsChecked)
                {
                    buyerCardIDs.Add(c.CardId);
                }

            });

            vm.SellerCards.ForEach(c =>
            {
                if (c.IsChecked)
                {
                    sellerCardIDs.Add(c.CardId);

                }
            });
            Trade newTrade = _tradeService.MakeTradeRequest(vm.Buyer.Id, vm.Seller.Id,buyerCardIDs ,sellerCardIDs);

            return RedirectToAction("RequestSent", "Trade", new { tradeID = newTrade.Id });
        }

        public IActionResult RequestSent(uint tradeID)
        {
            List<Card> Offered = new List<Card>();
            List<Card> Requested = new List<Card>();
            

            Trade t = _repo.GetTrades.Single(t=> t.Id == tradeID);
            TradeUser u = _repo.GetUsers.Single(u => u.Id == t.BuyerId);

            t.buyerCardsInfo.ForEach(b =>
            {
                var Card = _repo.GetCards.Single(c => c.Id == b.CardId);
                Offered.Add(Card);
            });

            t.sellerCardsInfo.ForEach(s =>
            {
                var Card = _repo.GetCards.Single(t=> t.Id ==  s.CardId); 
                Requested.Add(Card);

            });
            
            ViewBag.Offered = Offered;
            ViewBag.Requested = Requested;
            ViewBag.Me = u.Username;
            return View(); 
        }

    }
}
