using StackSwapApplication.ViewModels;
//By Deepthanshu 
namespace StackSwapApplication.Services
{
    public interface IUserAuthenticationService
    { 
        public void Register(RegisterVM registerVM);

        public bool Login(LoginVM loginVM);

        

    }
}
