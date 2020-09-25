using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ebookstore.Migrations.Models;
using Microsoft.AspNetCore.Identity;

namespace ebookstore
{
    
    public class ebookstoreUser : IdentityUser
    {
        public string  FirstName { get; set; }
        public string LastName { get; set; }

        public string Adress { get; set; }


        public  ShoppingCartItem  Item { get; set; }
    }
}
