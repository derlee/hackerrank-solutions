using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.String_Manipulation.Common_Child
{
    internal class Solution
    {
        // Complete the commonChild function below.
        private static int commonChild(string s1, string s2)
        {
   int n1 = s1.Length + 1, n2 = s2.Length + 1;
    int[,] dp = new int[n1, n2];
    for (int i = 1; i < n1; ++i)
    {
        for (int j = 1; j < n2; ++j)
        {
            if (s1[i - 1] == s2[j - 1])
            {
                dp[i, j] = dp[i - 1, j - 1] + 1;
            }
            else
            {
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }
    }
 
    return dp[n1 - 1, n2 - 1];
        }    

        private static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            
            string s2 = Console.ReadLine();

            s1 = "0" + s1;
            s2 = "0" + s2;

            var watch = Stopwatch.StartNew();

            int result = commonChild(s1, s2);

            watch.Stop();

            Console.WriteLine(result);

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
