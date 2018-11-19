using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace project_img.Models.Authorization
{
    public class LoginModel : ContentPage
    {
        public class R
        {
            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }
        }

        public class S
        {
            [JsonProperty("creation_time")]
            public DateTimeOffset CreationTime { get; set; }

            [JsonProperty("token")]
            public string Token { get; set; }

            [JsonProperty("avatar")]
            public Uri Avatar { get; set; }
        }

        public class E
        {
            [JsonProperty("error")]
            public string Error { get; set; }
        }
    }
}

