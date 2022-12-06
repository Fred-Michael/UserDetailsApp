using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Plugin.Media;
using System.IO;

namespace Xamarin_assignment.Droid
{
    [Activity(Label = "Xamarin_assignment", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            await CrossMedia.Current.Initialize();

            string db = "android_user_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string dbPath = Path.Combine(folderPath, db);

            LoadApplication(new App(dbPath));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}