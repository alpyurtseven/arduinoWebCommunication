using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string QuestionContent { get; set; }
        public int QuestionScore { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string Answer {get; set; }

        public bool QuestionTye { get; set; }
        public bool Status { get; set; }
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
