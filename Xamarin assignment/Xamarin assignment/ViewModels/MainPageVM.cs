using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

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

        public MainPageVM()
        {
            UserNavigationCommand = new Command(NewUserNavigation);
        }

        private void NewUserNavigation()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewUser());
        }
    }
}
