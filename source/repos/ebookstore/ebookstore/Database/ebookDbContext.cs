using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ebookstore.Migrations.Models;
using ebookstore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ebookstore.Data
{
    public class ebookDbContext : IdentityDbContext<ebookstoreUser>
    {
        public ebookDbContext()
        {
        }

        public ebookDbContext(DbContextOptions<ebookDbContext> options)
            : base(options)
        {
         
        }





        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Books> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
         
     
         builder.Entity<ebookstoreUser>()
     .HasOne<ShoppingCartItem>(s => s.Item)
     .WithOne(m => m.User)
    .HasForeignKey<ShoppingCartItem>(ad => ad.userId);

        }
    }
}
