using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string ExamName { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string ExamType { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
