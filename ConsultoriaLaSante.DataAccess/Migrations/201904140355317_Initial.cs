namespace ConsultoriaLaSante.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        FormNumber = c.Guid(nullable: false),
                        PurchaseNumber = c.String(),
                        BillNumber = c.String(),
                        Supplier_id = c.Int(nullable: false),
                        OrderState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FormNumber)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_id, cascadeDelete: true)
                .Index(t => t.Supplier_id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nit = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "Supplier_id", "dbo.Suppliers");
            DropIndex("dbo.Invoices", new[] { "Supplier_id" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Invoices");
        }
    }
}
