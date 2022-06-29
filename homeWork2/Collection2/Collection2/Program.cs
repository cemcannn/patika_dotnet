using System;
using System.Collections;

namespace Collection2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] list1 = new int[20], largestThree = new int[3], smallestThree = new int[3];
            int sumLargest = 0, sumSmallest = 0;

            for (int i = 0; i < 20; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                list1[i] = num;
            }

            Array.Sort(list1);
            
            for (int i = 0; i<3; i++)
            {
                smallestThree[i] = list1[i];
                sumSmallest += list1[i];
            }

            Array.Reverse(list1);

            for (int i = 0; i < 3; i++)
            {
                largestThree[i] = list1[i];
                sumLargest += list1[i];
            }

            Console.WriteLine("Average of largest three numbers of list : " + sumLargest/3);
            Console.WriteLine("Average of smallest three numbers of list : " + sumSmallest / 3);
            Console.WriteLine("Summary of averages of largest and smallest numbers : " + (sumLargest/3 + sumSmallest/3));
        }
    }
}
