using EFDbFirstApproachExample.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.Models
{
    public class Category2
    {
        [Key]
        public long CategoryID { get; set; }
        [Required(ErrorMessage ="Kjo fushe nuk duhet te jete bosh")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Kjo fushe mund te permbaje vetem shkronja ose numra")]

        
        [UniqueName(ErrorMessage="Kjo fushe duhet te jete unike")]

        [DisplayName("Emri i kategorise")]
        public string CategoryName { get; set; }
        public virtual ICollection<Product2> Products { get; set; }
    }
}