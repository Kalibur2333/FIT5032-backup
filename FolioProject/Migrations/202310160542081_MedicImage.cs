namespace FolioProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class MedicImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicImages", // Define the table name
                c => new
                {
                    Id = c.Int(nullable: false, identity: true), // Id column
                    Name = c.String(nullable: false), // Name column
                    Location = c.String(nullable: false), // Location column
                })
                .PrimaryKey(t => t.Id); // Set Id as the primary key
        }

        public override void Down()
        {
            DropTable("dbo.MedicImages"); // Drop the MedicImages table in case of rollback
        }
    }
}
