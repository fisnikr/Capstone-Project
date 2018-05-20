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
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {

        public Quiz quiz { get; set; }
        public Question question { get; set; }
        public Answer ans { get; set; }
        private DatabaseContext context;
        public QuizWindow()
        {
            InitializeComponent();
            context = new DatabaseContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Question1 q1 = new Question1();
            q1.quiz = quiz;
            q1.question = question;
            q1.ans = ans;
            q1.ShowDialog();

        }

        private void txtQuestion2_Click(object sender, RoutedEventArgs e)
        {
            Question1 q1 = new Question1();
            q1.quiz = quiz;
            q1.question = question;
            q1.ans = ans;
            q1.ShowDialog();
        }

        private void txtQuestion3_Click(object sender, RoutedEventArgs e)
        {
            Question1 q1 = new Question1();
            q1.quiz = quiz;
            q1.question = question;
            q1.ans = ans;
            q1.ShowDialog();
        }

        private void txtQuestion4_Click(object sender, RoutedEventArgs e)
        {
            Question1 q1 = new Question1();
            q1.quiz = quiz;
            q1.question = question;
            q1.ans = ans;
            q1.ShowDialog();
        }

        private void txtQuestion5_Click(object sender, RoutedEventArgs e)
        {
            Question1 q1 = new Question1();
            q1.quiz = quiz;
            q1.question = question;
            q1.ans = ans;
            q1.ShowDialog();
        }

        private void txtQuestion6_Click(object sender, RoutedEventArgs e)
        {
            Question1 q1 = new Question1();
            q1.quiz = quiz;
            q1.question = question;
            q1.ans = ans;
            q1.ShowDialog();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank You for taking the quiz !");
            this.Close();
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
           
            
            
        }
    }
}
