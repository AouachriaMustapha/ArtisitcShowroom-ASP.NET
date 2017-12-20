namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spacemigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.space", "loulepar", c => c.Int(nullable: true));
            AddColumn("dbo.space", "pic", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.space", "pic");
            DropColumn("dbo.space", "loulepar");
        }
    }
}
