namespace ManagementTool.Roles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDetailsFieldAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrackingTasks", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TrackingTasks", new[] { "UserId" });
            AddColumn("dbo.TrackingTasks", "ApplicationUserDetails", c => c.String());
            AddColumn("dbo.TrackingTasks", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.TrackingTasks", "ApplicationUser_Id");
            AddForeignKey("dbo.TrackingTasks", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackingTasks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TrackingTasks", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.TrackingTasks", "ApplicationUser_Id");
            DropColumn("dbo.TrackingTasks", "ApplicationUserDetails");
            CreateIndex("dbo.TrackingTasks", "UserId");
            AddForeignKey("dbo.TrackingTasks", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
