using SQLite;
using Xamarin_assignment.Models;

namespace Xamarin_assignment.Services.Interfaces
{
    public interface IUserService
    {
        int SaveUser(SQLiteConnection conn, User user);
    }
}
