/*using StackSwapApplication.Data;
using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    
    public class UserRepository : IUserService
    {
        public TradeContext _tradeContext;

        public UserRepository(TradeContext tradeContext)
        {
            _tradeContext = tradeContext;
        }

        public string GetUserName(uint ownerId)
        {
            if (ownerId != null)
            {
                return _tradeContext.Users.Where(u => u.Id == ownerId).Select(u => u.Name).FirstOrDefault();
            }
            

        }
    }
}
*/

