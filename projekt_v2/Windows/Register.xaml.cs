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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DatabaseContext context = new DatabaseContext();
            User u = new User();
            u.FirstName = txtFirstName.Text;
            u.LastName = txtLastName.Text;
            u.Password = pswBox.Password;
            u.EMail = txtEmail.Text;
            u.City = txtCity.Text;

            context.Users.Add(u);
            context.SaveChanges();

            MessageBox.Show("User registered !");

            this.Close();



        }
    }
}
