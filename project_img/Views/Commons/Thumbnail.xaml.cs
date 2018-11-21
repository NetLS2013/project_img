using System;
using System.Collections.Generic;
using project_img.CustomRenderer;
using Xamarin.Forms;

namespace project_img.Views.Commons
{
    public partial class Thumbnail : BorderLayout
    {
        public double ThumbImageHeight
        {
            get { return Convert.ToDouble(GetValue(ImageHeightProperty)); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public double ThumbFontSize
        {
            get { return Convert.ToDouble(GetValue(LabelFontSizeProperty)); }
            set { SetValue(LabelFontSizeProperty, value); }
        }

        private static BindableProperty ImageHeightProperty = BindableProperty.Create(
            "ThumbImageHeight",
            typeof(double),
            typeof(Thumbnail),
            (double) 0,
            BindingMode.TwoWay,
            propertyChanged: ImageHeightPropertyChanged);

        private static BindableProperty LabelFontSizeProperty = BindableProperty.Create(
            "ThumbFontSize",
            typeof(double),
            typeof(Thumbnail),
            (double) 0,
            BindingMode.TwoWay,
            propertyChanged: LabelFontSizePropertyChanged);


        private static void ImageHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Thumbnail) bindable;
            control.ImageHeight.HeightRequest = Convert.ToDouble(newValue);
        }

        private static void LabelFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (Thumbnail) bindable;
            control.LabelWeather.FontSize = Convert.ToDouble(newValue);
            control.LabelAddress.FontSize = Convert.ToDouble(newValue);
        }


        public Thumbnail()
        {
            InitializeComponent();
        }
    }
}
