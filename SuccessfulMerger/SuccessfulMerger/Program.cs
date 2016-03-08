using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessfulMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            SuccessfulMerger merger = new SuccessfulMerger();
            foreach (string line in File.ReadAllLines(@"D:\mergers.txt"))
            {
                var firstParts = line.Split(';');
                if(firstParts.Length == 2)
                {
                    var stringArray = firstParts[0].Split(',');
                    var numArray = stringArray.Select(s => int.Parse(s.Trim())).ToArray();
                    var actResult = merger.minimumMergers(numArray);
                    var result = int.Parse(firstParts[1].Trim());
                    Console.Out.WriteLine(firstParts[0] + " = " + actResult + " | " + (actResult == result));    
                }
            }
        }
    }
}
