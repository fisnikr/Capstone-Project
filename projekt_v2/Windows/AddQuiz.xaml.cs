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
    /// Interaction logic for AddQuiz.xaml
    /// </summary>
    public partial class AddQuiz : Window
    {
        public AddQuiz()
        {
            InitializeComponent();
        }

        private void btAddQuiz_Click(object sender, RoutedEventArgs e)
        {
            Quiz Q = new Models.Quiz();

            Q.Title = txtQuizName.Text;
            Q.Description = txtQuizDesc.Text;

            DatabaseContext c = new DatabaseContext();
            c.Quizes.Add(Q);           
            c.SaveChanges();

            MessageBox.Show("Quiz was registered !");
            this.Close();
        }
    }
}
