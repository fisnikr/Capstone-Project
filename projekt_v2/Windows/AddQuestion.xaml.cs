using projekt_v2.Models;
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

namespace projekt_v2.Windows
{
    /// <summary>
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        public  Quiz Quiz { get; set; }

        public AddQuestion()
        {
            InitializeComponent();
        }

       // public static string sendtext = "";
        private void btAddQuiz_Click(object sender, RoutedEventArgs e)
        {
           
            Question q = new Question();
            q.QuizID = Quiz.Id;
            q.QText = txtQuestion.Text;
            q.Points = int.Parse(txtPoints.Text);

            DatabaseContext c = new DatabaseContext();
            c.Questions.Add(q);
            c.SaveChanges();

            // MessageBox.Show("The Question was added");
            //  this.Close();

            AddAnswer AA = new AddAnswer();
            AA.Question = q;
            AA.Owner = this;
            AA.ShowDialog();


        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            txtQuizTitle.Text = Quiz.Title;
        }

   
    }
}
