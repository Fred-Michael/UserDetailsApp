using Plugin.Media;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin_assignment.Services
{
    public class PhotoService
    {
        public static async Task<ImageSource> SavePicture()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No camera available", "OK");
                return null;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
                Name = $"{DateTime.Now}_photo.jpg"
            });

            if (file == null)
                return null;

            return ImageSource.FromStream(() =>
            {
                var result = file.GetStream();
                return result;
            });
        }
    }
}
