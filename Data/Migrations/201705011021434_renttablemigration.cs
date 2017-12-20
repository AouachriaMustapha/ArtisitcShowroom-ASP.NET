namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renttablemigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.rentspace",
                c => new
                    {
                        fk_artist = c.Int(nullable: false),
                        fk_space = c.Int(nullable: false),
                        rentDate = c.DateTime(nullable: false, precision: 0),
                        price = c.Single(nullable: false),
                        user1_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.fk_artist, t.fk_space })
                .ForeignKey("dbo.space", t => t.fk_space)
                .ForeignKey("dbo.user", t => t.fk_artist)
                .ForeignKey("dbo.user", t => t.user1_id)
                .Index(t => t.fk_artist)
                .Index(t => t.fk_space)
                .Index(t => t.user1_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.rentspace", "user1_id", "dbo.user");
            DropForeignKey("dbo.rentspace", "fk_artist", "dbo.user");
            DropForeignKey("dbo.rentspace", "fk_space", "dbo.space");
            DropIndex("dbo.rentspace", new[] { "user1_id" });
            DropIndex("dbo.rentspace", new[] { "fk_space" });
            DropIndex("dbo.rentspace", new[] { "fk_artist" });
            DropTable("dbo.rentspace");
        }
    }
}
