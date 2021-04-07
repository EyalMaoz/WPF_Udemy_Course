using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel.Helpers
{
    public class DataBaseHelper
    {
        private static readonly string dbFile = Path.Combine(Environment.CurrentDirectory, "notedDb.db3");

        public static bool Insert<T>(T item)
        {
            bool res = false;
            using (SQLiteConnection conn = new SQLiteConnection(App.GenricSqlite, dbFile))
            {
                conn.CreateTable<T>();
                res = conn.Insert(item) > 0;
            }
            return res;
        }

        public static bool Delete<T>(T item)
        {
            bool res = false;
            using (SQLiteConnection conn = new SQLiteConnection(App.GenricSqlite, dbFile))
            {
                conn.CreateTable<T>();
                res = conn.Delete(item) > 0;
            }
            return res;
        }

        public static List<T> Read<T>() where T : class
        {
            List<T> items;
            using (SQLiteConnection conn = new SQLiteConnection(App.GenricSqlite, dbFile))
            {
                conn.CreateTable<T>();
                items = conn.Table<T>().ToList();
            }
            return items;
        }

    }
}
