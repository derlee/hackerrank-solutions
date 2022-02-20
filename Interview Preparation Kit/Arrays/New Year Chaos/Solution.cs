using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Arrays.New_Year_Chaos
{
    internal class Solution
    {
        // Complete the minimumBribes function below.
        private static void minimumBribes(int[] q)
        {
             var cl = 0; 
        for (int index = q.Count-1; index > 0; index--)
        {
            if (q[index] == index + 1)
                 continue;

            var curValue =0;
        
            if (q[index-1] == index + 1 )
            {
                cl += 1;
                curValue=q[index-1];
                q[index-1]=q[index];
                q[index]=curValue; 
               
            } 
            else  if (q[index-2] == index + 1 )
            {                
                cl += 2;
                curValue=q[index-2];
                q[index-2]=q[index-1];
                q[index-1]=q[index];
                q[index]=curValue; 

            }
            else  
            {
                Console.WriteLine("Too chaotic");
                return;
            } 
        } 
        Console.WriteLine(cl);
        }

        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp));

                var watch = Stopwatch.StartNew();

                minimumBribes(q);

                watch.Stop();

                Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));
            }

            Console.ReadKey();
        }
    }
}
