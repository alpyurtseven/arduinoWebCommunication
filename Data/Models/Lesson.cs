using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string LessonName { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15)]
        public string LessonCode { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
