namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Exam_ExamId", "dbo.Exams");
            DropIndex("dbo.Questions", new[] { "Exam_ExamId" });
            RenameColumn(table: "dbo.Questions", name: "Exam_ExamId", newName: "ExamId");
            AlterColumn("dbo.Questions", "ExamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "ExamId");
            AddForeignKey("dbo.Questions", "ExamId", "dbo.Exams", "ExamId", cascadeDelete: true);
            DropColumn("dbo.Questions", "ExanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "ExanId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Questions", "ExamId", "dbo.Exams");
            DropIndex("dbo.Questions", new[] { "ExamId" });
            AlterColumn("dbo.Questions", "ExamId", c => c.Int());
            RenameColumn(table: "dbo.Questions", name: "ExamId", newName: "Exam_ExamId");
            CreateIndex("dbo.Questions", "Exam_ExamId");
            AddForeignKey("dbo.Questions", "Exam_ExamId", "dbo.Exams", "ExamId");
        }
    }
}
