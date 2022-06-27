namespace TaskManager.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FunctionTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FunctionName = c.String(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Functions", "Id", "dbo.Departments");
            DropIndex("dbo.Functions", new[] { "Id" });
            DropTable("dbo.Functions");
        }
    }
}
