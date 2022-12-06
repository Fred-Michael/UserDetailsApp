using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin_assignment.Models;
using Xamarin_assignment.Views;

namespace Xamarin_assignment.ViewModels
{
    public class MainPageVM : INotifyPropertyChanged
    {
        public Command UserNavigationCommand { get; set; }
        public Command SelectedUserCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainPageVM()
        {
            UserNavigationCommand = new Command(NewUserNavigation);
            SelectedUserCommand = new Command<ListView>(UserSelectionCommand);
        }

        private void UserSelectionCommand(ListView SelectedItem)
        {
            if (SelectedItem.SelectedItem is User selected)
            {
                App.Current.MainPage.Navigation.PushAsync(new UserDetails(selected));
            }
        }

        private void NewUserNavigation()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewUser());
        }
    }
}
