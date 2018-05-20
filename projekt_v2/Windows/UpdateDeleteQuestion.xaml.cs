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

namespace projekt_v2.Windows
{
    /// <summary>
    /// Interaction logic for UpdateDeleteQuestion.xaml
    /// </summary>
    /// 
    public partial class UpdateDeleteQuestion : Window
    {
        public Quiz Quiz { get; set; }
        DatabaseContext context;
        public UpdateDeleteQuestion()
        {
            InitializeComponent();
            dgQuestions.Items.Refresh();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            context = new DatabaseContext();
            var questions = from q in context.Questions
                            where q.QuizID == Quiz.Id
                            select new
                            {
                                Id = q.Id,
                                QuestionText = q.QText
                            };

            dgQuestions.ItemsSource = questions.ToList();
            //context.Questions.Where(p => p.QuizID == Quiz.Id).ToList();
           // dgQuestions.Columns["QText"].Visibile = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtID.Text))
            {
                int dltQuestionId = int.Parse(txtID.Text);
                var dltQuestion = context.Questions.Where(q => q.Id == dltQuestionId).FirstOrDefault();
                context.Questions.Remove(dltQuestion);
                context.SaveChanges();

                MessageBox.Show("Question Deleted !");
                txtID.Clear();
                txtQuestion.Clear();
                txtID.Focus();

                context = new DatabaseContext();
                var questions = from q in context.Questions
                                where q.QuizID == Quiz.Id
                                orderby Guid.NewGuid()
                                select new
                                {
                                    Id = q.Id,
                                    QuestionText = q.QText
                                };

                dgQuestions.ItemsSource = questions.ToList();
                //dgQuestions.ItemsSource = context.Questions.Where(p => p.QuizID == Quiz.Id).ToList();

            }
            else
                MessageBox.Show("Please enter QuestionID !");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
           
           

            if (!string.IsNullOrWhiteSpace(txtQuestion.Text) && !string.IsNullOrWhiteSpace(txtID.Text))
            {
                int upQuestionId = int.Parse(txtID.Text);
                //   Question q = new Question();
                var upQuestion = context.Questions.Where(q => q.Id == upQuestionId).FirstOrDefault();
                upQuestion.QText = txtQuestion.Text;
              //  context.Question.Add
                context.SaveChanges();
                

                MessageBox.Show("Updated!");
                txtID.Clear();
                txtQuestion.Clear();
                txtID.Focus();
                    
                context = new DatabaseContext();
                var questions = from q in context.Questions
                                where q.QuizID == Quiz.Id
                                orderby Guid.NewGuid()
                                select new
                                {
                                    Id = q.Id,
                                    QuestionText = q.QText
                                };
                dgQuestions.ItemsSource = questions.ToList();


            }
            else
                MessageBox.Show("Please Enter Question or ID !");
        }
    }
}
