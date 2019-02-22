﻿using AutoMapper;
using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Repositories
{
    public class BaseRepository<TModel>:IBaseRepository<TModel> where TModel:class
    {
        protected DbContext dbContext;
        protected DbSet<TModel> dbSet;

        protected UnitOfWork unitOfWork;

        public BaseRepository(DbContext context, UnitOfWork unitOfWork)
        {
            this.dbContext = context;
            this.dbSet = dbContext.Set<TModel>();
            this.unitOfWork = unitOfWork;
        }

        //public System.Collections.Generic.IEnumerable<TModel> GetAll1()
        //{
        //    var query = from t in dbSet select t;
        //    return query;
        //}

        //public async Task<TModel> GetByIDAsync(Guid id)
        //{
        //    return await dbSet.FindAsync(id);
        //}

        public TModel GetByID(Guid id)
        {
            return dbSet.Find(id);
        }

        public void Create(TModel model)
        {
            dbSet.Add(model);
        }

        public void Update(TModel model)
        {
            dbSet.Attach(model);
            dbContext.Entry(model).State = EntityState.Modified;
        }
        public void Delete(TModel model)
        {
            if (dbContext.Entry(model).State == EntityState.Detached)
            {
                dbSet.Attach(model);
            }
            dbSet.Remove(model);
        }

        //public virtual void Upsert<TModel>(TModel entity)
        //    where TModel : class, IEntity
        //{
        //    if (entity == null) throw new System.NullReferenceException("Value cannot be null");

        //    TModel existingEntity = dbContext.Set<TModel>().Find(entity.ID);

        //    if (existingEntity == null)
        //    {
        //        dbContext.Set<TModel>().Add(entity);
        //    }
        //    else
        //    {
        //        Mapper.Map(entity, existingEntity);
        //    }
        //    dbContext.SaveChanges();
        //}

        public TModel[] GetAll()
        {
            return dbSet.ToArray();
        }
    }
}
