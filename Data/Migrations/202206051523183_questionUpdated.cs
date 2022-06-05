namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questionUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "QuestionScore", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "QuestionScore");
        }
    }
}
