namespace ManagementTool.Roles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullNameAndSurname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
