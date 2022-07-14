using System;
using System.Collections.Generic;

namespace array_list
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> kullanicilar = new Dictionary<int, string>();

            kullanicilar.Add(10,"Ayşe Yılmaz");
            kullanicilar.Add(12,"Ahmet Yılmaz");
            kullanicilar.Add(18,"Arda Kural");
            kullanicilar.Add(32,"Özcan Deniz");

            //Dizinin elemanlarına erişme
            Console.WriteLine("***** Elemanlara Erişme *****");
            Console.WriteLine(kullanicilar[12]);
            foreach (var item in kullanicilar)
                Console.WriteLine(item);

            //Count
            Console.WriteLine("***** Count *****");
            Console.WriteLine(kullanicilar.Count());

            //Contains
            Console.WriteLine("***** Contains *****");
            Console.WriteLine(kullanicilar.ContainsKey(12)); //Key karşılığı value verir
            Console.WriteLine(kullanicilar.ContainsValue("Ayşe Yılmaz")); //Value karşılığı keyi verir.

            //Remove
            Console.WriteLine("***** Remove *****");
            kullanicilar.Remove(12);
            foreach (var item in kullanicilar)
                Console.WriteLine(item);

            //Keys
            Console.WriteLine("***** Keys *****");
            foreach (var item in kullanicilar.Keys)
                Console.WriteLine(item);

            //Values
            Console.WriteLine("***** Values *****");
            foreach (var item in kullanicilar.Values)
                Console.WriteLine(item);
        }
    }
}