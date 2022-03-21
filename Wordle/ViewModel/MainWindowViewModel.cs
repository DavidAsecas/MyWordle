using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wordle.UI.View;

namespace Wordle.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ContentControl currentControl;
        private IDialogCoordinator dialogCoordinator;
        public ContentControl CurrentControl
        {
            get { return currentControl; }
            set { SetField(ref this.currentControl, value, nameof(CurrentControl)); }
        }

        public MainWindowViewModel()
        {
            CurrentControl = new IntroControl();
        }
    }
}
