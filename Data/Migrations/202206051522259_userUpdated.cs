namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserNumber");
        }
    }
}
