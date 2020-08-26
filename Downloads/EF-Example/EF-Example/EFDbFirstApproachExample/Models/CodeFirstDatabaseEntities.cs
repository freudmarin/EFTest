using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace EFDbFirstApproachExample.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class CodeFirstDatabaseEntities : DbContext
    {
        public CodeFirstDatabaseEntities()
            : base("name=CodeFirstDatabaseEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
        }

        public virtual DbSet<Brand2> Brands { get; set; }
        public virtual DbSet<Category2> Categories { get; set; }
        public virtual DbSet<Product2> Products { get; set; }
    }
}