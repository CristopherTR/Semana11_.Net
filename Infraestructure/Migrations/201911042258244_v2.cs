namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "studentLast", c => c.String(nullable: false));
            AddColumn("dbo.Students", "studentCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "studentCode");
            DropColumn("dbo.Students", "studentLast");
        }
    }
}
