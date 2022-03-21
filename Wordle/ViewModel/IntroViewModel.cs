using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wordle.BusinessLogic;
using Wordle.DataAccess;
using Wordle.UI.Model;

namespace Wordle.UI.ViewModel
{
    public class IntroViewModel : ViewModelBase
    {
        private ICommand startCommand;
        private readonly IDialogCoordinator dialogCoordinator;

        public ICommand StartCommand
        {
            get
            {
                if (startCommand == null)
                {
                    startCommand = new RelayCommand<IContentSwitcher>(window => ExecuteStartCommand(window));
                }

                return startCommand;
            }
        }

        public IntroViewModel(IDialogCoordinator dialogCoordinator)
        {
            this.dialogCoordinator = dialogCoordinator;
        }

        private async void ExecuteStartCommand(IContentSwitcher window)
        {
            var numberOfLetters = await this.dialogCoordinator.ShowInputAsync(this, "", "Cuantas letras?");
            var wordsService = DependencyBuilder.GetWordsService();
            var newWord = await wordsService.GetRandomWord(numberOfLetters);
            window.ChangeCurrentContent(ContentControlBuilder.GetWordleContent(newWord));
        }
    }
}
