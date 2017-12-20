namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.claims", "name", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.claims", "name");
        }
    }
}
