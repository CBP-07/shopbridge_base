using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Models
{
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
    }
}
