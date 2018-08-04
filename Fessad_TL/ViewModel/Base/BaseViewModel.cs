using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fessad_TL.Annotations;
using PropertyChanged;

namespace Fessad_TL
{
    [ImplementPropertyChanged]
    internal class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, x) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        
    }
}
