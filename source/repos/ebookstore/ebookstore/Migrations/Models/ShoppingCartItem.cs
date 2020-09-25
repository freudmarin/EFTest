using ebookstore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.Migrations.Models
{
    public class ShoppingCartItem
    {  [Key]
        [DisplayName("ID e artikullit")]
        public int ShoppingCartItemId { get; set; }
        public Books Book { get; set; }
        [DisplayName("Sasia")]
        public int Amount { get; set; }
        [DisplayName("ID e shportes")]
        public string ShoppingCartId { get; set; }
        public   ebookstoreUser User { get; set; }
       public   string userId { get; set; }
    }
}
