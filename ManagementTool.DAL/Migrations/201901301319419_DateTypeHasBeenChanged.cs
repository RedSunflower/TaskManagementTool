namespace ManagementTool.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTypeHasBeenChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrackingTasks", "StartDate", c => c.DateTime());
            AlterColumn("dbo.TrackingTasks", "TillDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrackingTasks", "TillDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TrackingTasks", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
