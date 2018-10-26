namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Uygulamalars", "Cpu", c => c.String());
            AlterColumn("dbo.Uygulamalars", "Ram", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uygulamalars", "Ram", c => c.Int(nullable: false));
            AlterColumn("dbo.Uygulamalars", "Cpu", c => c.Int(nullable: false));
        }
    }
}
