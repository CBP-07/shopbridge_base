using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Helpers
{
    public static class EntityHelper
    {
        public static IQueryable<T> IncludeProperties<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] navigationProperties) where T : class,IEntity
        {
            if (navigationProperties != null)
            {
                foreach (var navProp in navigationProperties)
                {
                    query = query.Include(navProp); ;
                }
            }
            return query;
        }
    }
}
