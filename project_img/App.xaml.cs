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

            var startPage = typeof(Gallery);

            if (Equals(Settings.Get(Settings.Key.IsLogged), false))
            {
                startPage = typeof(Signin);
            }
            else if (Settings.Get(Settings.Key.IsLogged) == null)
            {
                startPage = typeof(Signup);
            }

            SetMainPage((Page) Activator.CreateInstance(startPage));
        }

        public static void SetMainPage(Page page)
        {
            var navigationPage = new NavigationPage(page);

            Current.MainPage = navigationPage;
        }

        protected override void OnStart() {}

        protected override void OnSleep() {}

        protected override void OnResume() {}
    }
}
