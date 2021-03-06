﻿using System;

namespace project_img
{
    public class GlobalSetting
    {
        public static GlobalSetting Instance => Nested.Instance;

        public string SignUpEndpoint { get; private set; }
        public string SignInEndpoint { get; private set; }
        public string ImageEndpoint { get; private set; }
        public string ImageAllEndpoint { get; private set; }
        public string GifEndpoint { get; private set; }

        GlobalSetting()
        {
            DoItEndpoint = "http://api.doitserver.in.ua";
        }

        string DoItEndpoint
        {
            set => UpdateDoItEndpoint(value);
        }

        void UpdateDoItEndpoint(string dotItEndpoint)
        {
            SignUpEndpoint = $"{dotItEndpoint}/create";
            SignInEndpoint = $"{dotItEndpoint}/login";
            ImageEndpoint = $"{dotItEndpoint}/image";
            ImageAllEndpoint = $"{dotItEndpoint}/all";
            GifEndpoint = $"{dotItEndpoint}/gif";
        }

        class Nested
        {
            static Nested() {}
            
            internal static readonly GlobalSetting Instance = new GlobalSetting();
        }
    }
}
