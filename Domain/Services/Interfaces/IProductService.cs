using Shopbridge_base.Data;
using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get(params Expression<Func<Product, object>>[] navigationProperties);
        Task<Product> FirstOrDefault(Expression<Func<Product, bool>> selector);
        Task<IEnumerable<Product>> Get(Expression<Func<Product, bool>> selector);
        Task<Product> Add(Product product);
        Task<bool> Exist(Expression<Func<Product, bool>> selector);
        Task<Product> Update(int id,Product product);
        Task<bool> Delete(Expression<Func<Product, bool>> selector);
        Task<ProductPagedList> Get(Expression<Func<Product, bool>> selector, int begin, int offset);
    }
}
