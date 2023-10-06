using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AspNetWebApplication.Core.Helper;
using AspNetWebApplication.Migrations.Helper;

namespace AspNetWebApplication
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            var connectionString = ConnectionHelper.GetConnectionString2();
            MigrateDatabase(connectionString);

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void MigrateDatabase(string connectionString)
        {
            var migrator = new MigrationStatus(connectionString);
            migrator.MigrateToLatest();
        }
    }
}