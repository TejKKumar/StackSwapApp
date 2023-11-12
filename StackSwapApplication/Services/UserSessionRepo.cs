using StackSwapApplication.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Transactions;
using StackSwapApplication.Models;
using StackSwapApplication.Data;

namespace StackSwapApplication.Services
{
    public class UserSessionRepo : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TradeContext _tradeContext;


        public UserSessionRepo(IHttpContextAccessor httpContextAccessor, IDataService repo, TradeContext tradeContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _tradeContext = tradeContext;
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

        public TradeUser? GetCurrentUser()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            TradeUser? user = null;

            if (httpContext != null)
            {
                ISession session = httpContext.Session;

                if (session.GetString("UserName") != null)
                {
                    user = _tradeContext.Users.FirstOrDefault(u => u.Username == session.GetString("UserName"));
                }
            }
            return user;
        }
    }
}

