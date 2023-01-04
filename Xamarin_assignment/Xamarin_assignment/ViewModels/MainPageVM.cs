using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin_assignment.Models;
using Xamarin_assignment.Services;
using Xamarin_assignment.Views;

namespace Xamarin_assignment.ViewModels
{
    public class MainPageVM : INotifyPropertyChanged
    {
        public Command UserNavigationCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<User> _payload;
        public ObservableCollection<User> Payload
        {
            get => _payload;
            set
            {
                _payload = value;
            }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
            }
        }

        public MainPageVM()
        {
            OnLoad();
            UserNavigationCommand = new Command(NewUserNavigation);
        }

        private void NewUserNavigation()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewUser());
        }

        internal virtual void OnLoad()
        {
            Payload = new ObservableCollection<User>();
            Payload.Clear();
            Payload = UserService.GetAllUsers();
        }

        internal virtual void UserSelected(User user)
        {
            if (user != null)
            {
                UserDetails.SelectedUser = user;
                App.Current.MainPage.Navigation.PushAsync(new UserDetails());
            }
        }
    }
}
