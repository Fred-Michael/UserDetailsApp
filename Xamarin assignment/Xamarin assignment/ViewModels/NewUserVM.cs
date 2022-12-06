using Plugin.Media;
using SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin_assignment.Models;

namespace Xamarin_assignment.ViewModels
{
    public class NewUserVM : INotifyPropertyChanged
    {
        public Command SaveUserCommand { get; set; }
        public Command AddUserPictureCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private Image _UserImage;
        public Image UserImage
        {
            set { _UserImage = value; OnPropertyChanged(); }
            get { return _UserImage; }
        }

        private User _user;
        public User User
        {
            set { _user = value; OnPropertyChanged(); }
            get { return _user; }
        }

        private string _name;
        public string Name
        {
            set { _name = value; OnPropertyChanged(); }
            get { return _name; }
        }

        private List<string> ListOfSex = new List<string>() { Sex.Female, Sex.Male };

        public IList<string> UserSexList { get { return ListOfSex; } }

        private string _selectedSex;
        public string SelectedSex
        {
            get { return _selectedSex; }
            set 
            {
                if (_selectedSex != value)
                {
                    _selectedSex = value; 
                    OnPropertyChanged();
                }
            }
        }

        private string _address;
        public string Address
        {
            set { _address = value; OnPropertyChanged(); }
            get { return _address; }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            set { _phoneNumber = value; OnPropertyChanged(); }
            get { return _phoneNumber; }
        }

        public NewUserVM()
        {
            SaveUserCommand = new Command(SaveUser);
            AddUserPictureCommand = new Command(AddPicture);
        }

        private void SaveUser()
        {
            User user = new User()
            {
                Name = Name,
                Sex = SelectedSex,
                Address = Address,
                PhoneNumber = PhoneNumber
            };

            int result = 0;
            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<User>();
                result = conn.Insert(user);
            }

            if (result == 1)
            {
                App.Current.MainPage.DisplayAlert("Success", "A new user has been added to the db", "OK");
                App.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Failure", "Unable to add new user to the db", "OK");
                App.Current.MainPage.Navigation.PopToRootAsync();
            }
        }

        private async void AddPicture()
        {
            try
            {
                var photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    AllowCropping = true,
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    Directory = "Xamarin_assignment",
                    SaveToAlbum = true,
                    CompressionQuality = 85
                });

                if (photo != null)
                {
                    UserImage.Source = ImageSource.FromStream(() =>
                    {
                        return photo.GetStream();
                    });
                }
            }
            catch (System.Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
