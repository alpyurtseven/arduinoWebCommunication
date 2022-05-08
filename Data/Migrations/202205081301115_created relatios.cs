namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdrelatios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "LessonId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "ExanId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "Exam_ExamId", c => c.Int());
            CreateIndex("dbo.Exams", "LessonId");
            CreateIndex("dbo.Questions", "Exam_ExamId");
            AddForeignKey("dbo.Exams", "LessonId", "dbo.Lessons", "LessonId", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "Exam_ExamId", "dbo.Exams", "ExamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Exam_ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "LessonId", "dbo.Lessons");
            DropIndex("dbo.Questions", new[] { "Exam_ExamId" });
            DropIndex("dbo.Exams", new[] { "LessonId" });
            DropColumn("dbo.Questions", "Exam_ExamId");
            DropColumn("dbo.Questions", "ExanId");
            DropColumn("dbo.Exams", "LessonId");
        }
    }
}
