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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheContactsApp.Entities;

namespace TheContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts = null;

        public MainWindow()
        {
            InitializeComponent();
            ReadDB();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewContact newContact = new AddNewContact();
            newContact.ShowDialog();
            ReadDB();
        }

        void ReadDB()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.GenricSqlite, App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();
            }
            if (contacts != null)
            {
                ContactsListView.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchedText = (sender as TextBox)?.Text?.ToLower();
            if (searchedText == null) return;
            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchedText)).ToList();
            if (filteredList != null)
            {
                ContactsListView.ItemsSource = filteredList;
            }
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = ContactsListView.SelectedItem as Contact;
            if (selectedContact != null)
            {
                ContactDetailsWindow detailsWindow = new ContactDetailsWindow(selectedContact);
                detailsWindow.ShowDialog();
                ReadDB();
            }
        }
    }
}
