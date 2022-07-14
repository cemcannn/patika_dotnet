using System;
using System.Collections;

namespace Collection3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vowels = "a,e,i,o,u";
            ArrayList list1 = new ArrayList();
            string sentence = Console.ReadLine();
            sentence.ToLower();

            for (int i = 0; i < sentence.Length; i++)
            {
                if (vowels.Contains(sentence[i]))
                {
                    list1.Add(sentence[i]);
                }
            }
            
            foreach (var item in list1)
            {
                Console.Write(item + " ");
            }
        }
    }
}
