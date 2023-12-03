
using Microsoft.AspNetCore.Identity;
using StackSwapApplication.Models;
using StackSwapApplication.ViewModels;

//By Deepthanshu
namespace StackSwapApplication.Services
{
    public interface IUserSession
    {
        public bool UserLoginInfo(LoginVM loginVM);
        public bool GetUserSession();
        public TradeUser? GetCurrentUser();
        public void logout();

    }
}
