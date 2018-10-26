namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "EPosta", c => c.String());
            AddColumn("dbo.Logins", "yedek1", c => c.String());
            AddColumn("dbo.Logins", "yedek2", c => c.String());
            AddColumn("dbo.Logins", "yedek3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "yedek3");
            DropColumn("dbo.Logins", "yedek2");
            DropColumn("dbo.Logins", "yedek1");
            DropColumn("dbo.Logins", "EPosta");
        }
    }
}
