using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Data;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services
{
    public class ProductService : IProductService
    {
        private IRepository _repository { get; }
        private readonly ILogger<ProductService> _logger;
        public ProductService(IRepository repository, ILogger<ProductService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> Get(params Expression<Func<Product, object>>[] navigationProperties)
        {
            return await _repository.Get<Product>(navigationProperties).ToListAsync();
        }

        public async Task<Product> FirstOrDefault(Expression<Func<Product, bool>> selector)
        {
            return await _repository.FirstOrDefault(selector);
        }

        public async Task<IEnumerable<Product>> Get(Expression<Func<Product, bool>> selector)
        {

            return await _repository.Get(selector).ToListAsync();
        }

        public async Task<ProductPagedList> Get(Expression<Func<Product, bool>> selector, int begin, int offset)
        {
            int items = begin * offset;
            var products =await _repository.Get(selector).Skip(items).Take(offset).ToListAsync();
            var remaining = await _repository.Count((Product x)=>x.Status==true) - items;
            return new ProductPagedList {
                Page = begin,
                Product = products,
                Remainig = remaining
            };
        }

        public async Task<bool> Exist(Expression<Func<Product ,bool>> selector)
        {
            return await _repository.Exist(selector);
        }
        public async Task<Product> Add(Product product)
        {
            return await _repository.Add(product);
        }
        public async Task<Product> Update(int id,Product product)
        {
            return await _repository.Update(id,product);
        }

        public async Task<bool> Delete(Expression<Func<Product, bool>> selector)
        {
            return await _repository.Delete(selector);
        }
    }
}
