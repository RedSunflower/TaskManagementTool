namespace ManagementTool.Roles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserToTask : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserTrackingTasks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserTrackingTasks", "TrackingTask_Id", "dbo.TrackingTasks");
            DropIndex("dbo.ApplicationUserTrackingTasks", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserTrackingTasks", new[] { "TrackingTask_Id" });
            AddColumn("dbo.TrackingTasks", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.TrackingTasks", "User_Id");
            AddForeignKey("dbo.TrackingTasks", "User_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.ApplicationUserTrackingTasks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserTrackingTasks",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        TrackingTask_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.TrackingTask_Id });
            
            DropForeignKey("dbo.TrackingTasks", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TrackingTasks", new[] { "User_Id" });
            DropColumn("dbo.TrackingTasks", "User_Id");
            CreateIndex("dbo.ApplicationUserTrackingTasks", "TrackingTask_Id");
            CreateIndex("dbo.ApplicationUserTrackingTasks", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserTrackingTasks", "TrackingTask_Id", "dbo.TrackingTasks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserTrackingTasks", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
