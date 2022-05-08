using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Name { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Surname { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(8)]
        public string Password { get; set; }

        public bool Role { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
