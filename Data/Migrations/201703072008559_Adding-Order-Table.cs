namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOrderTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "UserId", "dbo.Buyer");
            DropForeignKey("dbo.Purchases", "ProductId", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "UserId" });
            DropIndex("dbo.Purchases", new[] { "ProductId" });
            DropPrimaryKey("dbo.Purchases");
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PurchaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId)
                .Index(t => t.PurchaseId);
            
            AddColumn("dbo.Purchases", "PurchaseId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Purchases", "DatePurchase", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Purchases", "Status", c => c.String());
            AlterColumn("dbo.Purchases", "Total", c => c.Double(nullable: false));
            AddPrimaryKey("dbo.Purchases", "PurchaseId");
            DropColumn("dbo.Purchases", "UserId");
            DropColumn("dbo.Purchases", "ProductId");
            DropColumn("dbo.Purchases", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Purchases", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "UserId", "dbo.User");
            DropForeignKey("dbo.Orders", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "PurchaseId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropPrimaryKey("dbo.Purchases");
            AlterColumn("dbo.Purchases", "Total", c => c.Single(nullable: false));
            DropColumn("dbo.Purchases", "Status");
            DropColumn("dbo.Purchases", "DatePurchase");
            DropColumn("dbo.Purchases", "PurchaseId");
            DropTable("dbo.Orders");
            AddPrimaryKey("dbo.Purchases", new[] { "UserId", "ProductId" });
            CreateIndex("dbo.Purchases", "ProductId");
            CreateIndex("dbo.Purchases", "UserId");
            AddForeignKey("dbo.Purchases", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "UserId", "dbo.Buyer", "UserId");
        }
    }
}
