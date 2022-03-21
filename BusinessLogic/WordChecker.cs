using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.BusinessLogic
{
    public class WordChecker
    {
        private string _word;

        public WordChecker(string word)
        {
            _word = word;
        }

        public bool WordHasLetter(string letter)
        {
            return CultureInfo.InvariantCulture.CompareInfo.IndexOf(_word, letter.ToLower(), CompareOptions.IgnoreNonSpace) >= 0;
        }

        public bool WordHasLetterInPosition(string letter, int position)
        {
            return string.Compare(_word[position].ToString(), letter.ToLower(), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0;
        }
    }
}
