namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInventory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        customer_name = c.String(),
                        customer_info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        purchase_date = c.String(),
                        customerRefID = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        inventoryRefID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.customers", t => t.customerRefID, cascadeDelete: true)
                .ForeignKey("dbo.inventories", t => t.inventoryRefID, cascadeDelete: true)
                .Index(t => t.customerRefID)
                .Index(t => t.inventoryRefID);
            
            CreateTable(
                "dbo.inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        quantity = c.Int(nullable: false),
                        riceRefID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.rice", t => t.riceRefID, cascadeDelete: true)
                .Index(t => t.riceRefID);
            
            CreateTable(
                "dbo.rice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        rice_name = c.String(),
                        riceother_info = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.supplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        supply_date = c.String(),
                        supplierRefID = c.Int(nullable: false),
                        inventoryRefID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.inventories", t => t.inventoryRefID, cascadeDelete: true)
                .ForeignKey("dbo.suppliers", t => t.supplierRefID, cascadeDelete: true)
                .Index(t => t.supplierRefID)
                .Index(t => t.inventoryRefID);
            
            CreateTable(
                "dbo.suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        supplier_name = c.String(),
                        supplier_company = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.supplyhistorylogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        supplier_name = c.String(),
                        supplier_company = c.String(),
                        supply_date = c.String(),
                        quantity = c.Int(nullable: false),
                        rice_name = c.String(),
                        riceother_info = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.purchases", "inventoryRefID", "dbo.inventories");
            DropForeignKey("dbo.supplies", "supplierRefID", "dbo.suppliers");
            DropForeignKey("dbo.supplies", "inventoryRefID", "dbo.inventories");
            DropForeignKey("dbo.inventories", "riceRefID", "dbo.rice");
            DropForeignKey("dbo.purchases", "customerRefID", "dbo.customers");
            DropIndex("dbo.supplies", new[] { "inventoryRefID" });
            DropIndex("dbo.supplies", new[] { "supplierRefID" });
            DropIndex("dbo.inventories", new[] { "riceRefID" });
            DropIndex("dbo.purchases", new[] { "inventoryRefID" });
            DropIndex("dbo.purchases", new[] { "customerRefID" });
            DropTable("dbo.supplyhistorylogs");
            DropTable("dbo.suppliers");
            DropTable("dbo.supplies");
            DropTable("dbo.rice");
            DropTable("dbo.inventories");
            DropTable("dbo.purchases");
            DropTable("dbo.customers");
        }
    }
}
