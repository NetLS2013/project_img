﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmValidation;
using Plugin.Media.Abstractions;
using project_img.Helpers;
using project_img.Models.Image;
using project_img.Services;
using Xamarin.Forms;

namespace project_img.ViewModels
{
    public class ImageViewModel : BaseViewModel
    {
        readonly Page _context;
        readonly RequestService _requestProvider;
        ValidationErrorCollection _errors;

        string _description;
        string _hashtag;
        string _latitude;
        string _longitude;
        MediaFile _image;

        public ICommand UploadCommand => new Command(async () => await UploadHundle());

        public ImageViewModel(Page context)
        {
            _context = context;
            _requestProvider = new RequestService();
        }


        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;

                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string Hashtag
        {
            get
            {
                return _hashtag;
            }
            set
            {
                if (_hashtag != value)
                {
                    _hashtag = value;

                    OnPropertyChanged(nameof(Hashtag));
                }
            }
        }

        public string Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                if (_latitude != value)
                {
                    _latitude = value;

                    OnPropertyChanged(nameof(Latitude));
                }
            }
        }

        public string Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                if (_longitude != value)
                {
                    _longitude = value;

                    OnPropertyChanged(nameof(Longitude));
                }
            }
        }

        public MediaFile Image
        {
            get
            {
                return _image;
            }
            set
            {
                if (_image != value)
                {
                    _image = value;

                    OnPropertyChanged(nameof(Image));
                }
            }
        }

        public ValidationErrorCollection Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;

                OnPropertyChanged(nameof(Errors));
            }
        }


        private bool Validate(ValidationHelper validator)
        {
            var result = validator.ValidateAll();

            Errors = result.ErrorList;

            return result.IsValid;
        }


        private async Task UploadHundle()
        {
            var validator = new ValidationHelper();

            try
            {
                var createRequest = new ImageModel.R
                {
                    Description = _description,
                    Hashtag = _hashtag,
                    Latitude = "48.9215", //TODO: get location from image or hardware gps
                    Longitude = "24.70972"
                };

                var (success, error) = await _requestProvider
                    .PostFormDataAsync<ImageModel.R, ImageModel.S, ImageModel.E>(
                        GlobalSetting.Instance.SignUpEndpoint,
                        createRequest,
                        _image?.GetStream()
                    );

                if (error != null)
                {
                    validator.AddErrors(nameof(Description), error.Children.Description.Errors);
                    validator.AddErrors(nameof(Hashtag), error.Children.Hashtag.Errors);
                    validator.AddErrors(nameof(Latitude), error.Children.Latitude.Errors);
                    validator.AddErrors(nameof(Longitude), error.Children.Longitude.Errors);
                    validator.AddErrors(nameof(Image), error.Children.Image.Errors);
                }

                if (!Validate(validator))
                {
                    return;
                }

                if (success != null)
                {
                    //TODO: better store in sqlite, and caching image

                    await _context.Navigation.PopAsync();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"--- Error: {e.StackTrace}");
            }
        }
    }
}