namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vmajd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        BuyerId = c.Int(nullable: false),
                        ShowroomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BuyerId, t.ShowroomerId })
                .ForeignKey("dbo.Buyer", t => t.BuyerId)
                .ForeignKey("dbo.Showroomer", t => t.ShowroomerId)
                .Index(t => t.BuyerId)
                .Index(t => t.ShowroomerId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Adress_City = c.String(),
                        Adress_Street = c.String(),
                        Adress_ZipCode = c.Int(nullable: false),
                        DateCreation = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Interaction",
                c => new
                    {
                        InteractionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InteractionId, t.UserId, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand = c.String(),
                        Tva = c.Single(nullable: false),
                        Category = c.String(),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
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
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        DatePurchase = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Total = c.Double(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseId);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        MediaId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.MediaId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Showrooms",
                c => new
                    {
                        ShowroomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShowroomerId, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Showroomer", t => t.ShowroomerId)
                .Index(t => t.ShowroomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        VoucherId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Reference = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Amount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.VoucherId)
                .ForeignKey("dbo.Showroomer", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CommentReview",
                c => new
                    {
                        BuyerId = c.Int(nullable: false),
                        ShowroomerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Text = c.String(),
                    })
                .PrimaryKey(t => new { t.BuyerId, t.ShowroomerId })
                .ForeignKey("dbo.Review", t => new { t.BuyerId, t.ShowroomerId })
                .Index(t => new { t.BuyerId, t.ShowroomerId });
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        InteractionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Text = c.String(),
                    })
                .PrimaryKey(t => new { t.InteractionId, t.UserId, t.ProductId })
                .ForeignKey("dbo.Interaction", t => new { t.InteractionId, t.UserId, t.ProductId })
                .Index(t => new { t.InteractionId, t.UserId, t.ProductId });
            
            CreateTable(
                "dbo.RateReview",
                c => new
                    {
                        BuyerId = c.Int(nullable: false),
                        ShowroomerId = c.Int(nullable: false),
                        Mark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BuyerId, t.ShowroomerId })
                .ForeignKey("dbo.Review", t => new { t.BuyerId, t.ShowroomerId })
                .Index(t => new { t.BuyerId, t.ShowroomerId });
            
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        InteractionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Mark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InteractionId, t.UserId, t.ProductId })
                .ForeignKey("dbo.Interaction", t => new { t.InteractionId, t.UserId, t.ProductId })
                .Index(t => new { t.InteractionId, t.UserId, t.ProductId });
            
            CreateTable(
                "dbo.Showroomer",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Description = c.String(),
                        Location_Latitude = c.Single(nullable: false),
                        Location_Longitude = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Buyer",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        DeliveryAddress = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buyer", "UserId", "dbo.User");
            DropForeignKey("dbo.Showroomer", "UserId", "dbo.User");
            DropForeignKey("dbo.Rate", new[] { "InteractionId", "UserId", "ProductId" }, "dbo.Interaction");
            DropForeignKey("dbo.RateReview", new[] { "BuyerId", "ShowroomerId" }, "dbo.Review");
            DropForeignKey("dbo.Comment", new[] { "InteractionId", "UserId", "ProductId" }, "dbo.Interaction");
            DropForeignKey("dbo.CommentReview", new[] { "BuyerId", "ShowroomerId" }, "dbo.Review");
            DropForeignKey("dbo.Interaction", "UserId", "dbo.User");
            DropForeignKey("dbo.Interaction", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Vouchers", "UserId", "dbo.Showroomer");
            DropForeignKey("dbo.Showrooms", "ShowroomerId", "dbo.Showroomer");
            DropForeignKey("dbo.Showrooms", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Review", "ShowroomerId", "dbo.Showroomer");
            DropForeignKey("dbo.Review", "BuyerId", "dbo.Buyer");
            DropForeignKey("dbo.Orders", "UserId", "dbo.User");
            DropForeignKey("dbo.Media", "UserId", "dbo.User");
            DropForeignKey("dbo.Orders", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Images", "ProductId", "dbo.Products");
            DropIndex("dbo.Buyer", new[] { "UserId" });
            DropIndex("dbo.Showroomer", new[] { "UserId" });
            DropIndex("dbo.Rate", new[] { "InteractionId", "UserId", "ProductId" });
            DropIndex("dbo.RateReview", new[] { "BuyerId", "ShowroomerId" });
            DropIndex("dbo.Comment", new[] { "InteractionId", "UserId", "ProductId" });
            DropIndex("dbo.CommentReview", new[] { "BuyerId", "ShowroomerId" });
            DropIndex("dbo.Vouchers", new[] { "UserId" });
            DropIndex("dbo.Showrooms", new[] { "ProductId" });
            DropIndex("dbo.Showrooms", new[] { "ShowroomerId" });
            DropIndex("dbo.Media", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "PurchaseId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Images", new[] { "ProductId" });
            DropIndex("dbo.Interaction", new[] { "ProductId" });
            DropIndex("dbo.Interaction", new[] { "UserId" });
            DropIndex("dbo.Review", new[] { "ShowroomerId" });
            DropIndex("dbo.Review", new[] { "BuyerId" });
            DropTable("dbo.Buyer");
            DropTable("dbo.Showroomer");
            DropTable("dbo.Rate");
            DropTable("dbo.RateReview");
            DropTable("dbo.Comment");
            DropTable("dbo.CommentReview");
            DropTable("dbo.Vouchers");
            DropTable("dbo.Showrooms");
            DropTable("dbo.Media");
            DropTable("dbo.Purchases");
            DropTable("dbo.Orders");
            DropTable("dbo.Images");
            DropTable("dbo.Products");
            DropTable("dbo.Interaction");
            DropTable("dbo.User");
            DropTable("dbo.Review");
        }
    }
}
