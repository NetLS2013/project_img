using System;
using project_img.CustomRenderer;
using project_img.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderLayout), typeof(BorderRenderer))]
namespace project_img.iOS.Renderer
{
    public class BorderRenderer : VisualElementRenderer<StackLayout>
    {
        public BorderRenderer()
        {
            Layer.BorderColor = UIColor.FromRGB(162, 162, 162).CGColor;
            Layer.BorderWidth = 2;
        }
    }
}
