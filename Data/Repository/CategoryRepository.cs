using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private Shopbridge_Context _ctx;

        public CategoryRepository(Shopbridge_Context context)
        {
            _ctx = context;
        }
        async Task<T> ICategoryRepository.Add<T>(T entity)
        {
            try
            {
                var entry = _ctx.Add(entity);
                await _ctx.SaveChangesAsync();
                return entry.Entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        IQueryable<T> ICategoryRepository.AsQueryable<T>()
        {
            throw new NotImplementedException();
        }

        Task<bool> ICategoryRepository.Delete<T>(Expression<Func<T, bool>> selector)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICategoryRepository.Exist<T>(Expression<Func<T, bool>> selector)
        {
            throw new NotImplementedException();
        }

        Task<T> ICategoryRepository.FirstOrDefault<T>(Expression<Func<T, bool>> selector)
        {
            throw new NotImplementedException();
        }

        IQueryable<T> ICategoryRepository.Get<T>(params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        IQueryable<T> ICategoryRepository.Get<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> ICategoryRepository.Get<T>()
        {
            throw new NotImplementedException();
        }

        Task<T> ICategoryRepository.Update<T, TId>(TId id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
