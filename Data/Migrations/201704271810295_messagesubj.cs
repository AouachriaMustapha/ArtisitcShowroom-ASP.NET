namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagesubj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.message", "subject", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.message", "subject");
        }
    }
}
