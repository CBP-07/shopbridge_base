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
        IEnumerable<Product> Get(params Expression<Func<Product, object>>[] navigationProperties);
        Product FirstOrDefault(Expression<Func<Product, bool>> selector);
        IEnumerable<Product> Get(Expression<Func<Product, bool>> selector);
        Product Add(Product product);
        bool Exist(Expression<Func<Product, bool>> selector);
        Product Update(int id,Product product);
        bool Delete(Expression<Func<Product, bool>> selector);
    }
}
