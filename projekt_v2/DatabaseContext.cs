using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using projekt_v2;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using projekt_v2.Models;


namespace projekt_v2
{
  
    class DatabaseContext : DbContext
    {
        public DatabaseContext() 
            : base("Server=FISNIK;Database=projectv2;Trusted_Connection=True;")
        {

        }

        public IDbSet<Quiz> Quizes { get; set; }
        public IDbSet<Question> Questions { get; set; }
        public IDbSet<Answer> Answers { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Results> Results { get; set; }
       

    }
}
