using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_assignment.ViewModels;

namespace Xamarin_assignment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUser : ContentPage
    {
        public NewUser()
        {
            InitializeComponent();
            BindingContext = new NewUserVM();
        }
    }
}