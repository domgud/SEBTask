using SEBTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEBTask.Extensions;
namespace SEBTask
{
    class Startup
    {
        private readonly IIOService _IOService;
        private readonly ITextService _textService;
        public Startup(IIOService iOService, ITextService textService)
        {
            _IOService = iOService;
            _textService = textService;
        }
        public void Run()
        {
            List<string> data = _IOService.ReadList();
            List<string> longestWords = _textService.FindLongestWords(data);
            bool containsSplit = _textService.ContainsSplit(data);

            Console.WriteLine(containsSplit? "Text contains the word split": "Text does not contain the word split");
            Console.WriteLine("Longest words:");
            foreach (var item in longestWords)
            {
                Console.WriteLine(item);
            }
            data.Shuffle();
            _IOService.PrintList(data);
        }

    }
}
