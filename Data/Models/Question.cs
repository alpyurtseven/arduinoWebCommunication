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

        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string Answer {get; set; }

        public bool QuestionTye { get; set; }
        public int ExanId { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
