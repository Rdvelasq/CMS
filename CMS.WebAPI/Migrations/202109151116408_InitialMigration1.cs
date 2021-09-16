namespace CMS.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personnels", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Personnels", new[] { "DepartmentId" });
            DropIndex("dbo.Personnels", new[] { "Department_DepartmentId" });
            DropColumn("dbo.Personnels", "DepartmentId");
            RenameColumn(table: "dbo.Personnels", name: "Department_DepartmentId", newName: "DepartmentID");
            AddColumn("dbo.Personnels", "NumberOfEmployees", c => c.Int());
            AddColumn("dbo.Personnels", "Salary", c => c.Double());
            AlterColumn("dbo.Personnels", "DepartmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Personnels", "DepartmentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Personnels", "DepartmentID");
            CreateIndex("dbo.Personnels", "ManagerId");
            AddForeignKey("dbo.Personnels", "ManagerId", "dbo.Personnels", "Id");
            AddForeignKey("dbo.Personnels", "DepartmentID", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            DropColumn("dbo.Personnels", "ManagerId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personnels", "ManagerId1", c => c.Int());
            DropForeignKey("dbo.Personnels", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Personnels", "ManagerId", "dbo.Personnels");
            DropIndex("dbo.Personnels", new[] { "ManagerId" });
            DropIndex("dbo.Personnels", new[] { "DepartmentID" });
            AlterColumn("dbo.Personnels", "DepartmentID", c => c.Int());
            AlterColumn("dbo.Personnels", "DepartmentID", c => c.Int());
            DropColumn("dbo.Personnels", "Salary");
            DropColumn("dbo.Personnels", "NumberOfEmployees");
            RenameColumn(table: "dbo.Personnels", name: "DepartmentID", newName: "Department_DepartmentId");
            AddColumn("dbo.Personnels", "DepartmentId", c => c.Int());
            CreateIndex("dbo.Personnels", "Department_DepartmentId");
            CreateIndex("dbo.Personnels", "DepartmentId");
            AddForeignKey("dbo.Personnels", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
        }
    }
}
