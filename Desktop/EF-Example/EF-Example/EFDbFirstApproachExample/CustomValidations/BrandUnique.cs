using EFDbFirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.CustomValidations
{
    public class BrandUnique: ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
          
            string name = value as string;

            int count = db.Brands.Where(br => br.BrandName == name).Count();
            if (count >= 1)
                return false;
            return true;
        }
    }
}