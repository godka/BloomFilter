using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace mythBloomFilter
{
    class Program
    {
        static void StartTest(string[] lines, int m)
        {
            CountBloomFilter bloomfilter = new CountBloomFilter(lines.Length * 6, m);
            for (var i = 0; i < lines.Length / 2; i++)
            {
                var line = lines[i];
                bloomfilter.Add(line);
            }
            int k = 0;
            for (var i = lines.Length / 2; i < lines.Length; i++)
            {
                var line = lines[i];
                if (bloomfilter.Contains(line))
                {
                    k++;
                    // Console.WriteLine("False Positive");
                }
            }
            Console.WriteLine("{0} : {1} / {2}", m, k, lines.Length / 2);
        }
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("out.txt");
            for (int i = 1; i < 21; i++)
                StartTest(lines, i);
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
