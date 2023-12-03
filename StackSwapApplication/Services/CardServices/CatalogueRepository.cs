using StackSwapApplication.Models;

//by Tejas 
namespace StackSwapApplication.Services
{
    
    public class CatalogueRepository : ICatalogueService
    {
        //Static list of catalogue items which are not stored on the database 
        public static List<CatalogueItem> catalogueItems = new List<CatalogueItem>()
        {
            new CatalogueItem(1,"Ash",Tier.Tier1,250,890,1200,25),
            new CatalogueItem(2,"Bellrus", Tier.Tier1, 300, 150, 2300, 25),
            new CatalogueItem(3,"GraveWard", Tier.Tier1, 720, 1300, 900, 25),
            new CatalogueItem(4,"D3=N", Tier.Tier1, 320, 450, 900, 25),
            new CatalogueItem(5,"Raven", Tier.Tier1, 1200, 1400, 60, 25),

            new CatalogueItem(6,"Ash",Tier.Tier2,300,890,1200, 50),
            new CatalogueItem(7,"Bellrus", Tier.Tier2, 350, 150, 2300, 50),
            new CatalogueItem(8,"GraveWard", Tier.Tier2, 770, 1300, 900, 50),
            new CatalogueItem(9,"D3=N", Tier.Tier2, 370, 450, 900, 50),
            new CatalogueItem(10,"Raven", Tier.Tier2, 1250, 1400, 60, 50),

            new CatalogueItem(11,"Ash",Tier.Tier3,350,890,1200, 75),
            new CatalogueItem(12,"Bellrus", Tier.Tier3, 400, 150, 2300, 75),
            new CatalogueItem(13,"GraveWard", Tier.Tier3, 820, 1300, 900, 75),
            new CatalogueItem(14,"D3=N", Tier.Tier3, 420, 450, 900, 75),
            new CatalogueItem(15,"Raven", Tier.Tier3, 1300, 1400, 60, 75),

            new CatalogueItem(16,"Ash",Tier.Tier4,400,890,1200, 100),
            new CatalogueItem(17,"Bellrus", Tier.Tier4, 450, 150, 2300, 100),
            new CatalogueItem(18,"GraveWard", Tier.Tier4, 870, 1300, 900, 100),
            new CatalogueItem(19,"D3=N", Tier.Tier4, 470, 450, 900, 100),
            new CatalogueItem(20,"Raven", Tier.Tier3, 1350, 1400, 60, 100),

            new CatalogueItem(21,"Ash",Tier.Tier5,450,890,1200, 150),
            new CatalogueItem(22,"Bellrus", Tier.Tier5, 500, 150, 2300, 150),
            new CatalogueItem(23,"GraveWard", Tier.Tier5, 920, 1300, 900, 150),
            new CatalogueItem(24,"D3=N", Tier.Tier5, 520, 450, 900, 150),
            new CatalogueItem(25,"Raven", Tier.Tier5, 1400, 1400, 60, 150),
        };

        //
        /// <summary>
        /// Method that creates instantiates a card based on a selected catalogue item.
        /// </summary>
        /// <param name="newCard"></param>
        /// <param name="cItem"></param>
        public void CreateCard(out Card newCard, CatalogueItem cItem)
        {
            newCard = new Card
            {
                Champion = cItem.Champion,
                CardTier = cItem.Tier,
                Damage = cItem.Damage,
                Magic = cItem.Magic,
                Health = cItem.Health,
            };
        }

        //
        /// <summary>
        /// Get method for a CatalogueItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CatalogueItem? GetCatalogueItemById(uint id)
        {
            return catalogueItems.Find(c => c.Id == id);
        }

        //
        /// <summary>
        /// Get all the catalogue items 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CatalogueItem> GetCatalogueItems()
        {
            return catalogueItems.AsEnumerable();
        }
    }
}
