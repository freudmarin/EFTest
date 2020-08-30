using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EFDbFirstApproachExample.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/jQuery").Include("~/Scripts/jquery-.js"));
            bundles.Add(new ScriptBundle("~/jQueryValidate").Include("~/Scripts/jquery.validate.js"));
            bundles.Add(new ScriptBundle("~/Unobtrusive").Include("~/Scripts/jquery.validate.unobtrusive.js"));
        }
    }
}