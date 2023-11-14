using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public interface ICatalogueService
    {
        public void CreateCard(out Card newCard, CatalogueItem cItem);
        public CatalogueItem? GetCatalogueItemById(uint id);
        public IEnumerable<CatalogueItem>GetCatalogueItems();
    }
}
