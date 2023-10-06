using FluentMigrator;
using AspNetWebApplication.Migrations.Helper;

namespace AspNetWebApplication.Migrations
{
    [MigrationDate(2023,10,05,08,16,14)]
    public class G5_M20200604AddedThePersonTable : Migration
    {
        public override void Up()
        {
            Create.Table("Person_G5")
                  .WithColumn("PersonId_G5").AsInt32().Identity().PrimaryKey("PK_Person_Id_G5")
                  .WithColumn("Code").AsString(14).NotNullable().Unique("UK_Person_Code_G5")
                  .WithColumn("FirstName").AsString(82).Nullable()
                  .WithColumn("LastName").AsString(82).Nullable()
                  .WithColumn("Sede").AsString(16).Nullable()
                  .WithColumn("Plan").AsString(282).Nullable()
                  .WithColumn("Centro_Educativo").AsString(8).Nullable()
                  .WithColumn("CreationDate").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Person_G5");
        }
    }
}
