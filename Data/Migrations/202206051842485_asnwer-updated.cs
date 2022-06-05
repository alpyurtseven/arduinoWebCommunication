namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asnwerupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Answers", "UserID");
            AddForeignKey("dbo.Answers", "UserID", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "UserID", "dbo.Users");
            DropIndex("dbo.Answers", new[] { "UserID" });
            DropColumn("dbo.Answers", "UserID");
        }
    }
}
