using StackSwapApplication.Data;
using StackSwapApplication.Models;
using StackSwapApplication.Services.DataServices;
using StackSwapApplication.ViewModels;

namespace StackSwapApplication.Services
{
    public class AuthenticationRepository : IUserAuthenticationService
    {

        private readonly IDataService _dataService;

        public AuthenticationRepository(IDataService dataService)
        {
            _dataService = dataService;
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

        }

    }
}
