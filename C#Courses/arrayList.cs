using System;
using System.Collections;
using System.Collections.Generic;

namespace array_list
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList liste = new ArrayList();
            liste.Add("Ayşe");
            liste.Add(2);
            liste.Add(true);
            liste.Add('A');

            //Index üzerinden liste verilerine erişim
            Console.WriteLine(liste[1]);

            //Tüm verilere erişim
            foreach (var item in liste)
                Console.WriteLine(item);

            //AddRange birden fazla toplu eleman ekleme
            Console.WriteLine("***** Add Range *****");

            string[] renk = {"kırmızı", "sarı", "yeşil"};
            List<int> sayilar = new List<>(){1,8,3,7,9,92,5};
            liste.AddRange(renkler);
            liste.AddRange(sayilar);

            foreach (var item in liste)
                Console.WriteLine(item);

            //Sort sıralama metodu
            Console.WriteLine("***** Sort *****");
            //İçinde her türden veri olduğu için liste için compile da hata vermez fakat runtime da hata verir. Biz de yeni liste oluşturup onun üzerinde sort işlemi yapacağız.
            ArrayList liste1 = new ArrayList();
            liste1.AddRange(sayilar);

            liste1.Sort();

            foreach (var item in liste1)
                Console.WriteLine(item);

            //Binary Search
            Console.WriteLine("***** Binary Search *****");
            //Binary search için önce "Sort" işlemini yapmalıyız! Sort işlemini yukarıda yaptık. Bize elemanın kaçıncı indexte olduğunu verecek.
            
            Console.WriteLine(liste1.BinarySearch[9]);

            //Reverse
            Console.WriteLine("***** Reverse *****");
            //En baştaki elemanı en sona en sondaki elemanı en başa alır.

            liste1.Reverse();

            foreach (var item in liste1)
                Console.WriteLine(item);

            //Clear
            Console.WriteLine("***** Clear *****");
            //Listeyi temizler!!

            liste1.Clear();

            foreach (var item in liste1)
                Console.WriteLine(item);
        }
    }
}