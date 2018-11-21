using System;
using System.Collections.Generic;
using project_img.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace project_img.Views.Pages
{
    public partial class GenerateGif : PopupPage
    {
        public GenerateGif(ImageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
