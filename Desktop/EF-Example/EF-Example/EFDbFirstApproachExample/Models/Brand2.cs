using EFDbFirstApproachExample.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.Models
{
    public class Brand2
    {
        [Key]
        public long BrandID { get; set; }

        [Required(ErrorMessage = "Kjo fushe nuk duhet te jete bosh")]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "Kjo fushe mund te permbaje vetem shkronja ose numra")]
        [DisplayName("Emri i Brand")]
        [BrandUnique(ErrorMessage="Brandi duhet te jete unik")]
        public string BrandName { get; set; }
        public virtual ICollection<Product2> Products { get; set; }
    }
}