using System;
using Newtonsoft.Json;

namespace project_img.Models.Image
{
    public class GifModel
    {
        public class R
        {
            [JsonProperty("weather")]
            public string Weather { get; set; }
        }

        public class S
        {
            [JsonProperty("gif")]
            public string Gif { get; set; }
        }

        public class E { }
    }
}
