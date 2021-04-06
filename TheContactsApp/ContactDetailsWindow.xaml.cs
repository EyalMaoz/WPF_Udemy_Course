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
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact m_contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            m_contact = contact;
            nameTextBox.Text = m_contact.Name;
            emailTextBox.Text = m_contact.Email;
            phoneTextBox.Text = m_contact.PhoneNumber;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.GenricSqlite, App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(m_contact);
            }
            Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            m_contact.Name = nameTextBox.Text;
            m_contact.Email = emailTextBox.Text;
            m_contact.PhoneNumber = phoneTextBox.Text;
            using (SQLiteConnection connection = new SQLiteConnection(App.GenricSqlite, App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(m_contact);
            }
            Close();
        }
    }
}
