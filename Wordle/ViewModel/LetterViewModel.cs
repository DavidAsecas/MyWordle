using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.UI.ViewModel
{
    public class LetterViewModel : ViewModelBase
    {
        private string correctLetter;
        private string tryLetter;
        private string backgroundColor;
        private bool isFocused;

        public string TryLetter
        {
            get => tryLetter;
            set
            {
                if (value.Length == 1)
                {
                    OnMaxLengthReached();
                }

                SetField(ref tryLetter, value, nameof(TryLetter));
            }
        }

        public int Position { get; private set; }

        public string BackgroundColor { get => backgroundColor; set => SetField(ref backgroundColor, value, nameof(BackgroundColor)); }

        public bool IsFocused { get => isFocused; set => SetField(ref isFocused, value, nameof(IsFocused)); }

        public event EventHandler<int> MaxLengthReached;

        public LetterViewModel(string letter, int position)
        {
            this.correctLetter = letter;
            Position = position;
            BackgroundColor = "White";
        }

        public void SetColor(string color)
        {
            BackgroundColor = color;
        }

        private void OnMaxLengthReached()
        {
            MaxLengthReached?.Invoke(this, Position);
        }
    }
}
