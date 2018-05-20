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
    /// Interaction logic for AddAnswer.xaml
    /// </summary>
    public partial class AddAnswer : Window
    {
        public Question Question { get; set; }
        public AddAnswer()
        {
            InitializeComponent();
        }

        public void loadtextb()
        {
            DatabaseContext c = new DatabaseContext();
            foreach(Question q in c.Questions)
            {
                TextBox tx = new TextBox();
                tx.Text = q.QText;
                tx.Tag = q;
           
                txtQuestionA.Text = tx.Text;
               
            }

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            loadtextb();
        }
     

        

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Answer a = new Answer();
            a.QAnswer = txtAnswer.Text;
           
          

            a.IsCorrect=Convert.ToBoolean(checkAnswer.IsChecked);
            a.QuestionID = Question.Id;
            DatabaseContext c = new DatabaseContext();
            c.Answers.Add(a);
            c.SaveChanges();

            MessageBox.Show("Answer Added");

            
        }

      
    }
}
