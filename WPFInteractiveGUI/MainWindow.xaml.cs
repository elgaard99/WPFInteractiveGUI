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

namespace WPFInteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        public MainWindow()
        {

            InitializeComponent();

            controller = new Controller();

            DataContext = controller;

            btnDeletePerson.IsEnabled = false;
            btnUp.IsEnabled = false;
            btnDown.IsEnabled = false;

            tbFirstName.IsEnabled = false;
            tbLastName.IsEnabled = false;
            tbAge.IsEnabled = false;
            tbTelephoneNo.IsEnabled = false;


        }

        private void btnDeletePerson_click(object sender, RoutedEventArgs e)
        {
            controller.DeletePerson();

            if (controller.PersonCount != 0)
            {
                tbFirstName.Text = controller.CurrentPerson.FirstName;
                tbLastName.Text = controller.CurrentPerson.LastName;
                tbAge.Text = controller.CurrentPerson.Age.ToString();
                tbTelephoneNo.Text = controller.CurrentPerson.TelephoneNo;
            }

            else
            {
                btnDeletePerson.IsEnabled = false;
                btnUp.IsEnabled = false;
                btnDown.IsEnabled = false;

                tbFirstName.IsEnabled = false;
                tbLastName.IsEnabled = false;
                tbAge.IsEnabled = false;
                tbTelephoneNo.IsEnabled = false;

                tbFirstName.Clear();
                tbLastName.Clear();
                tbAge.Clear();
                tbTelephoneNo.Clear();
            }

        }

        private void btnUp_click(object sender, RoutedEventArgs e)
        {
            controller.NextPerson();

            tbFirstName.Text = controller.CurrentPerson.FirstName;
            tbLastName.Text = controller.CurrentPerson.LastName;
            tbAge.Text = controller.CurrentPerson.Age.ToString();
            tbTelephoneNo.Text = controller.CurrentPerson.TelephoneNo;
        }

        private void btnDown_click(object sender, RoutedEventArgs e)
        {
            controller.PrevPerson();

            tbFirstName.Text = controller.CurrentPerson.FirstName;
            tbLastName.Text = controller.CurrentPerson.LastName;
            tbAge.Text = controller.CurrentPerson.Age.ToString();
            tbTelephoneNo.Text = controller.CurrentPerson.TelephoneNo;
        }

        private void btnNewPerson_click(object sender, RoutedEventArgs e)
        {
            controller.AddPerson();

            btnDeletePerson.IsEnabled = true;
            btnUp.IsEnabled = true;
            btnDown.IsEnabled = true;

            tbFirstName.IsEnabled = true;
            tbLastName.IsEnabled = true;
            tbAge.IsEnabled = true;
            tbTelephoneNo.IsEnabled = true;

            tbFirstName.Clear();
            tbLastName.Clear();
            tbAge.Clear();
            tbTelephoneNo.Clear();

        }

        private void tbFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.PersonCount != 0)
                controller.CurrentPerson.FirstName = tbFirstName.Text;
        }

        private void tbLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.PersonCount != 0)
                controller.CurrentPerson.LastName = tbLastName.Text;
        }

        private void tbAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.PersonCount != 0)
            {
                int age = 0;

                if (int.TryParse(tbAge.Text, out age) || tbAge.Text == string.Empty)
                    controller.CurrentPerson.Age = age;

                else
                    MessageBox.Show("Du skal angive et tal.");
            }
        }

        private void tbTelephoneNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.PersonCount != 0)
                controller.CurrentPerson.TelephoneNo = tbTelephoneNo.Text;
        }

       
    }
}
