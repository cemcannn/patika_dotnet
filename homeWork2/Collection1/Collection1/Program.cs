using System;
using System.Collections;

namespace Collection1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList primeNumbers = new ArrayList();
            ArrayList notPrimeNumbers = new ArrayList();

            for (int i = 0; i < 5; i++)
            {
                int count = 0;
                string value = Console.ReadLine();
                int num;
                bool isNumeric = int.TryParse(value, out num);
                
                if(isNumeric && num>0)
                {
                    for (int j = 1; j < num; j++)
                    {
                        if (num % j == 0)
                        {
                            count++;
                        }
                    }
                    if (count > 1)
                    {
                        notPrimeNumbers.Add(num);
                    }
                    else
                    {
                        primeNumbers.Add(num);
                    }
                }
                

            }
            primeNumbers.Sort();
            notPrimeNumbers.Sort();

            Console.Write("Prime Numbers : ");
            foreach (var item in primeNumbers)
            {
                Console.Write(item + ", ");
            }

            Console.WriteLine();
            Console.Write("Not Prime Numbers : ");
            foreach (var item in notPrimeNumbers)
            {
                Console.Write(item + ", ");
            }
        }
    }
}
