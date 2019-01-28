namespace ManagementTool.Roles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationBetweenTasksAndUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserTrackingTasks",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        TrackingTask_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.TrackingTask_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.TrackingTasks", t => t.TrackingTask_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.TrackingTask_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserTrackingTasks", "TrackingTask_Id", "dbo.TrackingTasks");
            DropForeignKey("dbo.ApplicationUserTrackingTasks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserTrackingTasks", new[] { "TrackingTask_Id" });
            DropIndex("dbo.ApplicationUserTrackingTasks", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserTrackingTasks");
        }
    }
}
