using Wordle.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.UI.Model
{
    public class WordsService : IWordsService
    {
        private readonly IWordDataAccess wordDataAccess;

        public WordsService(IWordDataAccess wordDataAccess)
        {
            this.wordDataAccess = wordDataAccess;
        }

        public async Task<string> GetRandomWord(string numberOfLetters)
        {
            var words = await this.wordDataAccess.GetWords(Convert.ToInt32(numberOfLetters));
            var random = new Random();
            var index = random.Next(words.Count());
            return words.ElementAt(index).Word;
        }
    }
}
