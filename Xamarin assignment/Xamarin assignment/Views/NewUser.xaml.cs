using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_assignment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUser : ContentPage
    {
        //private readonly IUserService _userService;
        //public NewUser(IUserService userService)
        //{
        //    InitializeComponent();
        //    _userService = userService;
        //}

        public NewUser()
        {
            InitializeComponent();
        }
    }
}