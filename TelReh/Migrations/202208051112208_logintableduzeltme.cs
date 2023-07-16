namespace TelReh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logintableduzeltme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loginler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(),
                        Sifre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Loginler");
        }
    }
}
