using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.BusinessLogic;
using Wordle.UI.Model;

namespace Wordle.UI.ViewModel
{
    public class WordTryViewModel : ViewModelBase
    {
        private ObservableCollection<LetterViewModel> letters;
        private bool isCorrect;
        private WordChecker wordChecker;

        public ObservableCollection<LetterViewModel> Letters
        {
            get => letters;
            set
            {
                SetField(ref letters, value, nameof(Letters));
            }
        }

        public bool IsCorrect { get => isCorrect; set => SetField(ref isCorrect, value, nameof(IsCorrect)); }

        public WordTryViewModel(WordleModel wordleModel)
        {
            Letters = new ObservableCollection<LetterViewModel>(wordleModel.Word
                .Select((letter, position) => new LetterViewModel(letter.ToString(), position)));
            this.wordChecker = new WordChecker(wordleModel.Word);
            isCorrect = true;
            foreach (var letter in Letters)
            {
                letter.MaxLengthReached += Letter_MaxLengthReached;
            }
        }

        public bool IsWordCorrect()
        {
            foreach (var letter in Letters)
            {
                letter.SetColor("Green");

                if (!this.wordChecker.WordHasLetterInPosition(letter.TryLetter, letter.Position))
                {
                    letter.SetColor("Orange");
                    IsCorrect = false;
                }

                if (!this.wordChecker.WordHasLetter(letter.TryLetter))
                {
                    letter.SetColor("Red");
                    IsCorrect = false;
                }
            }

            return IsCorrect;
        }

        private void Letter_MaxLengthReached(object sender, int position)
        {
            (sender as LetterViewModel).IsFocused = false;
            Letters[(position + 1) % Letters.Count].IsFocused = true;
        }
    }
}
