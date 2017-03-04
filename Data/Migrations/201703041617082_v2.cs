namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommentReview", new[] { "ShowroomerId", "BuyerId" }, "dbo.Review");
            DropForeignKey("dbo.RateReview", new[] { "ShowroomerId", "BuyerId" }, "dbo.Review");
            RenameColumn(table: "dbo.CommentReview", name: "ShowroomerId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.CommentReview", name: "BuyerId", newName: "ShowroomerId");
            RenameColumn(table: "dbo.RateReview", name: "ShowroomerId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.RateReview", name: "BuyerId", newName: "ShowroomerId");
            RenameColumn(table: "dbo.CommentReview", name: "__mig_tmp__0", newName: "BuyerId");
            RenameColumn(table: "dbo.RateReview", name: "__mig_tmp__1", newName: "BuyerId");
            RenameIndex(table: "dbo.CommentReview", name: "IX_ShowroomerId_BuyerId", newName: "IX_BuyerId_ShowroomerId");
            RenameIndex(table: "dbo.RateReview", name: "IX_ShowroomerId_BuyerId", newName: "IX_BuyerId_ShowroomerId");
            DropPrimaryKey("dbo.Review");
            AddPrimaryKey("dbo.Review", new[] { "BuyerId", "ShowroomerId" });
            AddForeignKey("dbo.CommentReview", new[] { "BuyerId", "ShowroomerId" }, "dbo.Review", new[] { "BuyerId", "ShowroomerId" });
            AddForeignKey("dbo.RateReview", new[] { "BuyerId", "ShowroomerId" }, "dbo.Review", new[] { "BuyerId", "ShowroomerId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RateReview", new[] { "BuyerId", "ShowroomerId" }, "dbo.Review");
            DropForeignKey("dbo.CommentReview", new[] { "BuyerId", "ShowroomerId" }, "dbo.Review");
            DropPrimaryKey("dbo.Review");
            AddPrimaryKey("dbo.Review", new[] { "ShowroomerId", "BuyerId" });
            RenameIndex(table: "dbo.RateReview", name: "IX_BuyerId_ShowroomerId", newName: "IX_ShowroomerId_BuyerId");
            RenameIndex(table: "dbo.CommentReview", name: "IX_BuyerId_ShowroomerId", newName: "IX_ShowroomerId_BuyerId");
            RenameColumn(table: "dbo.RateReview", name: "BuyerId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.CommentReview", name: "BuyerId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.RateReview", name: "ShowroomerId", newName: "BuyerId");
            RenameColumn(table: "dbo.RateReview", name: "__mig_tmp__1", newName: "ShowroomerId");
            RenameColumn(table: "dbo.CommentReview", name: "ShowroomerId", newName: "BuyerId");
            RenameColumn(table: "dbo.CommentReview", name: "__mig_tmp__0", newName: "ShowroomerId");
            AddForeignKey("dbo.RateReview", new[] { "ShowroomerId", "BuyerId" }, "dbo.Review", new[] { "ShowroomerId", "BuyerId" });
            AddForeignKey("dbo.CommentReview", new[] { "ShowroomerId", "BuyerId" }, "dbo.Review", new[] { "ShowroomerId", "BuyerId" });
        }
    }
}
