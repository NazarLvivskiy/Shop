using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> GetEntitiesForFilter(Predicate<TEntity> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity GetForId(int id)
        {
            throw new NotImplementedException();
        }

        public void Updata(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
