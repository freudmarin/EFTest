using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

      //  public System.Data.Entity.DbSet<UserManagement.Identity.ApplicationUser> ApplicationUsers { get; set; }

        //  public System.Data.Entity.DbSet<UserManagement.Identity.ApplicationUser> ApplicationUsers { get; set; }



        //nuk duhet ,gjenerohet vete // public System.Data.Entity.DbSet<UserManagement.Identity.ApplicationUser> ApplicationUsers { get; set; }
    }
}



