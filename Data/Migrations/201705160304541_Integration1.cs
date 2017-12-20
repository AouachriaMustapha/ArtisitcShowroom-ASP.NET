namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Integration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpositionArtworks",
                c => new
                    {
                        artworkId = c.Int(nullable: false),
                        exposureId = c.Int(nullable: false),
                        fk_space = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        DateExpoPriority = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => new { t.artworkId, t.exposureId })
                .ForeignKey("dbo.artwork", t => t.artworkId, cascadeDelete: true)
                .ForeignKey("dbo.exposure", t => t.exposureId, cascadeDelete: true)
                .Index(t => t.artworkId)
                .Index(t => t.exposureId);
            
            AddColumn("dbo.exposure", "eDate", c => c.DateTime(precision: 0));
            AddColumn("dbo.exposure", "sDate", c => c.DateTime(precision: 0));
            AddColumn("dbo.exposure", "Archiver", c => c.Boolean(nullable: false));
            AddColumn("dbo.exposure", "details_fk_artwork", c => c.Int());
            AddColumn("dbo.exposure", "details_detailDate", c => c.DateTime(precision: 0));
            AddColumn("dbo.exposure", "details_fk_space", c => c.Int());
            CreateIndex("dbo.exposure", new[] { "details_fk_artwork", "details_detailDate", "details_fk_space" });
            AddForeignKey("dbo.exposure", new[] { "details_fk_artwork", "details_detailDate", "details_fk_space" }, "dbo.details", new[] { "fk_artwork", "detailDate", "fk_space" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpositionArtworks", "exposureId", "dbo.exposure");
            DropForeignKey("dbo.ExpositionArtworks", "artworkId", "dbo.artwork");
            DropForeignKey("dbo.exposure", new[] { "details_fk_artwork", "details_detailDate", "details_fk_space" }, "dbo.details");
            DropIndex("dbo.ExpositionArtworks", new[] { "exposureId" });
            DropIndex("dbo.ExpositionArtworks", new[] { "artworkId" });
            DropIndex("dbo.exposure", new[] { "details_fk_artwork", "details_detailDate", "details_fk_space" });
            DropColumn("dbo.exposure", "details_fk_space");
            DropColumn("dbo.exposure", "details_detailDate");
            DropColumn("dbo.exposure", "details_fk_artwork");
            DropColumn("dbo.exposure", "Archiver");
            DropColumn("dbo.exposure", "sDate");
            DropColumn("dbo.exposure", "eDate");
            DropTable("dbo.ExpositionArtworks");
        }
    }
}
