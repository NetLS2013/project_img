using System;
using Android.Content;
using project_img.CustomRenderer;
using project_img.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderLayout), typeof(BorderRenderer))]
namespace project_img.Droid.Renderer
{
    public class BorderRenderer : VisualElementRenderer<StackLayout>
    {
        public BorderRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);
            SetBackgroundResource(Resource.Drawable.gray_border);
        }
    }
}
