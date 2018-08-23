using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Fessad_TL.Annotations;
using PropertyChanged;

namespace Fessad_TL
{
    [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, x) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        protected async Task RunCommand(Expression<Func<bool>> func, Func<Task> action)
        {
            // Check if another process is already running
            if (func.GetPrpertyValue())
                return;

            // Set the value tru to tell every other command the line is busy
            func.SetPropertyValue(true);

            try
            {
                // Run the command
                await action();
            }
            finally
            {
                // Indicating function is free right now
                func.SetPropertyValue(false);
            }

            

        }

    }
}
