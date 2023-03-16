using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;
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

        public async Task<T> Add<T>(T entity) where T : class, IEntity
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

        public IQueryable<T> AsQueryable<T>() where T : class, IEntity
        {
            return _ctx.Set<T>().AsQueryable();
        }

        public async Task<bool> Delete<T>(Expression<Func<T, bool>> selector) where T : class, IEntity
        {
            try
            {
                var item = await FirstOrDefault(selector);
                (item as IEntity).Status = false;
                //_ctx.Remove(item);
                _ctx.SaveChanges();
                return !await Exist(selector);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Exist<T>(Expression<Func<T, bool>> selector) where T : class, IEntity
        {
            return await _ctx.Set<T>().AnyAsync(selector);
        }

        public async Task<T> FirstOrDefault<T>(Expression<Func<T, bool>> selector) where T : class, IEntity
        {
            return  await AsQueryable <T>().FirstOrDefaultAsync(selector);
        }

        public IQueryable<T> Get<T>(params Expression<Func<T, object>>[] navigationProperties) where T : class, IEntity
        {
            var query =  AsQueryable<T>();
            query = query.IncludeProperties(navigationProperties);
            return query;
        }
       
        public IQueryable<T> Get<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties) where T : class, IEntity
        {
            var query = AsQueryable<T>();
            query = query.IncludeProperties(navigationProperties);
            query = query.Where(where);
            return query;
        }

        public async Task<IEnumerable<T>> Get<T>() where T : class, IEntity
        {
            return AsQueryable<T>().ToList();
        }

        public async Task<T> Update<T, TId>(TId id, T entity) where T : class, IEntity
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
