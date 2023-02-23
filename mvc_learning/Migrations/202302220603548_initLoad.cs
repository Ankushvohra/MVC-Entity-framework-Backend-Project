namespace mvc_learning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initLoad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        departmentid = c.Int(nullable: false, identity: true),
                        departmentname = c.String(),
                    })
                .PrimaryKey(t => t.departmentid);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
