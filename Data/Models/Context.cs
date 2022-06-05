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
            Database.SetInitializer(new Configuration());
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }

    public class Configuration : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
        }

    }
}
