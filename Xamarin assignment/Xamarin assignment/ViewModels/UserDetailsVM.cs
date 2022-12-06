using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin_assignment.Models;

namespace Xamarin_assignment.ViewModels
{
    public class UserDetailsVM : INotifyPropertyChanged
    {
        public Command UpdateUserCommand { get; set; }
        public Command DeleteUserCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private User _user;
        public User User
        {
            set { _user = value; OnPropertyChanged(); }
            get { return _user; }
        }

        private string _name;
        public string Name
        {
            set { _name = value; OnPropertyChanged(); }
            get { return _name; }
        }

        private string _address;
        public string Address
        {
            set { _address = value; OnPropertyChanged(); }
            get { return _address; }
        }

        private string _sex;
        public string Sex
        {
            set { _sex = value; OnPropertyChanged(); }
            get { return _sex; }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            set { _phoneNumber = value; OnPropertyChanged(); }
            get { return _phoneNumber; }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            set { _selectedUser = value; OnPropertyChanged(); }
            get { return _selectedUser; }
        }

        public UserDetailsVM(User selectedUser)
        {
            _selectedUser = selectedUser;
            UpdateUserCommand = new Command(UpdateUser);
            DeleteUserCommand = new Command(DeleteUser);

            SetFields(_selectedUser);
        }

        private async void UpdateUser()
        {
            var updatedUser = UpdateFields();
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                var choice = await App.Current.MainPage.DisplayAlert(
                    "Update User",
                    $"Are you sure you want to update this record?",
                    "Yes",
                    "No");

                if (choice)
                {
                    conn.Update(updatedUser);
                    await App.Current.MainPage.Navigation.PopToRootAsync();
                }
            }
        }

        private async void DeleteUser()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                var choice = await App.Current.MainPage.DisplayAlert(
                    "Delete User",
                    $"Are you sure you want to delete {_selectedUser.Name}?",
                    "Yes",
                    "No");

                if (choice)
                {
                    conn.Delete(_selectedUser);
                    await App.Current.MainPage.Navigation.PopToRootAsync();
                }
            }
        }

        private void SetFields(User user)
        {
            Name = user == null ? "" : user.Name;
            Address = user == null ? "" : user.Address;
            //Sex = user.Sex;
            PhoneNumber = user == null ? "" : user.PhoneNumber;
        }

        private User UpdateFields()
        {
            _selectedUser.Name = Name;
            _selectedUser.Address = Address;
            //_selectedUser.Sex = update_user_sex.Text;
            _selectedUser.PhoneNumber = PhoneNumber;
            return _selectedUser;
        }

    }
}
