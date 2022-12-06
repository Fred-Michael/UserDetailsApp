using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin_assignment.Models;

namespace Xamarin_assignment.ViewModels
{
    public class UserDetailsVM : ContentPage, INotifyPropertyChanged
    {
        public Command UpdateUserCommand { get; set; }
        public Command DeleteUserCommand { get; set; }

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected override void OnPropertyChanged([CallerMemberName] string name = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}

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

        //private User _selectedUser { get; set; }
        public User _selectedUser { get; set; }

        public UserDetailsVM()
        {
            //_selectedUser = selectedUser;
            UpdateUserCommand = new Command(UpdateUser);
            DeleteUserCommand = new Command(DeleteUser);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetFields(_selectedUser);
        }

        private void UpdateUser()
        {

        }

        private void DeleteUser()
        {

        }

        private void SetFields(User user)
        {
            Name = user.Name;
            Address = user.Address;
            Sex = user.Sex;
            PhoneNumber = user.PhoneNumber;
        }

        //private User UpdateFields()
        //{
        //    _selectedUser.Name = update_user_name.Text;
        //    _selectedUser.Address = update_user_address.Text;
        //    _selectedUser.Sex = update_user_sex.Text;
        //    _selectedUser.PhoneNumber = update_user_number.Text;
        //    return _selectedUser;
        //}

    }
}
