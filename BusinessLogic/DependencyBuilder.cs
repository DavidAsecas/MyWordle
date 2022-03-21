using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.DataAccess;
using Wordle.UI.Model;

namespace Wordle.BusinessLogic
{
    public static class DependencyBuilder
    {
        public static IWordsService GetWordsService()
        {
            return new WordsService(WordDataAccess.Instance);
        }
    }
}
