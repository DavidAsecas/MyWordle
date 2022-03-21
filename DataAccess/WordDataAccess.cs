using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle.DataAccess
{
    public class WordDataAccess : IWordDataAccess
    {
        private static IWordDataAccess _instance;
        
        public static IWordDataAccess Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WordDataAccess();
                }

                return _instance;
            }
        }

        private WordDataAccess()
        {
        }

        public async Task<IEnumerable<IWordDataModel>> GetWords(int numberOfLetters)
        {
            IEnumerable<IWordDataModel> words = new List<IWordDataModel>();
            using (RestClient client = new RestClient("https://api.datamuse.com/words"))
            {
                var request = new RestRequest();
                request.AddParameter("sp", string.Concat(Enumerable.Repeat("?", numberOfLetters)));
                request.AddParameter("v", "es");
                request.AddParameter("max", "500");
                var response = await client.GetAsync(request);
                if (response.IsSuccessful)
                {
                    words = JsonConvert.DeserializeObject<IEnumerable<WordDataModel>>(response.Content);
                }
            }

            return words;
        }
    }
}
