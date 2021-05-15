namespace Test_app_BrightEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SortNumbers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SortNumbers",
                c => new
                    {
                        SortNumberId = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SortNumberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SortNumbers");
        }
    }
}
