using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Plugin.Permissions;
using ImageCircle.Forms.Plugin.Droid;
using DLToolkit.Forms.Controls;
using CrossCurrentActivity = Plugin.CurrentActivity.CrossCurrentActivity;
using Rg.Plugins.Popup;

namespace project_img.Droid
{
    [Activity(
        Label = "project_img",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation
    )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Popup.Init(this, savedInstanceState);

            ImageCircleRenderer.Init();
            FlowListView.Init();

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}