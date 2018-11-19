using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace project_img.Helpers
{
    public static class Settings
    {
        public static object Get(Key key)
        {
            Application.Current.Properties.TryGetValue(key.ToString(), out object value);

            return value;
        }

        public static async Task Set(Key key, object value)
        {
            Application.Current.Properties[key.ToString()] = value;
            await Application.Current.SavePropertiesAsync();
        }

        public enum Key
        {
            Avatar,
            Token,
            IsLogged
        }
    }
}
