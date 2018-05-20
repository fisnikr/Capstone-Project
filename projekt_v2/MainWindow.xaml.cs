using projekt_v2.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using projekt_v2.Models;

namespace projekt_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseContext context;
        public MainWindow()
        {
            InitializeComponent();
        }

       


 

        private void btProfessor_Click(object sender, RoutedEventArgs e)
        {
            Professor P = new Windows.Professor();
            P.Owner = this;
            this.Hide();
            P.ShowDialog();
            this.Close();
        }

        private void btStudent_Click(object sender, RoutedEventArgs e)
        {
            Student S = new Student();
            S.Owner = this;
            this.Hide();
            S.ShowDialog();
            this.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register R = new Register();
            R.ShowDialog();
            R.Owner = this;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            context = new DatabaseContext();
            User u = new User();

            var prof = context.Users.Where(q => q.IsAdmin == true && q.EMail == txtEmail.Text && q.Password == pswBox.Password);
            var std = context.Users.Where(q => q.IsAdmin == false && q.EMail == txtEmail.Text && q.Password == pswBox.Password);


            if (prof.Count() != 0)
            {
                Professor P = new Windows.Professor();
                P.Owner = this;
                this.Hide();
                P.ShowDialog();
                // this.Close();
               
            }
            else if (std.Count() != 0)
            {
                Student S = new Student();
              
                S.ShowDialog();
                S.Owner = this;
              
            }
            else
               MessageBox.Show("Invalid username and/or password");
        }
    }
}
