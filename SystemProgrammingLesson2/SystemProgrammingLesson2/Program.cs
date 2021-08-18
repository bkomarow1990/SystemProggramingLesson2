using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemProgrammingLesson2
{
    class Program
    {
        static void NumsPrint(object nums) {
            int[] nums_int = nums as int[];
            Console.Clear();
            for (int i = nums_int[0]; i <= nums_int[1]; i++)
            {
                Console.WriteLine(i);
            }
           
        }
        static void GetMin(object elems) {
            int[] elems_int = elems as int[];
            int min = elems_int[0];
            for (int i = 0; i < elems_int.Length; i++)
            {
                if (elems_int[i] < min)
                {
                    min = elems_int[i];
                }
            }
            string out_text = $"Min: {min}";
            File.WriteAllText("resMin.dat", out_text);
            Console.WriteLine(out_text);
        }
        static void GetMax(object elems)
        {
            int[] elems_int = elems as int[];
            int max = elems_int[0];
            for (int i = 0; i < elems_int.Length; i++)
            {
                if (elems_int[i] > max)
                {
                    max = elems_int[i];
                }
            }
            string out_text = $"Max: {max}";
            File.WriteAllText("resMax.dat", out_text);
            Console.WriteLine(out_text);
        }
        private static void GetAvg(object obj)
        {
            int[] elems = obj as int[];
            string out_text = $"Average: {elems.Average()}";
            File.WriteAllText("resAvg.dat", out_text);
            Console.WriteLine(out_text);
        }
        static void Main(string[] args)
        {
            ParameterizedThreadStart threadstart = new ParameterizedThreadStart(NumsPrint);
            
            int []nums = new int[2];
            
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"Enter num: {i+1}");
                nums[i] = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Enter count threads: ");
            int count_threads = Int32.Parse(Console.ReadLine());
            Thread[] threads = new Thread[count_threads];
            for (int i = 0; i < count_threads; i++)
            {
                threads[i] = new Thread(threadstart);
            }
            for (int i = 0; i < count_threads; i++)
            {
                threads[i].Start((object)nums);
            }
            //thread.Start();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Task 4: ");
            Console.WriteLine("");
            int[] elems = new int[10000];
            Random rnd = new Random();
            for (int i = 0; i < elems.Length; i++)
            {
                elems[i] = rnd.Next(0,101);
            }
            // Min
            ParameterizedThreadStart minThreadStart = new ParameterizedThreadStart(GetMin);
            Thread minThread = new Thread(minThreadStart);
            minThread.Start(elems);
            // Max
            ParameterizedThreadStart maxThreadStart = new ParameterizedThreadStart(GetMax);
            Thread maxThread = new Thread(maxThreadStart);
            maxThread.Start(elems);
            // Avg
            ParameterizedThreadStart avgThreadStart = new ParameterizedThreadStart(GetAvg);
            Thread avgThread = new Thread(avgThreadStart);
            avgThread.Start(elems);
        }

        
    }
}
