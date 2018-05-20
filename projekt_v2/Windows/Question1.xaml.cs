using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using projekt_v2.Models;
using System.Data.Linq;

namespace projekt_v2.Windows
{
    /// <summary>
    /// Interaction logic for Question1.xaml
    /// </summary>
    public partial class Question1 : Window
    {
        public Quiz quiz { get; set; }
        public Question question { get; set; }
        public Answer ans { get; set; }
        private DatabaseContext context;
        List<Answer> item = new List<Answer>();

        public Question1()
        {
            InitializeComponent();
            DataContext = new[] { new Answer() };
            //  dgQuestion.ItemsSource = question;

            // txtQuestion.Text = questionText.ToString();



         //   dataGrid1.ItemsSource = item.Select(x => x.QAnswer);
        }

        public class checkedBoxIte
        {
            public string MyString { get; set; }
            public bool MyBool { get; set; }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //int id = 2;
            context = new DatabaseContext();
            var quest = (from q in context.Questions
                         where q.QuizID == quiz.Id //&& q.Id == id
                         orderby Guid.NewGuid()
                         select new
                         {
                             Id = q.Id,
                             QuestionText = q.QText
                         }).FirstOrDefault();


            txtQuestion.Text = quest.QuestionText.ToString();

            int questionid = quest.Id;


            var answers = (from a in context.Answers
                           where a.QuestionID == questionid
                           select a);

          
            var count1 = context.Answers.Where(a => a.QuestionID == questionid).Select(d => d.Id);


            // var count = answers.Count();
            var anst = (from a in context.Answers
                        where a.QuestionID == questionid
                        select a).ToList();


            for (int i = 0; i < count1.Count(); i++)
            {
                Answer ite = new Answer();
         

                ite.QAnswer = anst.ToString();


            }

            item.AddRange(anst);
        dataGrid1.ItemsSource = item;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}

