using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEBTask.Services.Interfaces
{
    interface IIOService
    {
        public void PrintList(List<string> words);
        public List<string> ReadList();
    }
}
