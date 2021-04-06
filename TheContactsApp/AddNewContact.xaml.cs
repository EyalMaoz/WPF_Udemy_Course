using SQLite.Net;
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
using TheContactsApp.Entities;

namespace TheContactsApp
{
    /// <summary>
    /// Interaction logic for AddNewContact.xaml
    /// </summary>
    public partial class AddNewContact : Window
    {
        public AddNewContact()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                PhoneNumber = phoneTextBox.Text
            };
            using (SQLiteConnection connection = new SQLiteConnection(App.GenricSqlite, App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }
            Close();
        }
    }
}
