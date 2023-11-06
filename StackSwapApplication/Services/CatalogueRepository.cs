using StackSwapApplication.Models;

namespace StackSwapApplication.Services
{
    public class CatalogueRepository : ICatalogueService
    {
        public static List<CatalogueItem> catalogueItems = new List<CatalogueItem>()
        {
            new CatalogueItem("Ash",Tier.Tier1,250,890,1200),
            new CatalogueItem("Bellrus", Tier.Tier1, 300, 150, 2300),
            new CatalogueItem("GraveWard", Tier.Tier1, 720, 1300, 900),
            new CatalogueItem("D3=N", Tier.Tier1, 320, 450, 900),
            new CatalogueItem("Raven", Tier.Tier1, 1200, 1400, 60),

            new CatalogueItem("Ash",Tier.Tier2,300,890,1200),
            new CatalogueItem("Bellrus", Tier.Tier2, 350, 150, 2300),
            new CatalogueItem("GraveWard", Tier.Tier2, 770, 1300, 900),
            new CatalogueItem("D3=N", Tier.Tier2, 370, 450, 900),
            new CatalogueItem("Raven", Tier.Tier2, 1250, 1400, 60),

            new CatalogueItem("Ash",Tier.Tier3,350,890,1200),
            new CatalogueItem("Bellrus", Tier.Tier3, 400, 150, 2300),
            new CatalogueItem("GraveWard", Tier.Tier3, 820, 1300, 900),
            new CatalogueItem("D3=N", Tier.Tier3, 420, 450, 900),
            new CatalogueItem("Raven", Tier.Tier3, 1300, 1400, 60),

            new CatalogueItem("Ash",Tier.Tier4,400,890,1200),
            new CatalogueItem("Bellrus", Tier.Tier4, 450, 150, 2300),
            new CatalogueItem("GraveWard", Tier.Tier4, 870, 1300, 900),
            new CatalogueItem("D3=N", Tier.Tier4, 470, 450, 900),
            new CatalogueItem("Raven", Tier.Tier3, 1350, 1400, 60),

            new CatalogueItem("Ash",Tier.Tier5,450,890,1200),
            new CatalogueItem("Bellrus", Tier.Tier5, 500, 150, 2300),
            new CatalogueItem("GraveWard", Tier.Tier5, 920, 1300, 900),
            new CatalogueItem("D3=N", Tier.Tier5, 520, 450, 900),
            new CatalogueItem("Raven", Tier.Tier5, 1400, 1400, 60),
        };


        public void CreateCard(out Card newCard, CatalogueItem cItem)
        {
            newCard = new Card
            {
                Champion = cItem.GetChampion,
                CardTier = cItem.GetTier,
                Damage = cItem.GetDamage,
                Magic = cItem.GetMagic,
                Health = cItem.GetHealth,
            };
        }

        public IEnumerable<CatalogueItem> GetCatalogueItems()
        {
            return catalogueItems.AsEnumerable();
        }
    }
}
