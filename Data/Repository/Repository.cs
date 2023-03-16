using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly Shopbridge_Context _ctx;

        public Repository(Shopbridge_Context _dbcontext)
        {
            this._ctx = _dbcontext;
        }

        public T Add<T>(T entity) where T : class
        {
            try
            {
                var entry =_ctx.Set<T>().Add(entity);
                _ctx.SaveChanges();
                return entry.Entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IQueryable<T> AsQueryable<T>() where T : class
        {
            return _ctx.Set<T>().AsQueryable();
        }

        public bool Delete<T>(Expression<Func<T, bool>> selector) where T : class
        {
            try
            {
                var item = FirstOrDefault(selector);
                _ctx.Remove(item);
                _ctx.SaveChanges();
                return !Exist(selector);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Exist<T>(Expression<Func<T, bool>> selector) where T : class
        {
            return _ctx.Set<T>().Any(selector);
        }

        public T FirstOrDefault<T>(Expression<Func<T, bool>> selector) where T : class
        {
            return AsQueryable<T>().FirstOrDefault(selector);
        }

        public IQueryable<T> Get<T>(params Expression<Func<T, object>>[] navigationProperties) where T : class
        {
            var query = AsQueryable<T>();
            query = query.IncludeProperties(navigationProperties);
            return query;
        }
       
        public IQueryable<T> Get<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties) where T : class
        {
            var query = AsQueryable<T>();
            query = query.IncludeProperties(navigationProperties);
            query = query.Where(where);
            return query;
        }

        public IEnumerable<T> Get<T>() where T : class
        {
            return AsQueryable<T>().ToList();
        }

        public T Update<T, TId>(TId id, T entity) where T : class
        {
            try
            {
                var old = _ctx.Set<T>().Find(id);
                var entry = _ctx.Entry(old);
                entry.CurrentValues.SetValues(entity);
               //var entry = _ctx.Set<T>().Update(entity);
                _ctx.SaveChanges();
                return entry.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
