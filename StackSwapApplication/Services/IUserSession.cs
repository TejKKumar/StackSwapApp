
using Microsoft.AspNetCore.Identity;
using StackSwapApplication.ViewModels;

namespace StackSwapApplication.Services
{
    public interface IUserSession
    {
        public bool UserLoginInfo(LoginVM loginVM);

    }
}
