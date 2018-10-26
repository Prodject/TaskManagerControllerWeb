namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uygulamalars", "IsServis", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uygulamalars", "IsServis");
        }
    }
}
