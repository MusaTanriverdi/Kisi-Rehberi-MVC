namespace TelReh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationcontrol : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kisiler", "Ad", c => c.String());
            AlterColumn("dbo.Kisiler", "CepTelefon", c => c.String());
            AlterColumn("dbo.Kisiler", "EmailAdres", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kisiler", "EmailAdres", c => c.String(nullable: false));
            AlterColumn("dbo.Kisiler", "CepTelefon", c => c.String(nullable: false));
            AlterColumn("dbo.Kisiler", "Ad", c => c.String(nullable: false));
        }
    }
}
