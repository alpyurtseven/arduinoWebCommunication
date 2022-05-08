using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;


namespace Data.Models
{
    public class Context:DbContext
    {
        public Context()
              : base("name=Context") {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Exam> Exams { get; set; }


        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
