using System;
using Android.App;
using Android.Widget;
using project_img.Droid.DependencyServices;
using project_img.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(AlertService))]
namespace project_img.Droid.DependencyServices
{
    public class AlertService : IAlertService
    {
        public void Long(string message)
        {
            Toast.MakeText(
                Application.Context,
                message,
                ToastLength.Long
            ).Show();
        }

        public void Short(string message)
        {
            Toast.MakeText(
                Application.Context,
                message,
                ToastLength.Short
            ).Show();
        }
    }
}
