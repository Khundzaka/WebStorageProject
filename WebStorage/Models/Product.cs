using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStorage.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ProductStorage> ProductStorages { get; set; }
    }
}