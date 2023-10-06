using System;
using System.Diagnostics;
using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors.SqlServer;

namespace AspNetWebApplication.Migrations.Helper
{
    public class MigrationStatus
    {
        public static string SqlScript = string.Empty;

        private string ConnectionString { get; set; }

        public MigrationStatus()
        {}

        public MigrationStatus(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public int Timeout { get; set; }
            public string ProviderSwitches { get; set; }
        }

        private MigrationRunner GetMigrationRunner()
        {
            var announcer = new TextWriterAnnouncer(s => Debug.WriteLine(s));
            var assembly = Assembly.GetAssembly(GetType());
            var migrationContext = new RunnerContext(announcer) {Namespace = "AspNetWebApplication.Migrations"};
            var options = new MigrationOptions {PreviewOnly = false, Timeout = 60, ProviderSwitches = String.Empty};
            var factory = new SqlServer2008ProcessorFactory();
            var processor = factory.Create(ConnectionString, announcer, options);
            return new MigrationRunner(assembly, migrationContext, processor);
        }

        public void MigrateToLatest()
        {
            var runner = GetMigrationRunner();
            runner.MigrateUp(true);
        }

        public void MigrateToPrevious(long version)
        {
            var runner = GetMigrationRunner();
            runner.MigrateDown(version, true);
        }
    }
}