using Microsoft.Extensions.Logging;
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

        public IEnumerable<Product> Get(params Expression<Func<Product, object>>[] navigationProperties)
        {
            return _repository.Get<Product>(navigationProperties);
        }

        public Product FirstOrDefault(Expression<Func<Product, bool>> selector)
        {
            return _repository.FirstOrDefault(selector);
        }

        public IEnumerable<Product> Get(Expression<Func<Product, bool>> selector)
        {
            return _repository.Get(selector).ToList();
        }

        public bool Exist(Expression<Func<Product ,bool>> selector)
        {
            return _repository.Exist(selector);
        }
        public Product Add(Product product)
        {
            return _repository.Add(product);
        }
        public Product Update(int id,Product product)
        {
            return _repository.Update(id,product);
        }

        public bool Delete(Expression<Func<Product, bool>> selector)
        {
            return _repository.Delete(selector);
        }
    }
}
