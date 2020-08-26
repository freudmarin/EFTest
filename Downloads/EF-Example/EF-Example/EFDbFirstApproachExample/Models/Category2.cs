using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.Models
{
    public class Category2
    {
        [Key]
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product2> Products { get; set; }
    }
}