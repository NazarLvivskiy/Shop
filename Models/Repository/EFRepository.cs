using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ShopContext Context;

        DbSet<TEntity> entities;

        public EFRepository(ShopContext shopContext)
        {
            Context = shopContext;
            //

            entities = Context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            entities.Add(entity);

            Context.SaveChanges();
        }

        public void Delete(Guid id)
        {

            entities.Remove(GetForId(id));

            Context.SaveChanges();
        }

        public IList<TEntity> GetAllEntities()
        {
            return entities.ToList();
        }

        public IList<TEntity> GetEntitiesForFilter(PaginationParameters pagination)
        {
            return GetAllEntities()
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToList();
        }

        public TEntity GetForId(Guid id)
        {
            return entities.Find(id);
        }

        public async Task Update(TEntity entity, Guid id)
        {
            Delete(id);

            Create(entity);

            await Context.SaveChangesAsync();
        }
    }
}
