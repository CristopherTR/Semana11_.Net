namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationsv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        studentID = c.Int(nullable: false, identity: true),
                        studentName = c.String(nullable: false),
                        studentAddress = c.String(nullable: false),
                        studentLast = c.String(nullable: false),
                        studentCode = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.studentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
