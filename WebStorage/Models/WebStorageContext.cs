using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebStorage.Models
{
    public class WebStorageContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebStorageContext() : base("name=WebStorageContext")
        {
        }

        public System.Data.Entity.DbSet<WebStorage.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<WebStorage.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<WebStorage.Models.Storage> Storages { get; set; }

        public System.Data.Entity.DbSet<WebStorage.Models.ProductStorage> ProductStorages { get; set; }
    }
}
