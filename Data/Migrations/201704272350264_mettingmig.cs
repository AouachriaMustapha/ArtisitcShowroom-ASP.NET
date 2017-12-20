namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mettingmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.metting", "etat", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.metting", "etat");
        }
    }
}
