using StackSwapApplication.Models;
using StackSwapApplication.Models.BaseEntities;

namespace StackSwapApplication.Services
{
    public interface IDataService
    { 
      public IQueryable<User> GetUsers { get; }

        public void AddEntity(BaseEntity entity);

        public void RemoveEntity(BaseEntity entity);

        public void UpdateEntity(BaseEntity entity);
    }
}
