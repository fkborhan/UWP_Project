using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace MonthlyProject
{
    public class Command : ICommand
    {
        private Action methodToExecute = null;
        private DispatcherTimer canExecuteChangedEventTimer = null;
        private Func<bool> methodToDetectCanExecute = null;
        public Command(Action methodToExecute, Func<bool> methodToDetectCanExecute)
        {
            this.methodToExecute = methodToExecute;
            this.methodToDetectCanExecute = methodToDetectCanExecute;
            this.canExecuteChangedEventTimer = new DispatcherTimer();
            this.canExecuteChangedEventTimer.Tick +=
            canExecuteChangedEventTimer_Tick;
            this.canExecuteChangedEventTimer.Interval = new TimeSpan(0, 0, 1);
            this.canExecuteChangedEventTimer.Start();

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (this.methodToDetectCanExecute == null)
            {
                return true;
            }
            else
            {
                return this.methodToDetectCanExecute();
            }

        }

        public void Execute(object parameter)
        {
            this.methodToExecute();
        }
        void canExecuteChangedEventTimer_Tick(object sender, object e)
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
