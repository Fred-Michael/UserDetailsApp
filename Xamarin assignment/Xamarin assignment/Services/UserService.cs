using System;
using Xamarin_assignment.Services.Interfaces;
using SQLite;
using Xamarin_assignment.Models;
using System.Collections.ObjectModel;

namespace Xamarin_assignment.Services
{
    public class UserService
    {
        public static ObservableCollection<User> GetAllUsers()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<User>();
                return new ObservableCollection<User>(conn.Table<User>());
            }
        }

        public static int SaveUser(SQLiteConnection connection, User user)
        {
            connection.CreateTable<User>();
            var rows = connection.Insert(user);
            connection.Close();

            return rows > 0 ? 1 : 0;
        }
    }
}
