using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XWSDGCat.Common
{
    public class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void DoNotify(string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
