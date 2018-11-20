using System;
using System.Collections.Generic;
using project_img.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace project_img.Views.Pages
{
    public partial class Gallery : ContentPage
    {
        public ImageViewModel ViewModel { get; set; }

        public Gallery()
        {
            InitializeComponent();

            BindingContext = ViewModel = new ImageViewModel(this);
        }

        async void AddImage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddImage(ViewModel));
        }

        async void GenerateGif_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new GenerateGif());
        }
    }
}
