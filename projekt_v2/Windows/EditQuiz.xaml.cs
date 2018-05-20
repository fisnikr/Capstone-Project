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
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data;

namespace projekt_v2.Windows
{
    /// <summary>
    /// Interaction logic for EditQuiz.xaml
    /// </summary>
    public partial class EditQuiz : Window
    {
        public EditQuiz()
        {
            InitializeComponent();
        }

        public void loaddata()
        {


            DatabaseContext context = new DatabaseContext();
            foreach (Quiz q in context.Quizes)
            {
                ComboBoxItem ci = new ComboBoxItem();
                ci.Content = q.Title;
                ci.Tag = q;
                cmbEditQuiz.Items.Add(ci);
            }

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            loaddata();
        }

        private void btAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            AddQuestion AQ = new AddQuestion();
            ComboBoxItem item = (ComboBoxItem)cmbEditQuiz.SelectedItem;
            Quiz q = (Quiz)item.Tag;
            AQ.Quiz = q;
            AQ.Owner = this;
            AQ.ShowDialog();
            
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateDeleteQuestion UD = new UpdateDeleteQuestion();
            ComboBoxItem item = (ComboBoxItem)cmbEditQuiz.SelectedItem;
            Quiz q = (Quiz)item.Tag;
            UD.Quiz = q;
            UD.Owner = this;
            UD.ShowDialog();
        }
    }
}
