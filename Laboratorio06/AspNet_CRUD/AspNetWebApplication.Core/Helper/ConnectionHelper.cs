using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;

namespace AspNetWebApplication.Core.Helper
{
    public static class ConnectionHelper
    {
        public static string CurrentConnectionString { get; set; }

        static ConnectionHelper()
        {
            ResetConnectionString();
        }

        public static void ResetConnectionString()
        {
            CurrentConnectionString = "AspNetWebApplicationEntities";
        }

        public static string GetConnectionString()
        {
            return GetConnectionString(CurrentConnectionString);
        }

        public static string GetConnectionString2()
        {
            return GetConnectionString(CurrentConnectionString, false);
        }

        public static string GetConnectionString(string name, bool metadata = true)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;

            var builder = new EntityConnectionStringBuilder(connectionString);

            if(metadata)
                return builder.ConnectionString;
            else
                return builder.ProviderConnectionString;
        }

        public static string GetConnectionString(DbConnection connection)
        {
            return connection.ConnectionString;
        }
    }
}
