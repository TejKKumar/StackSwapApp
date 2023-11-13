
using Microsoft.AspNetCore.Identity;
using StackSwapApplication.Models;
using StackSwapApplication.ViewModels;

namespace StackSwapApplication.Services
{
    public interface IUserSession
    {
        public bool UserLoginInfo(LoginVM loginVM);
        public bool GetUserSession();
        public TradeUser? GetCurrentUser();

    }
}
