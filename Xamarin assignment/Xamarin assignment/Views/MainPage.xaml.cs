using SQLite;
using Xamarin.Forms;
using Xamarin_assignment.Models;
using Xamarin_assignment.ViewModels;
using Xamarin_assignment.Views;

namespace Xamarin_assignment
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageVM();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<User>();
                var results = conn.Table<User>().ToList();

                usersListView.ItemsSource = results;
            }
        }

        private void usersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (usersListView.SelectedItem is User selectedUser)
            {
                UserDetails._selectedUser = selectedUser;
                Navigation.PushAsync(new UserDetails());
            }
        }
    }
}
