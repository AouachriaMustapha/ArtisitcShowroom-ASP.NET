namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.space", "rentdate", c => c.DateTime(precision: 0));
            AlterColumn("dbo.space", "loulepar", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.space", "loulepar", c => c.Int(nullable: false));
            DropColumn("dbo.space", "rentdate");
        }
    }
}
