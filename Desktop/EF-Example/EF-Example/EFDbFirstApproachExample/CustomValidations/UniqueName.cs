using EFDbFirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.CustomValidations
{
    public class UniqueName: ValidationAttribute
    {
        
      public   override bool IsValid(object value)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            //mund te perdoret dhe tek categoryName dhe tek BrandName
            string name = value as string;
            
            int count = db.Categories.Where(c => c.CategoryName == name).Count();
            if (count >= 1)
                return false;
            return true;
        }
    }
}