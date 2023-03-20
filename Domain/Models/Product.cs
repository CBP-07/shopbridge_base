using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Models
{
    public class Category:IEntity
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Description { get; set; }
        public bool Status { get; set; }
        public IList<ProductCategories> ProductCategories { get; set; }
    }

    public class ProductCategories: IEntity
    {
        [Key]
        public int ProductCategoriesId { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public bool Status { get; set; }
    }
    public class Product :IEntity
    {
        [Key]
        public int Product_Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0,double.MaxValue)]
        public double Price { get; set; }

        public bool Available { get; set; }
        public bool Status { get; set; }
        public IList<ProductCategories> ProductCategories { get; set; }
    }
}
