using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wordle.BusinessLogic;
using Wordle.UI.Model;

namespace Wordle.UI.ViewModel
{
    public class WordleViewModel : ViewModelBase
    {
        private WordleModel wordle;
        private readonly IDialogCoordinator dialogCoordinator;
        private ObservableCollection<WordTryViewModel> tryWords;
        private WordTryViewModel currentTryWord;
        private ICommand checkWordCommand;
        private ICommand newGameCommand;

        public ObservableCollection<WordTryViewModel> TryWords { get => tryWords; set => SetField(ref tryWords, value, nameof(TryWords)); }

        public WordTryViewModel CurrentTryWord { get => currentTryWord; set => SetField(ref currentTryWord, value, nameof(CurrentTryWord)); }

        public ICommand CheckWordCommand
        {
            get
            {
                if (checkWordCommand == null)
                {
                    checkWordCommand = new RelayCommand(_ => ExecuteCheckWord(), _ => CanExecuteCheckWord());
                }

                return checkWordCommand;
            }
        }

        public ICommand NewGameCommand
        {
            get
            {
                if (newGameCommand == null)
                {
                    newGameCommand = new RelayCommand<IContentSwitcher>(window => ExecuteNewGame(window));
                }

                return newGameCommand;
            }
        }

        public WordleViewModel(WordleModel wordle, IDialogCoordinator dialogCoordinator)
        {
            this.wordle = wordle;
            this.dialogCoordinator = dialogCoordinator;
            CurrentTryWord = new WordTryViewModel(wordle);
            TryWords = new ObservableCollection<WordTryViewModel> { CurrentTryWord };
        }

        private bool CanExecuteCheckWord()
        {
            return !CurrentTryWord.Letters.Any(letter => string.IsNullOrWhiteSpace(letter.TryLetter));
        }

        private async void ExecuteCheckWord()
        {
            if (!CurrentTryWord.IsWordCorrect())
            {
                if (TryWords.Count < 6)
                {
                    CurrentTryWord = new WordTryViewModel(wordle);
                    TryWords.Add(CurrentTryWord); 
                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this, "Lástima...", $"La palabra era {this.wordle.Word}");
                }
            }
            else
            {
                await this.dialogCoordinator.ShowMessageAsync(this, "Felicidades!", "Has acertado!");
            }
        }

        private async void ExecuteNewGame(IContentSwitcher window)
        {
            var numberOfLetters = await this.dialogCoordinator.ShowInputAsync(this, "", "Cuantas letras?");
            var wordleService = DependencyBuilder.GetWordsService();
            var word = await wordleService.GetRandomWord(numberOfLetters);
            window.ChangeCurrentContent(ContentControlBuilder.GetWordleContent(word));
        }
    }
}
