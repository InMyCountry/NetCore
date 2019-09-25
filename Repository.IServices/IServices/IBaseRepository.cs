using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository.IServices.IServices
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        void Add(TEntity entity);
        void AddAll(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
        void DeleteAll(IEnumerable<TEntity> entities);
        void Clear();
        TEntity GetById(TKey Id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAllLazy();
        bool IsExist(Expression<Func<TEntity, bool>> where);
    }
}
