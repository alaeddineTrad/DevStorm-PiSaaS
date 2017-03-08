namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1AfterPullingFromGit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Phone", c => c.Int(nullable: false));
        }
    }
}
