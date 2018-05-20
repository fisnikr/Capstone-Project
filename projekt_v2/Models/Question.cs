using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt_v2.Models
{
    public class Question
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string QText { get; set; }
        [Required]
        public int Points { get; set; }

        public int QuizID { get; set; } 
        public virtual Quiz Quizes { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<Results> Result { get; set; }
      
    }
}
