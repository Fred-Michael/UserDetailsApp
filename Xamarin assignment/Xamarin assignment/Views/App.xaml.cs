using Xamarin.Forms;
using Xamarin_assignment.DIContainer;
using Xamarin_assignment.Services.Interfaces;

namespace Xamarin_assignment
{
    public partial class App : Application
    {
        public static string databaseLocation = "";
        private readonly IUserService _userService;

        // perform some code clean up for these two ctors
        //public App(IUserService userService)
        //{
        //    _userService = userService;
        //    InitializeComponent();

        //    MainPage = new NavigationPage(new MainPage());
        //}

        public App(string dbLocation)
        {
            InitializeComponent();
            databaseLocation = dbLocation;
            AppContainer.ConfigureServices();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
