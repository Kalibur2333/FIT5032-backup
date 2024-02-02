namespace FolioProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentModels2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentModels2", // Define the table name
                c => new
                {
                    Id = c.Int(nullable: false, identity: true), // Id column
                    MedicImageId = c.Int(nullable: false), // MedicImageId column
                    AppointmentTime = c.DateTime(nullable: false), // AppointmentTime column
                    Description = c.String(), // Description column
                })
                .PrimaryKey(t => t.Id) // Set Id as the primary key
                .ForeignKey("dbo.MedicImages", t => t.MedicImageId, cascadeDelete: true) // Define a foreign key relationship to MedicImages
                .Index(t => t.MedicImageId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppointmentModels", "MedicImageId", "dbo.MedicImages"); // Drop the foreign key relationship
            DropIndex("dbo.AppointmentModels", new[] { "MedicImageId" }); // Drop the index
            DropTable("dbo.AppointmentModels"); // Drop the AppointmentModels table in case of rollback
        }
    }
}
