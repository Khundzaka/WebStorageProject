using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStorage.Models
{
    public class Storage
    {
        public int StorageId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public virtual ICollection<ProductStorage> ProductStorages { get; set; }
    }
}