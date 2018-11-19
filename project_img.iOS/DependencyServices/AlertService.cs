using System;
using Foundation;
using project_img.Interfaces;
using project_img.iOS.DependencyServices;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(AlertService))]
namespace project_img.iOS.DependencyServices
{
    public class AlertService : IAlertService
    {
        const double LONG_DELAY = 3.5;
        const double SHORT_DELAY = 2.0;

        NSTimer alertDelay;
        UIAlertController alert;

        public void Long(string message)
        {
            ShowAlert(message, LONG_DELAY);
        }

        public void Short(string message)
        {
            ShowAlert(message, SHORT_DELAY);
        }

        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) => {
                DismissMessage();
            });

            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.ActionSheet);

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        private void DismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }

            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}
