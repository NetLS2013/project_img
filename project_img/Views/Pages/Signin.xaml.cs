using System;
using System.Collections.Generic;
using project_img.ViewModels;
using Xamarin.Forms;

namespace project_img.Views.Pages
{
    public partial class Signin : ContentPage
    {
        public AuthorizationViewModel ViewModel { get; set; }

        public Signin()
        {
            InitializeComponent();

            BindingContext = ViewModel = new AuthorizationViewModel(this);
        }

        void Signup_Clicked(object sender, EventArgs e)
        {
            App.SetMainPage(new Signup());
        }
    }
}
