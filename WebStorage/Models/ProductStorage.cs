using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStorage.Models
{
    public class ProductStorage
    {
        public int ProductStorageId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int StorageId { get; set; }
        public virtual Storage Storage { get; set; }
        public int Quantity { get; set; }
    }
}