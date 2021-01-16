using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.Repository
{
    interface IRepository<TEntity> where TEntity : class
    {
        //POST
        void Create(TEntity entity);

        //GET
        ICollection<TEntity> GetAllEntities();

        //GET
        ICollection<TEntity> GetEntitiesForFilter(Predicate<TEntity> predicate);

        //GET
        TEntity GetForId(int id);

        //PUT
        void Updata(TEntity entity);

        //DELETE
        void Delete(int id);
    }
}
