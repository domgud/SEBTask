using SEBTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SEBTask.Services
{
    class TextService : ITextService
    {

        public bool ContainsSplit(List<string> words)
        {
            /*will only work with strict 'split' as given in the task
            could also add an extra string.tolower check to make it work with any combinations of split such as 'SpLit', 'SPLIT' etc
            */
            return words.Contains("split");
        }

        public List<string> FindLongestWords(List<string> words)
        {
            //find the max lenght in n iterations, more efficient than sorting and getting the first element
            int longest = words.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length;
            //distinct is to only get the unique words so it wouldnt repeat itself
            return words.Where(x => x.Length == longest).Distinct().ToList();
        }
    }
}
