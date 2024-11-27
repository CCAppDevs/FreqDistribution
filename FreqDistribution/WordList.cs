using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FreqDistribution
{
    public class WordList
    {
        public string BaseString { get; set; }
        public List<string> Words { get; set; }
        public Dictionary<string, int> FreqDist { get; set; }

        public WordList(string baseString)
        {
            BaseString = baseString;

            Words = new List<string>();
            FreqDist = new Dictionary<string, int>();

            foreach (string token in RemoveSpecialCharacters(BaseString).ToUpper().Split(" "))
            {
                if (FreqDist.ContainsKey(token))
                {
                    FreqDist[token]++;
                }
                else
                {
                    FreqDist.Add(token, 1);
                }
            }

            var test = FreqDist.ToList();

            foreach (var item in test)
            {
                Words.Add(item.Key);
            }
        }

        public Dictionary<string, int> GetTopTen()
        {
            return FreqDist.OrderByDescending(x => x.Value).ToDictionary();
        }

        public string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9\\s]+", "", RegexOptions.Compiled);
        }
    }
}
