using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace project_img.Models.Image
{
    public class GalleryModel
    {
        public class R { }

        public class S
        {
            [JsonProperty("images")]
            public IList<Image> Images { get; set; }

            public class Image
            {

                [JsonProperty("id")]
                public int Id { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("hashtag")]
                public string Hashtag { get; set; }

                [JsonProperty("parameters")]
                public ParametersRoot Parameters { get; set; }

                [JsonProperty("smallImagePath")]
                public string SmallImagePath { get; set; }

                [JsonProperty("bigImagePath")]
                public string BigImagePath { get; set; }

                [JsonProperty("created")]
                public string Created { get; set; }
            }

            public class ParametersRoot
            {

                [JsonProperty("longitude")]
                public int Longitude { get; set; }

                [JsonProperty("latitude")]
                public int Latitude { get; set; }

                [JsonProperty("weather")]
                public string Weather { get; set; }
            }
        }

        public class E { }
    }
}
