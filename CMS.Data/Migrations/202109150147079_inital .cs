namespace CMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Employee", newName: "Personnel");
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            AddColumn("dbo.Personnel", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Personnel", "NumberOfEmployees", c => c.Int());
            AddColumn("dbo.Personnel", "Salary", c => c.Double());
            AddColumn("dbo.Personnel", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Personnel", "ManagerId", c => c.Int());
            AlterColumn("dbo.Personnel", "HourlyRate", c => c.Double());
            CreateIndex("dbo.Personnel", "DepartmentId");
            CreateIndex("dbo.Personnel", "ManagerId");
            AddForeignKey("dbo.Personnel", "DepartmentId", "dbo.Department", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Personnel", "ManagerId", "dbo.Personnel", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personnel", "ManagerId", "dbo.Personnel");
            DropForeignKey("dbo.Personnel", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Personnel", new[] { "ManagerId" });
            DropIndex("dbo.Personnel", new[] { "DepartmentId" });
            AlterColumn("dbo.Personnel", "HourlyRate", c => c.Double(nullable: false));
            AlterColumn("dbo.Personnel", "ManagerId", c => c.Int(nullable: false));
            DropColumn("dbo.Personnel", "Discriminator");
            DropColumn("dbo.Personnel", "Salary");
            DropColumn("dbo.Personnel", "NumberOfEmployees");
            DropColumn("dbo.Personnel", "DepartmentId");
            DropTable("dbo.Department");
            RenameTable(name: "dbo.Personnel", newName: "Employee");
        }
    }
}
