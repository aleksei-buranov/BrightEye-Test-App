namespace Test_app_BrightEye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Numbers",
                c => new
                    {
                        NumberId = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Numbers");
        }
    }
}
