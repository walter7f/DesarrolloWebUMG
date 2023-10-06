using System;
using FluentMigrator;

namespace AspNetWebApplication.Migrations.Helper
{
    public class MigrationDateAttribute : MigrationAttribute
    {
        public MigrationDateAttribute(int year, int month, int day, int hour, int minute, int second)
            : base(GetVersion(year, month, day, hour, minute, second))
        {}

        private static long GetVersion(int year, int month, int day, int hour, int minute, int second)
        {
            var date = new DateTime(year, month, day, hour, minute, second);
            var stringVersion = date.ToString("yyyyMMddHHmmss");
            return Convert.ToInt64(stringVersion);
        }
    }
}