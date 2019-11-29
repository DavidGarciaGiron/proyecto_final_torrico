namespace ApiWebFacturas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Facturas", "Nombre_Vendedor", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Facturas", "Nombre_Cliente", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Facturas", "Nombre_Cliente", c => c.String());
            AlterColumn("dbo.Facturas", "Nombre_Vendedor", c => c.String());
        }
    }
}
