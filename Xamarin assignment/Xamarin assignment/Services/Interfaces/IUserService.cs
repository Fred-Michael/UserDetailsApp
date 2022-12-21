using SQLite;
using System.Collections.ObjectModel;
using Xamarin_assignment.Models;

namespace Xamarin_assignment.Services.Interfaces
{
    public interface IUserService
    {
        ObservableCollection<User> GetAllUsers();
        int SaveUser(SQLiteConnection conn, User user);
    }
}
