using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEBTask.Services.Interfaces
{
    interface ITextService
    {
        public List<string> FindLongestWords(List<string> words);
        public bool ContainsSplit(List<string> words);
    }

}

