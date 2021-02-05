﻿using Microsoft.EntityFrameworkCore;
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
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
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
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;

            entities.Remove(GetForId(id));

            Context.SaveChanges();
        }

        public ICollection<TEntity> GetAllEntities()
        {
            return entities.ToList();
        }

        public ICollection<TEntity> GetEntitiesForFilter(Predicate<TEntity> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity GetForId(Guid id)
        {
            return entities.Find(id);
        }

        public async Task Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
