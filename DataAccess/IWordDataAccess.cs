using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wordle.DataAccess
{
    public interface IWordDataAccess
    {
        Task<IEnumerable<IWordDataModel>> GetWords(int numberOfLetters);
    }
}