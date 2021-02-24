﻿using Microsoft.EntityFrameworkCore;
using Shop.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.Repository
{
    public class IdentyRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ApplicationDbContext db;

        DbSet<TEntity> entities;

        public IdentyRepository(ApplicationDbContext applicationDbContext)
        {
            db = applicationDbContext;

            entities = db.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            entities.Add(entity);

            db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            entities.Remove(entities.Find(id));

            db.SaveChanges();
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

            await db.SaveChangesAsync();
        }
    }
}
