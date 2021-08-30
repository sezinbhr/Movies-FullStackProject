using System;
using System.Collections.Generic;
using System.Text;
using Movies.Models;

namespace Movies.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity, new()
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);

        IList<TEntity> GetWithCriteria(Func<TEntity, bool> criteria);

        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
