using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Answer
    { 
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
