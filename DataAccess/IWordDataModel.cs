namespace Wordle.DataAccess
{
    public interface IWordDataModel
    {
        int Score { get; set; }
        string Word { get; set; }
    }
}