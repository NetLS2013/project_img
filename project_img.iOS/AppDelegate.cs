using System;
using System.Collections.Generic;
using System.Linq;
using DLToolkit.Forms.Controls;
using FFImageLoading.Forms.Platform;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using Rg.Plugins.Popup;
using UIKit;

namespace project_img.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Popup.Init();
            ImageCircleRenderer.Init();
            FlowListView.Init();
            CachedImageRenderer.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
