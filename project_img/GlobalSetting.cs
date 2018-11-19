using System;

namespace project_img
{
    public class GlobalSetting
    {
        public static GlobalSetting Instance => Nested.Instance;

        public string SignUpEndpoint { get; private set; }
        public string ImageEndpoint { get; private set; }

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
            ImageEndpoint = $"{dotItEndpoint}/image";
        }

        class Nested
        {
            static Nested() { }
            
            internal static readonly GlobalSetting Instance = new GlobalSetting();
        }
    }
}
