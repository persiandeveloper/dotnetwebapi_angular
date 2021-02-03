using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            

            bundles.Add(new Bundle("~/bundles/Angular")
              .Include(
                "~/bundles/AngularOutput/inline.*",
                "~/bundles/AngularOutput/polyfills.*",
                "~/bundles/AngularOutput/scripts.*",
                "~/bundles/AngularOutput/vendor.*",
                "~/bundles/AngularOutput/runtime.*",
                "~/bundles/AngularOutput/main.*"));


            bundles.Add(new StyleBundle("~/Content/Angular")
          .Include("~/bundles/AngularOutput/styles.*"));
         }
    }
}
