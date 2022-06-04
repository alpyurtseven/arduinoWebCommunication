namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdae : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Lessons", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Questions", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Exams", "ExamType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exams", "ExamType", c => c.String(maxLength: 15, unicode: false));
            DropColumn("dbo.Questions", "Status");
            DropColumn("dbo.Users", "Status");
            DropColumn("dbo.Lessons", "Status");
            DropColumn("dbo.Exams", "Status");
        }
    }
}
