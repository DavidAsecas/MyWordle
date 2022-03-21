using System.Threading.Tasks;

namespace Wordle.UI.Model
{
    public interface IWordsService
    {
        Task<string> GetRandomWord(string numberOfLetters);
    }
}