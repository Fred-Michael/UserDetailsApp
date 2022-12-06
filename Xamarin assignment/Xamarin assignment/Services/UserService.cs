using System;
using Xamarin_assignment.Services.Interfaces;
using SQLite;
using Xamarin_assignment.Models;

namespace Xamarin_assignment.Services
{
    public class UserService : IUserService
    {
        public int SaveUser(SQLiteConnection connection, User user)
        {
            connection.CreateTable<User>();
            var rows = connection.Insert(user);
            connection.Close();

            return rows > 0 ? 1 : 0;
        }
    }
}
