namespace CMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personnel", "ManagerId1", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personnel", "ManagerId1");
        }
    }
}
