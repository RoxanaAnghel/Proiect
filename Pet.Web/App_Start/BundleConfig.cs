using System.Web;
using System.Web.Optimization;

namespace Pet.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            RegisterBundles_GetAPet(bundles);
        }

        public static void RegisterBundles_GetAPet(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            IBundleTransform[] jsTransforms = new IBundleTransform[0];
            IBundleTransform[] cssTransforms = new IBundleTransform[0];

            Bundle angularMaterialBundle = new Bundle("~/angular-material", cssTransforms);
            angularMaterialBundle.Include("~/Content/angular-material/angular-material.css");
            angularMaterialBundle.Include("~/Content/angular-material/bootstrap.css");
            bundles.Add(angularMaterialBundle);

            Bundle materialLiteBundle = new Bundle("~/Content/mdl", cssTransforms);
            materialLiteBundle.Include("~/Content/mdl-v1.1.2/material.css");
            bundles.Add(materialLiteBundle);

            Bundle angularBundle = new Bundle("~/angular", jsTransforms);
            angularBundle.Include("~/Scripts/angular/angular.js");
            angularBundle.Include("~/Scripts/angular/angular-aria.js");
            angularBundle.Include("~/Scripts/angular/angular-animate.js");
            angularBundle.Include("~/Scripts/angular/angular-material.js");
            angularBundle.Include("~/Scripts/angular/angular-route.js");
            angularBundle.Include("~/Content/mdl-v1.1.2/material.js");
            bundles.Add(angularBundle);

            Bundle appModuleBundle = new Bundle("~/module", jsTransforms);
            appModuleBundle.Include("~/app/app.module.js");
            bundles.Add(appModuleBundle);

            Bundle controllerBundle = new Bundle("~/AngularControllers", jsTransforms);
            controllerBundle.Include("~/app/home/home.controller.js");
            controllerBundle.Include("~/app/home/home.service.js");
            controllerBundle.Include("~/app/user/user.service.js");
            controllerBundle.Include("~/app/user/userdetails.controller.js");
            controllerBundle.Include("~/app/user/userdetails-edit.controller.js");
            controllerBundle.Include("~/app/myPets/mypets.controller.js");
            controllerBundle.Include("~/app/myPets/mypets.service.js");
            controllerBundle.Include("~/app/myPets/pet-save.controller.js");
            controllerBundle.Include("~/app/myPets/pet-edit.controller.js");
            controllerBundle.Include("~/app/conversations/conversations.controller.js");
            controllerBundle.Include("~/app/conversations/conversation.controller.js");
            controllerBundle.Include("~/app/conversations/conversations.service.js");
            controllerBundle.Include("~/app/conversations/messages.service.js");
            controllerBundle.Include("~/app/myPets/pet.view.controller.js");
            
            controllerBundle.Include("~/app/uploads/uploads.controller.js");
            controllerBundle.Include("~/app/uploads/uploads.service.js");
            controllerBundle.Include("~/app/uploads/loading-spinner.js");

            bundles.Add(controllerBundle);
        }
    }
}
