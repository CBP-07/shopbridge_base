using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public interface IRepository
    {
        IQueryable<T> AsQueryable<T>() where T : class;
        IQueryable<T> Get<T>(params Expression<Func<T, object>>[] navigationProperties) where T : class;
        IQueryable<T> Get<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties) where T : class;
        IEnumerable<T> Get<T>() where T : class;
        T FirstOrDefault<T>(Expression<Func<T,bool>> selector) where T : class;
        bool Delete<T>(Expression<Func<T,bool>> selector) where T: class;
        T Add<T>(T entity) where T: class;
        T Update<T,TId>(TId id,T entity) where T: class;
        bool Exist<T>(Expression<Func<T, bool>> selector) where T : class;
    }
}
