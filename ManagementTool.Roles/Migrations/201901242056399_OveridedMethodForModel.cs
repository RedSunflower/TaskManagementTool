namespace ManagementTool.Roles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OveridedMethodForModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TrackingTasks", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.TrackingTasks", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TrackingTasks", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.TrackingTasks", name: "UserId", newName: "User_Id");
        }
    }
}
