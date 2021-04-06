using SQLite.Net.Platform.Generic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TheContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string DatabasePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Contacts.db");
        public static SQLitePlatformGeneric GenricSqlite = new SQLitePlatformGeneric();
    }
}
