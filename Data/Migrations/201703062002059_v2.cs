namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", new[] { "InteractionId", "UserId", "ProductId" }, "dbo.Interaction");
            DropForeignKey("dbo.Rate", new[] { "InteractionId", "UserId", "ProductId" }, "dbo.Interaction");
            DropPrimaryKey("dbo.Interaction");
            AlterColumn("dbo.Interaction", "InteractionId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Interaction", new[] { "InteractionId", "UserId", "ProductId" });
            AddForeignKey("dbo.Comment", new[] { "InteractionId", "UserId", "ProductId" }, "dbo.Interaction", new[] { "InteractionId", "UserId", "ProductId" });
            AddForeignKey("dbo.Rate", new[] { "InteractionId", "UserId", "ProductId" }, "dbo.Interaction", new[] { "InteractionId", "UserId", "ProductId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rate", new[] { "InteractionId", "UserId", "ProductId" }, "dbo.Interaction");
            DropForeignKey("dbo.Comment", new[] { "InteractionId", "UserId", "ProductId" }, "dbo.Interaction");
            DropPrimaryKey("dbo.Interaction");
            AlterColumn("dbo.Interaction", "InteractionId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Interaction", new[] { "InteractionId", "UserId", "ProductId" });
            AddForeignKey("dbo.Rate", new[] { "InteractionId", "UserId", "ProductId" }, "dbo.Interaction", new[] { "InteractionId", "UserId", "ProductId" });
            AddForeignKey("dbo.Comment", new[] { "InteractionId", "UserId", "ProductId" }, "dbo.Interaction", new[] { "InteractionId", "UserId", "ProductId" });
        }
    }
}
