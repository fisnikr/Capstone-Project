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
    /// Interaction logic for Professor.xaml
    /// </summary>
    public partial class Professor : Window
    {
        public Professor()
        {
            InitializeComponent();
        }

        private void btAddQuiz_Click(object sender, RoutedEventArgs e)
        {
            AddQuiz AQ = new AddQuiz();
            AQ.Owner = this;
            this.Hide();
            AQ.ShowDialog();
         
        }

        private void btEditQuiz_Click(object sender, RoutedEventArgs e)
        {
            EditQuiz EQ = new EditQuiz();
            EQ.Owner = this;
            this.Hide();
            EQ.ShowDialog();
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminRegister R = new AdminRegister();
            R.Owner = this;
          
            R.ShowDialog();
        }
    }
}
