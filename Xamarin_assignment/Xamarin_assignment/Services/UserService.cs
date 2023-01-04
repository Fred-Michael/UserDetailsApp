using SQLite;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin_assignment.Models;

namespace Xamarin_assignment.Services
{
    public class UserService
    {
        private static int result = 0;
        private static string PhotoPath = null;
        private static string ImageLocation = "C:/Users/hp/source/repos/Xamarin_assignment/Xamarin_assignment/Xamarin_assignment/Assets/Images";
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

        public static void SaveUser(User user)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<User>();
                result = conn.Insert(user);

                if (result == 1)
                {
                    App.Current.MainPage.DisplayAlert(
                        "Success",
                        "A new user has been added to the db",
                        "OK");
                    App.Current.MainPage.Navigation.PopToRootAsync();
                }
                else
                {
                    App.Current.MainPage.DisplayAlert(
                        "Failure",
                        "Unable to add new user to the db",
                        "OK");
                    App.Current.MainPage.Navigation.PopToRootAsync();
                }
            }
        }
    }
}
