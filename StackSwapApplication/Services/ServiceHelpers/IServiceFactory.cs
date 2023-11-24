using StackSwapApplication.Services.DataServices;

namespace StackSwapApplication.Services.ServiceHelpers
{
    public interface IServiceFactory
    {
        void GetService<S>(out IDataService service) where S : IDataService;
    }
}
