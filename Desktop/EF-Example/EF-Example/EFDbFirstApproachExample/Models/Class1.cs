using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace EFDbFirstApproachExample.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class EFDBFirstDatabaseEntities : DbContext
    {
        public EFDBFirstDatabaseEntities()
            : base("name=EFDBFirstDatabaseEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}