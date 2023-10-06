using FluentMigrator;
using AspNetWebApplication.Migrations.Helper;

namespace AspNetWebApplication.Migrations
{
    [MigrationDate(2020,06,04,08,16,14)]
    public class M20200604AddedThePersonTable : Migration
    {
        public override void Up()
        {
            Create.Table("Person")
                  .WithColumn("PersonId").AsInt32().Identity().PrimaryKey("PK_Person_Id")
                  .WithColumn("Code").AsString(14).NotNullable().Unique("UK_Person_Code")
                  .WithColumn("FirstName").AsString(82).Nullable()
                  .WithColumn("LastName").AsString(82).Nullable()
                  .WithColumn("Phone").AsString(16).Nullable()
                  .WithColumn("Address").AsString(282).Nullable()
                  .WithColumn("BloodType").AsString(8).Nullable()
                  .WithColumn("CreationDate").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Person");
        }
    }
}
