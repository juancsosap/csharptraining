namespace Pagina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                        apellido = c.String(nullable: false, maxLength: 100),
                        edad = c.Int(nullable: false),
                        email = c.String(nullable: false),
                        direccion = c.String(nullable: false, maxLength: 500),
                        tarjeta = c.String(nullable: false),
                        contrasena = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personas");
        }
    }
}
