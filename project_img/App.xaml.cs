using System;
using project_img.Helpers;
using project_img.Views.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace project_img
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var startPage = typeof(Signup);

            if (Equals(Settings.Get(Settings.Key.IsLogged), true))
            {
                startPage = typeof(AddImage);
            }

            MainPage = (Page)Activator.CreateInstance(startPage);
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
