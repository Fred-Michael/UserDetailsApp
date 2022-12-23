using Xamarin.Forms;
using Xamarin_assignment.Models;
using Xamarin_assignment.ViewModels;

namespace Xamarin_assignment
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new MainPageVM();
        }

        private void UsersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            User user = e.SelectedItem as User;
            (BindingContext as MainPageVM)?.UserSelected(user);
        }
    }
}
