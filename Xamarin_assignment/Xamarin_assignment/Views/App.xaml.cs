using Xamarin.Forms;

namespace Xamarin_assignment
{
    public partial class App : Application
    {
        public static string databaseLocation = "";

        public App(string dbLocation)
        {
            InitializeComponent();
            databaseLocation = dbLocation;

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
