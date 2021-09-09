namespace SongsUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Internees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Goal = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Internees");
        }
    }
}
