using Plugin.Media;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin_assignment.Models;
using Xamarin_assignment.Services;

namespace Xamarin_assignment.ViewModels
{
    public class NewUserVM : INotifyPropertyChanged
    {
        public Command SaveUserCommand { get; set; }
        public Command AddUserPictureCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private User _user;
        public User User
        {
            set { _user = value; OnPropertyChanged(); }
            get => _user;
        }

        private string _name;
        public string Name
        {
            set { _name = value; OnPropertyChanged(); }
            get => _name;
        }

        private ImageSource _image;
        public ImageSource UserImage
        {
            set { _image = value; OnPropertyChanged(); }
            get => _image;
        }

        private ObservableCollection<string> _listOfSex = new ObservableCollection<string>
        {
            Sex.Female.ToString(),
            Sex.Male.ToString()
        };

        public ObservableCollection<string> UserSexList
        {
            get => _listOfSex;
            set
            {
                _listOfSex = value;
            }
        }

        private Sex _selectedSex;
        public Sex SelectedSex
        {
            get => _selectedSex;
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
            get => _address;
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            set { _phoneNumber = value; OnPropertyChanged(); }
            get => _phoneNumber;
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

            UserService.SaveUser(user);
        }

        private async void AddPicture()
        {
            await CrossMedia.Current.Initialize();

            UserImage = await PhotoService.SavePicture();
        }
    }
}
