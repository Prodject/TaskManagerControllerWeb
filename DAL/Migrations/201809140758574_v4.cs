namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "FirmaAdi", c => c.String());
            AddColumn("dbo.Logins", "Client1", c => c.String());
            AddColumn("dbo.Logins", "ClientYetki1", c => c.String());
            AddColumn("dbo.Logins", "Client2", c => c.String());
            AddColumn("dbo.Logins", "ClientYetki2", c => c.String());
            AddColumn("dbo.Logins", "Client3", c => c.String());
            AddColumn("dbo.Logins", "ClientYetki3", c => c.String());
            AddColumn("dbo.Logins", "Client4", c => c.String());
            AddColumn("dbo.Logins", "ClientYetki4", c => c.String());
            AddColumn("dbo.Logins", "Client5", c => c.String());
            AddColumn("dbo.Logins", "ClientYetki5", c => c.String());
            AddColumn("dbo.Logins", "Guncelleme", c => c.String());
            AddColumn("dbo.Logins", "ProgramAdi", c => c.String());
            AddColumn("dbo.Logins", "PKomut", c => c.String());
            AddColumn("dbo.Logins", "CKomut", c => c.String());
            AddColumn("dbo.Logins", "EKomut", c => c.String());
            AddColumn("dbo.Logins", "resim", c => c.String());
            AddColumn("dbo.Uygulamalars", "Userid", c => c.Int(nullable: false));
            AddColumn("dbo.Uygulamalars", "PUzanti", c => c.String());
            AlterColumn("dbo.Uygulamalars", "AcilmaZamani", c => c.String());
            AlterColumn("dbo.Uygulamalars", "KapanmaZamani", c => c.String());
            DropColumn("dbo.Logins", "TabloID");
            DropColumn("dbo.Logins", "Client");
            DropColumn("dbo.Logins", "ClientYetki");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "ClientYetki", c => c.String());
            AddColumn("dbo.Logins", "Client", c => c.String());
            AddColumn("dbo.Logins", "TabloID", c => c.Int(nullable: false));
            AlterColumn("dbo.Uygulamalars", "KapanmaZamani", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Uygulamalars", "AcilmaZamani", c => c.DateTime(nullable: false));
            DropColumn("dbo.Uygulamalars", "PUzanti");
            DropColumn("dbo.Uygulamalars", "Userid");
            DropColumn("dbo.Logins", "resim");
            DropColumn("dbo.Logins", "EKomut");
            DropColumn("dbo.Logins", "CKomut");
            DropColumn("dbo.Logins", "PKomut");
            DropColumn("dbo.Logins", "ProgramAdi");
            DropColumn("dbo.Logins", "Guncelleme");
            DropColumn("dbo.Logins", "ClientYetki5");
            DropColumn("dbo.Logins", "Client5");
            DropColumn("dbo.Logins", "ClientYetki4");
            DropColumn("dbo.Logins", "Client4");
            DropColumn("dbo.Logins", "ClientYetki3");
            DropColumn("dbo.Logins", "Client3");
            DropColumn("dbo.Logins", "ClientYetki2");
            DropColumn("dbo.Logins", "Client2");
            DropColumn("dbo.Logins", "ClientYetki1");
            DropColumn("dbo.Logins", "Client1");
            DropColumn("dbo.Logins", "FirmaAdi");
        }
    }
}
