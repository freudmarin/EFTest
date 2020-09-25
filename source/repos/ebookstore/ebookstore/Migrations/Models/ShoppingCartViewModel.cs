using ebookstore.Migrations.Models;
using ebookstore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ebookstore.Models
    {
        public class ShoppingCartViewModel
        {
            public ShoppingCart ShoppingCart { get; set; }
            public decimal ShoppingCartTotal { get; set; }
        }
    }


