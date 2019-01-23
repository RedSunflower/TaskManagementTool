namespace ManagementTool.Roles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProgressListAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrackingTasks", "Progress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrackingTasks", "Progress");
        }
    }
}
