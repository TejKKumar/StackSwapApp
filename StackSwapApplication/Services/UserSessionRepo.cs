using StackSwapApplication.ViewModels;
using Microsoft.AspNetCore.Http;

namespace StackSwapApplication.Services
{
    public class UserSessionRepo : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDataService _repo;

        public UserSessionRepo(IHttpContextAccessor httpContextAccessor, IDataService repo)
        {
            _httpContextAccessor = httpContextAccessor;
            _repo = repo;
        }
        bool IUserSession.UserLoginInfo(LoginVM loginVM)
        {
            var Users = from m in _repo.GetUsers select m;
            var User = Users.FirstOrDefault(s => s.Username == (loginVM.Username));
            if (User != null)
            {
                if (User.Password == loginVM.Password && User.Username != null)
                {
                    var httpContext = _httpContextAccessor.HttpContext;
                    if(httpContext != null)
                    {
                        ISession session = httpContext.Session;
                        session.SetString("UserName", User.Username);
                        return true;
                    }
                }
            }
            return false;


        }
    }
}
