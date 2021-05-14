using SEBTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEBTask.Services
{
    class IOService : IIOService
    {
        private readonly string inputFile = "input.txt";
        private readonly  string outputFile = "result.txt";
        public void PrintList(List<string> words)
        {
            Random random = new Random();
            //adding random dots every couple of words
            int dotCounter = 0;
            int nextDot = random.Next(3, 13);
            //also adding new lines every couple of words for better readability
            int newlineCounter = 0;
            int nextNewLine = 6;
            /*
             its better to read line by line to not destroy your ram
             so file.readallines would be bad with big text files
             * */
            using (TextWriter tw = new StreamWriter(outputFile))
            {
                foreach (string s in words)
                {
                    tw.Write(s);
                    dotCounter++;
                    newlineCounter++;
                    //check if need to put a dot
                    if (dotCounter == nextDot)
                    {
                        dotCounter = 0;
                        nextDot = random.Next(3, 13);
                        tw.Write(".");
                    }
                    //writing space symbol
                    tw.Write(" ");
                    //check if need to put a newline for better readability
                    if (newlineCounter == nextNewLine)
                    {
                        tw.Write("\n");
                        newlineCounter = 0;
                    }
                }
            }
        }

        public List<string> ReadList()
        {
            string readLine;
            List<string> output = new List<string>();
            //seperators here
            //could maybe use regex cause these seem to not catch on on very edge cases?
            string[] separators = new string[] { ",", ".", "!", "\'", " ", "\n", "\t", "\"", ":", "?", "-", "/", "(", ")"};
            using (var sr = new StreamReader(inputFile))
            {
                while ((readLine = sr.ReadLine()) != null)
                {
                    var data = readLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    output.AddRange(data);
                }
            }
            return output;
        }
    }
}
