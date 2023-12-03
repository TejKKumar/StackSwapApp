using StackSwapApplication.Data;
using StackSwapApplication.Models;
using StackSwapApplication.Services.DataServices;
using StackSwapApplication.ViewModels;

//by Deepthanshu 
namespace StackSwapApplication.Services
{
    public class AuthenticationRepository : IUserAuthenticationService
    {

        private readonly IUserSession _userSession;
        private readonly IDataService _dataService;

        /// <summary>
        /// Constructor for the AuthenticationRepository
        /// </summary>
        /// <param name="dataService"></param>
        /// <param name="userSession"></param>
        public AuthenticationRepository(IDataService dataService, IUserSession userSession)
        {
            _dataService = dataService;
            _userSession = userSession; 
        }


        /// <summary>
        /// Register method for creating a new user
        /// </summary>
        /// <param name="registerVM"></param>
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

        /// <summary>
        /// Login method for authenticating user 
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>
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
