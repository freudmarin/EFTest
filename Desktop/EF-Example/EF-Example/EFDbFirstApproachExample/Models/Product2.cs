using EFDbFirstApproachExample.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.Models
{
    public class Product2
    {
        [Key]
        public long ProductID { get; set; }
        [Required(ErrorMessage="Emri i produktit nuk duhet te jete bosh")]
        [MaxLength(50, ErrorMessage="Emri i produktit nuk duhet te kete me shume se 50 karaktere")]
        [MinLength(2, ErrorMessage = "Emri i produktit nuk duhet te kete me pak se 2 karaktere")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Vendosni nje vlere per cmimin")]
        [Range(0, 1000000000, ErrorMessage = "Cmimi duhet te jete midis 0 dhe 10000000")]
        public Nullable<decimal> Price { get; set; }
        [CurrentDateAttribute(ErrorMessage ="Data e blerjes,nuk ka kuptim")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }

        public Nullable<long> CategoryID { get; set; }

        public Nullable<long> BrandID { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Photo { get; set; }

        public virtual Brand2 Brand { get; set; }
        public virtual Category2 Category { get; set; }
    }
}