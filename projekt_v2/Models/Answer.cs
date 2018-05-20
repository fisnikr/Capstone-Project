using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt_v2.Models
{
    public class Answer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string QAnswer { get; set; }
        [Required]
        public bool IsCorrect { get; set; }

        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }

    }
}
