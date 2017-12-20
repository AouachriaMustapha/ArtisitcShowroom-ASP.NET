namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class integration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.artwork", "phot", c => c.String(maxLength: 255, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.artwork", "phot");
        }
    }
}
