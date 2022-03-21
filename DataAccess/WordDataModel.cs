using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.DataAccess
{
    public class WordDataModel : IWordDataModel
    {
        public string Word { get; set; }
        public int Score { get; set; }
    }
}
