namespace Pagina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnacimiento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "nacimiento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personas", "nacimiento");
        }
    }
}
