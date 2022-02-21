using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Dictionaries_and_Hashmaps.Hash_Tables_Ransom_Note
{
    internal class Solution
    {
        private static void checkMagazine(string[] magazine, string[] note)
        {
            var dicM = new Dictionary<string, int>(); 

            foreach (var s in magazine)
            {
                if (dicM.TryGetValue(s, out int value)) 
                    dicM[s] += 1; 
                else
                    dicM.Add(s, 1);
            } 

            foreach (var n in note)
            {
                if (!dicM.TryGetValue(n, out int value) || value<=0)
                {
                    Console.WriteLine("No");
                    return;
                } 
                else
                {
                   dicM[n]--; 
                }
            }
            Console.WriteLine("Yes");
        }

        private static void Main(string[] args)
        {
            string[] mn = Console.ReadLine().Split(' ');

            int m = Convert.ToInt32(mn[0]);

            int n = Convert.ToInt32(mn[1]);

            string[] magazine = Console.ReadLine().Split(' ');

            string[] note = Console.ReadLine().Split(' ');

            var watch = Stopwatch.StartNew();

            checkMagazine(magazine, note);

            watch.Stop();

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));
            Console.ReadKey();
        }
    }
}
