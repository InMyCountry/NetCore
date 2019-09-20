using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Services.Services
{
    public abstract class RepositoryBase<TEntity, TKey> where TEntity : class
    {
        private DbContext dataContext;
        private readonly DbSet<TEntity> dbset;

        protected RepositoryBase(DbContext dbContext)
        {
            dataContext = dbContext;
            dbset = dataContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            dbset.Add(entity);
        }

        //新增方法
        public virtual void AddAll(IEnumerable<TEntity> entities)
        {
            dbset.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        //新增方法
        public virtual void Update(IEnumerable<TEntity> entities)
        {
            foreach (TEntity obj in entities)
            {
                dbset.Attach(obj);
                dataContext.Entry(obj).State = EntityState.Modified;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> objects = dbset.Where<TEntity>(where).AsEnumerable();
            dbset.RemoveRange(objects);
        }

        //新增方法
        public virtual void DeleteAll(IEnumerable<TEntity> entities)
        {
            dbset.RemoveRange(entities);
        }

        public virtual void Clear()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(TKey id)
        {
            return dbset.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbset.ToList();
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAllLazy()
        {
            return dbset;
        }

    }
}
