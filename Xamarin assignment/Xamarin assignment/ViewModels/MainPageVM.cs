using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin_assignment.Models;
using Xamarin_assignment.Services;
using Xamarin_assignment.Services.Interfaces;
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
            get { return _payload; }
            set
            {
                _payload = value;
            }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public MainPageVM()
        {

            //replace this call with a service layer call
            //var service = new UserService();
            Payload = UserService.GetAllUsers();
            //Payload = new UserService();
            //using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            //{
            //    conn.CreateTable<User>();
            //    Payload = new ObservableCollection<User>(conn.Table<User>().ToList());

            //    //Payload = results;

            //    //usersListView.ItemsSource = results;
            //}

            UserNavigationCommand = new Command(NewUserNavigation);
        }

        private void NewUserNavigation()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewUser());
        }

        internal virtual void UserSelected(User user)
        {
            //System.Console.WriteLine(e);
            //UserDetails._selectedUser = selectedUser;
            //App.Current.MainPage.Navigation.PushAsync(new UserDetails());
            if (user != null)
            {
                UserDetails._selectedUser = user;
                App.Current.MainPage.Navigation.PushAsync(new UserDetails());
            }
        }

        //internal virtual void OnAppearing()
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
        //    {
        //        conn.CreateTable<User>();
        //        Payload = new ObservableCollection<User>(conn.Table<User>().ToList());

        //        //Payload = results;

        //        //usersListView.ItemsSource = results;
        //    }
        //}
    }
}
