using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace project_img.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, Action action = null, IEnumerable<string> additionalprops = null, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);

            if (additionalprops != null)
            {
                foreach (var s in additionalprops)
                    OnPropertyChanged(s);
            }

            action?.Invoke();

            return true;
        }

        bool _isbusy;

        public bool IsBusy
        {
            get { return this._isbusy; }
            set { SetField(ref this._isbusy, value); }
        }
    }
}
