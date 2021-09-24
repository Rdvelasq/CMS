namespace CMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4thMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Department", "DepartmentLocation", c => c.String());
            DropColumn("dbo.Department", "TestField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Department", "TestField", c => c.Boolean(nullable: false));
            DropColumn("dbo.Department", "DepartmentLocation");
        }
    }
}
