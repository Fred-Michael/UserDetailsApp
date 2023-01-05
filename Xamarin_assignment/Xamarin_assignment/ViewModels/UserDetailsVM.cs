using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin_assignment.Models;
using Xamarin_assignment.Services;

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
            get => _user;
        }

        private string _name;
        public string Name
        {
            set { _name = value; OnPropertyChanged(); }
            get => _name;
        }

        private string _address;
        public string Address
        {
            set { _address = value; OnPropertyChanged(); }
            get => _address;
        }

        private ObservableCollection<string> _listOfSex = new ObservableCollection<string>
        {
            Sex.Female.ToString(),
            Sex.Male.ToString()
        };

        public ObservableCollection<string> UserSexList
        {
            get => _listOfSex;
            set
            {
                _listOfSex = value;
            }
        }

        private Sex _selectedSex;
        public Sex SelectedSex
        {
            get => _selectedSex;
            set
            {
                if (_selectedSex != value)
                {
                    _selectedSex = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            set { _phoneNumber = value; OnPropertyChanged(); }
            get => _phoneNumber;
        }

        private User _selectedUser;
        public User SelectedUser
        {
            set { _selectedUser = value; OnPropertyChanged(); }
            get => _selectedUser;
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
            User updatedUser = UpdateFields();
            int result = await UserService.ActionUser(false, updatedUser);

            if (result >= 1)
            {
                await App.Current.MainPage.Navigation.PopToRootAsync();
            }
        }

        private async void DeleteUser()
        {
            int result = await UserService.ActionUser(true, SelectedUser);

            if (result >= 1)
            {
                await App.Current.MainPage.Navigation.PopToRootAsync();
            }
        }

        private void SetFields(User user)
        {
            Name = user == null ? "" : user.Name;
            Address = user == null ? "" : user.Address;

            if (user.Sex.ToString() == "Female")
            {
                SelectedSex = user.Sex;
            }
            else
            {
                SelectedSex = user.Sex;
            }

            PhoneNumber = user == null ? "" : user.PhoneNumber;
        }

        private User UpdateFields()
        {
            _selectedUser.Name = Name;
            _selectedUser.Address = Address;
            _selectedUser.Sex = SelectedSex;
            _selectedUser.PhoneNumber = PhoneNumber;
            return _selectedUser;
        }
    }
}