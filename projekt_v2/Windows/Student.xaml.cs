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
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class Student : Window
    {
        public Student()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            QuizWindow qw = new QuizWindow();
            ComboBoxItem item = (ComboBoxItem)cmbSelectQuiz.SelectedItem;
            Quiz q = (Quiz)item.Tag;
            qw.quiz = q;
            qw.Owner = this;
            qw.ShowDialog();
        }


        public void loaddata()
        {


            DatabaseContext context = new DatabaseContext();
            foreach (Quiz q in context.Quizes)
            {
                ComboBoxItem ci = new ComboBoxItem();
                ci.Content = q.Title;
                ci.Tag = q;
                cmbSelectQuiz.Items.Add(ci);
            }

        }
        private void cmbSelectQuiz_Loaded(object sender, RoutedEventArgs e)
        {
            loaddata();
        }


    }
}
