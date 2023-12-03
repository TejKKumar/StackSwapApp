using StackSwapApplication.Services.DataServices;

//By Tejas, a service generator which is not used of fully implemented 
namespace StackSwapApplication.Services.ServiceHelpers
{
    public interface IServiceFactory
    {
        void GetService<S>(out IDataService service) where S : IDataService;
    }
}
