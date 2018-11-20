using System;
using System.Collections.Generic;
using project_img.ViewModels;
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
    }
}
