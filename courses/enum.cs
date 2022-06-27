using System;

namespace enum_concept
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(Gunler.Pazar);
            System.Console.WriteLine((int)Gunler.Cumartesi); //Numeric değerine erişmek için cast işlemi yapıyoruz, int koyarak.

            int sicaklik = 32;
            if(sicaklik <= (int)HavaDurumu.Normal)
            {
                System.Console.WriteLine("Dışarıya çıkmak için havanın biraz daha ısınmasını bekleyelim.");
            }
            else if (sicaklik >= (int)HavaDurumu.Sicak)
            {
                System.Console.WriteLine("Dışarıya çıkmak için çok sıcak bir gün");
            }
            else if (sicaklik>= (int)HavaDurumu.Normal && sicaklik < (int)HavaDurumu.CokSicak)
            {
                System.Console.WriteLine("Haydi dışarıya çıkalım");
            }
        }
    }
    enum Gunler
    {
        Pazartesi, //Default olarak 0'dan başlar ardışık olarak numara verir. Biz farklı bir numara verirsek o sayıdan başlar.
        Sali,
        Carsamba,
        Persembe=34, //Buraya 34 verdiğimiz için çarşambaya kadar 0,1,2 şeklinde gelir perşembeden sonra 34,35,36,37 diye gider.
        Cuma,
        Cumartesi,
        Pazar
    }
    enum HavaDurumu
    {
        Soguk = 5, //5'ten 20'ye kadar soğuk.
        Normal = 20, //20'den 25'e kadar sıcak.
        Sicak = 25, //25'ten 30'a kadar sıcak.
        CokSicak = 30 //30'dan sonra çok sıcak.
    }
}