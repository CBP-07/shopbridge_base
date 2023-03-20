using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Data
{
    public class ProductPagedList
    {
        public IEnumerable<Product> Product { get; set; }
        public int Page { get; set; }
        public int Remainig { get; set; }
    }
}
