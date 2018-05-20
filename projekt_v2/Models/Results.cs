using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt_v2.Models
{
    public class Results
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserID { get; set; }    
        public virtual User Users { get; set; }

   
        public int QuizID { get; set; }
        public virtual Quiz Quizes { get; set; }
        
       [ForeignKey("Questions")]
        public int QuestionID { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public bool IsCorrect { get; set; }
        public int AnswerID { get; set; }
        public virtual Answer Answers { get; set; }

      
      

    }
}
