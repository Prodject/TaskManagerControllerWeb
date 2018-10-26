namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uygulamalars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UygulamaAdi = c.String(),
                        Cpu = c.Int(nullable: false),
                        Ram = c.Int(nullable: false),
                        IsAcik = c.Boolean(nullable: false),
                        AcilmaZamani = c.DateTime(nullable: false),
                        KapanmaZamani = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uygulamalars");
        }
    }
}
