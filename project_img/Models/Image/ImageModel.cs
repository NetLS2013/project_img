using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace project_img.Models.Image
{
    public class ImageModel
    {
        public class R
        {
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("hashtag")]
            public string Hashtag { get; set; }

            [JsonProperty("latitude")]
            public string Latitude { get; set; }

            [JsonProperty("longitude")]
            public string Longitude { get; set; }
        }

        public class S
        {
            [JsonProperty("parameters")]
            public ParametersRoot Parameters { get; set; }

            [JsonProperty("smallImage")]
            public string SmallImage { get; set; }

            [JsonProperty("bigImage")]
            public string BigImage { get; set; }

            public class ParametersRoot
            {

                [JsonProperty("address")]
                public string Address { get; set; }

                [JsonProperty("weather")]
                public string Weather { get; set; }
            }
        }

        public class E
        {
            [JsonProperty("children")]
            public ChildrenRoot Children { get; set; }

            public class ChildrenRoot
            {
                [JsonProperty("image")]
                public ErrorsList Image { get; set; }

                [JsonProperty("description")]
                public ErrorsList Description { get; set; }

                [JsonProperty("hashtag")]
                public ErrorsList Hashtag { get; set; }

                [JsonProperty("latitude")]
                public ErrorsList Latitude { get; set; }

                [JsonProperty("longitude")]
                public ErrorsList Longitude { get; set; }
            }

            public class ErrorsList
            {
                [JsonProperty("errors")]
                public List<string> Errors { get; set; }
            }
        }
    }
}
