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
    public partial class Signup : ContentPage
    {
        public AuthorizationViewModel ViewModel { get; set; }

        MediaFile _mediaFile;
        TapGestureRecognizer _tapAvatarImage;

        public Signup()
        {
            InitializeComponent();

            BindingContext = ViewModel = new AuthorizationViewModel(this);

            _tapAvatarImage = new TapGestureRecognizer();
            _tapAvatarImage.Tapped += AvatarImage_Tapped;

            Avatar.GestureRecognizers.Add(_tapAvatarImage);
        }

        void Signin_Clicked(object sender, System.EventArgs e)
        {
            App.SetMainPage(new Signin());
        }

        async void AvatarImage_Tapped(object sender, EventArgs e)
        {
            var request = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);

            if (request[Permission.Storage] == PermissionStatus.Granted)
            {
                await CrossMedia.Current.Initialize();

                _mediaFile = await CrossMedia.Current.PickPhotoAsync();

                if (_mediaFile == null)
                    return;

                ViewModel.Avatar = _mediaFile;
                Avatar.Source = ImageSource.FromStream(_mediaFile.GetStream);
            }
        }
    }
}
