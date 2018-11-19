﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmValidation;
using Plugin.Media.Abstractions;
using project_img.Helpers;
using project_img.Models.Authorization;
using project_img.Services;
using Xamarin.Forms;

namespace project_img.ViewModels
{
    public class AuthorizationViewModel : BaseViewModel
    {
        readonly Page _context;
        readonly RequestService _requestProvider;
        ValidationErrorCollection _errors;

        string _email;
        string _userName;
        string _password;
        MediaFile _avatar;

        public ICommand SignUpCommand => new Command(async () => await SignUpHundle());

        public AuthorizationViewModel(Page context)
        {
            _context = context;
            _requestProvider = new RequestService();
        }


        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;

                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (_userName != value)
                {
                    _userName = value;

                    OnPropertyChanged(nameof(UserName));
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;

                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public MediaFile Avatar
        {
            get
            {
                return _avatar;
            }
            set
            {
                if (_avatar != value)
                {
                    _avatar = value;

                    OnPropertyChanged(nameof(Avatar));
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


        private async Task SignUpHundle()
        {
            var validator = new ValidationHelper();

            try
            {
                var createRequest = new CreateModel.R {
                    UserName = _userName,
                    Email = _email,
                    Password = _password
                };

                var (success, error) = await _requestProvider
                    .PostFormDataAsync<CreateModel.R, CreateModel.S, CreateModel.E>(
                        GlobalSetting.Instance.SignUpEndpoint,
                        createRequest,
                        _avatar?.GetStream()
                    );

                if (error != null)
                {
                    validator.AddErrors(nameof(UserName), error.Children.Username.Errors);
                    validator.AddErrors(nameof(Email), error.Children.Email.Errors);
                    validator.AddErrors(nameof(Password), error.Children.Password.Errors);
                    validator.AddErrors(nameof(Avatar), error.Children.Avatar.Errors);
                }

                if (!Validate(validator))
                {
                    return;
                }

                if (success != null)
                {
                    await Settings.Set(Settings.Key.IsLogged, true);
                    await Settings.Set(Settings.Key.Avatar, success.Avatar);
                    await Settings.Set(Settings.Key.Token, success.Token);

                    await _context.Navigation.PushAsync(new ContentPage());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"--- Error: {e.StackTrace}");
            }
        }
    }
}