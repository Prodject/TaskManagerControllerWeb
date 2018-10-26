namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TabloID = c.Int(nullable: false),
                        KullaniciAdi = c.String(),
                        Sifre = c.String(),
                        AdminYetki = c.String(),
                        Client = c.String(),
                        ClientYetki = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logins");
        }
    }
}
