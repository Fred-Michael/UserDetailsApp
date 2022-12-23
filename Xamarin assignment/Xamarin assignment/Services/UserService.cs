using SQLite;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin_assignment.Models;

namespace Xamarin_assignment.Services
{
    public class UserService
    {
        private static int result = 0;
        public static ObservableCollection<User> GetAllUsers()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<User>();
                return new ObservableCollection<User>(conn.Table<User>());
            }
        }

        public static async Task<int> ActionUser(bool action, User user)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                bool choice;
                if (action == false)
                {
                    choice = await App.Current.MainPage.DisplayAlert(
                        "Update User",
                        $"Are you sure you want to update this record?",
                        "Yes",
                        "No");

                    if (choice)
                        result = conn.Update(user);
                }
                else
                {
                    choice = await App.Current.MainPage.DisplayAlert(
                    "Delete User",
                    $"Are you sure you want to delete {user.Name}?",
                    "Yes",
                    "No");

                    if (choice)
                        result = conn.Delete(user);
                }

                return result;
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
