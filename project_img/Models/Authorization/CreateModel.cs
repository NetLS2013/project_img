using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace project_img.Models.Authorization
{
    public class CreateModel
    {
        public class R
        {
            [JsonProperty("username")]
            public string UserName { get; set; }

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
            [JsonProperty("children")]
            public ChildrenRoot Children { get; set; }        
        
            public class ChildrenRoot
            {
                [JsonProperty("username")]
                public ErrorsList Username { get; set; }
                
                [JsonProperty("email")]
                public ErrorsList Email { get; set; }
                
                [JsonProperty("password")]
                public ErrorsList Password { get; set; }
                
                [JsonProperty("avatar")]
                public ErrorsList Avatar { get; set; }
            }

            public class ErrorsList
            {
                [JsonProperty("errors")]
                public List<string> Errors { get; set; }
            }
        }
    }
}
