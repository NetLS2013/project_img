using System;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using project_img.ViewModels;
using Xamarin.Forms;

namespace project_img.Views.Pages
{
    public partial class AddImage : ContentPage
    {
        public ImageViewModel ViewModel { get; set; }

        MediaFile _mediaFile;
        TapGestureRecognizer _tapAvatarImage;

        public AddImage(ImageViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = ViewModel = viewModel;

            _tapAvatarImage = new TapGestureRecognizer();
            _tapAvatarImage.Tapped += Image_Tapped;

            Image.GestureRecognizers.Add(_tapAvatarImage);
        }

        async void Image_Tapped(object sender, EventArgs e)
        {
            var request = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);

            if (request[Permission.Storage] == PermissionStatus.Granted)
            {
                await CrossMedia.Current.Initialize();

                _mediaFile = await CrossMedia.Current.PickPhotoAsync();

                if (_mediaFile == null)
                    return;

                ViewModel.Image = _mediaFile;
                Image.Source = ImageSource.FromStream(_mediaFile.GetStream);
            }
        }
    }
}
