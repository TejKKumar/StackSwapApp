using StackSwapApplication.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Transactions;

namespace StackSwapApplication.Services
{
    public class UserSessionRepo : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UserSessionRepo(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
           // _loginValidationService = loginValidationService;

        }
        bool IUserSession.UserLoginInfo(LoginVM loginVM)
        {
            
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null && loginVM.Username != null)
                {

                    ISession session = httpContext.Session;
                    session.SetString("UserName", loginVM.Username);

                    return true;
                }
            
            return false;
        }
        bool IUserSession.GetUserSession()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext != null)
            {
                ISession session = httpContext.Session;

                if (session.GetString("UserName") != null)
                {
                    return true;
                }


            }
            return false;

        }
    }
}

