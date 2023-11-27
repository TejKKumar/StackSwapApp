using StackSwapApplication.Data;
using StackSwapApplication.Models;
using StackSwapApplication.Services.DataServices;
using StackSwapApplication.ViewModels;

namespace StackSwapApplication.Services
{
    public class AuthenticationRepository : IUserAuthenticationService
    {

        private readonly IUserSession _userSession;
        private readonly IDataService _dataService;

        public AuthenticationRepository(IDataService dataService, IUserSession userSession)
        {
            _dataService = dataService;
            _userSession = userSession; 
        }


        public void Register(RegisterVM registerVM)
        {
            TradeUser newUser = new()
            {
                Username = registerVM.Username,
                Name = registerVM.Name,
                Email = registerVM.Email,
                Password = registerVM.Password,
                Credits = 1000,
                Cards = new List<Card>()
            };

            _dataService.AddEntity(newUser);
            _dataService.SaveDatabaseChanges();


        }

        public bool Login(LoginVM loginVM)
        {
            var Users = from m in _dataService.GetUsers select m;
            var user = Users.FirstOrDefault(s => s.Username == loginVM.Username);

            if (user != null && user.Password == loginVM.Password && user.Username != null)
            {
                if(_userSession.UserLoginInfo(loginVM))
                {
                    return true;
                }
                else
                {
                    return false;
                }   
            }
            else
            {
                return false;
            }
        }

    }
}
