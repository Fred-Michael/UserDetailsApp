using Xamarin.Forms;
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
    }
}
