using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_assignment.Models;
using Xamarin_assignment.ViewModels;

namespace Xamarin_assignment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetails : ContentPage
    {
        private User _selectedUser;
        public UserDetails(User selectedUser)
        {
            InitializeComponent();
            _selectedUser = selectedUser;
            //SetFields(_selectedUser);
            BindingContext = new UserDetailsVM();

            //try the below:
            var user = new UserDetailsVM();
            user._selectedUser = _selectedUser;

        }

        private async void UpdateUserButton_Clicked(object sender, EventArgs e)
        {
            var updatedUser = UpdateFields();
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                var choice = await DisplayAlert(
                    "Update User",
                    $"Are you sure you want to update this record?",
                    "Yes",
                    "No");

                if (choice)
                {
                    conn.Update(updatedUser);
                    await Navigation.PopToRootAsync();
                }
            }
        }

        private async void DeleteUserButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                var choice = await DisplayAlert(
                    "Delete User",
                    $"Are you sure you want to delete {_selectedUser.Name}?",
                    "Yes",
                    "No");

                if (choice)
                {
                    conn.Delete(_selectedUser);
                    await Navigation.PopToRootAsync();
                }
            }
        }

        //private void SetFields(User user)
        //{
        //    update_user_name.Text = user.Name;
        //    update_user_address.Text = user.Address;
        //    update_user_sex.Text = user.Sex;
        //    update_user_number.Text = user.PhoneNumber;
        //}

        private User UpdateFields()
        {
            _selectedUser.Name = update_user_name.Text;
            _selectedUser.Address = update_user_address.Text;
            //_selectedUser.Sex = update_user_sex.Text;
            _selectedUser.PhoneNumber = update_user_number.Text;
            return _selectedUser;
        }
    }
}