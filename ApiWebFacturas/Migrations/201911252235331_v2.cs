namespace ApiWebFacturas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Facturas", "Estado_Factura", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Facturas", "Estado_Factura", c => c.Double(nullable: false));
        }
    }
}
