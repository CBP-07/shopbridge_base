using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public interface IRepository
    {
        IQueryable<T> AsQueryable<T>() where T : class, IEntity;
        IQueryable<T> Get<T>(params Expression<Func<T, object>>[] navigationProperties) where T : class, IEntity;
        IQueryable<T> Get<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties) where T : class, IEntity;
         Task<IEnumerable<T>> Get<T>() where T : class, IEntity;
         Task<int> Count<T>(Expression<Func<T, bool>> expression) where T : class, IEntity;
         Task<T> FirstOrDefault<T>(Expression<Func<T,bool>> selector) where T : class, IEntity;
         Task<bool> Delete<T>(Expression<Func<T,bool>> selector) where T: class, IEntity;
         Task<T> Add<T>(T entity) where T: class, IEntity;
         Task<T> Update<T,TId>(TId id,T entity) where T: class, IEntity;
         Task<bool> Exist<T>(Expression<Func<T, bool>> selector) where T : class, IEntity;
    }
}
