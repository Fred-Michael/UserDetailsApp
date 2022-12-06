using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_assignment.Models;
using Xamarin_assignment.ViewModels;

namespace Xamarin_assignment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetails : ContentPage
    {
        public static User _selectedUser { get; set; }
        public UserDetails()
        {
            InitializeComponent();
            BindingContext = new UserDetailsVM(_selectedUser);
        }
    }
}