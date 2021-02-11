using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //POST
        void Create(TEntity entity);

        //GET
        IList<TEntity> GetAllEntities();

        //GET
        IList<TEntity> GetEntitiesForFilter(Predicate<TEntity> predicate);

        //GET
        TEntity GetForId(Guid id);

        //PUT
        Task Update(TEntity entity, Guid id);

        //DELETE
        void Delete(Guid id);
    }
}
