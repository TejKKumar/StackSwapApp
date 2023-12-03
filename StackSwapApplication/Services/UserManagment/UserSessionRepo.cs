using StackSwapApplication.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Transactions;
using StackSwapApplication.Models;
using StackSwapApplication.Data;
using StackSwapApplication.Services.DataServices;

//Deepthanshu 
namespace StackSwapApplication.Services
{
    public class UserSessionRepo : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDataService _dataService;

        /// <summary>
        /// Constructor for the UserSessionRepo 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="dataService"></param>
        public UserSessionRepo(IHttpContextAccessor httpContextAccessor, IDataService dataService)
        {
            _httpContextAccessor = httpContextAccessor;
            _dataService = dataService;

        }

        /// <summary>
        /// Method for verifying users 
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Gets user session information 
        /// </summary>
        /// <returns>Boolean</returns>
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

        /// <summary>
        /// Gets the currently logged in user
        /// </summary>
        /// <returns>a TradeUser</returns>
        public TradeUser? GetCurrentUser()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            TradeUser? user = null;

            if (httpContext != null)
            {
                ISession session = httpContext.Session;

                if (session.GetString("UserName") != null)
                {
                    user = _dataService.GetUsers.FirstOrDefault(u => u.Username == session.GetString("UserName"));
                }
            }
            return user;
        }

        /// <summary>
        /// Destroys the session 
        /// </summary>
        public void logout()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext != null)
            {
                ISession session = httpContext.Session;

                if (session.GetString("UserName") != null)
                {
                    session.Clear();
                    httpContext.Session.Clear();
                    httpContext.Session.Remove("UserName"); 
                    httpContext.Response.Cookies.Delete(".AspNetCore.Session");

                }
            }
        }
    }
}

