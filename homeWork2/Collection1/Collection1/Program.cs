using System;
using System.Collections;

namespace Collection1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList primeNumbers = new ArrayList(); // Asal sayılar ArrayList olarak oluşturuldu.
            ArrayList notPrimeNumbers = new ArrayList(); //Asal olmayan sayılar ArrayList olarak oluşturuldu.
            int sumPrime = 0;
            int sumNotPrime = 0;

            for (int i = 0; i < 5; i++) //20 sayılık for döngüsüü
            {
                int count = 0; 
                string value = Console.ReadLine();
                int num;
                bool isNumeric = int.TryParse(value, out num); //Kullanıcıdan alınan value değerini TryParse metodu ile numeric olup olmadığını kontrol ediyoruz.
                
                if(isNumeric && num>0) //Değer numeric ve 0'dan büyük ise sisteme alıyor.
                {
                    for (int j = 1; j < num; j++) //1'den başlayıp num-1 sayısına kadar bölüyor.
                    {
                        if (num % j == 0) //Bölüm 0 ise yani tam bölünüyorsa, sayacı 1 arttırıyor.
                        {
                            count++;
                        }
                    }
                    if (count > 1) //Eğer asal sayılara ekleyeceksek sayacın 1'den büyük olması bekleniyor, çünkü 1 sayısına da tam bölünüyor. Eğer 1'den fazla ise asal olmayan sayı listesine ekleniyor.
                    {
                        notPrimeNumbers.Add(num);
                        sumNotPrime += num;
                    }
                    else
                    {
                        primeNumbers.Add(num);
                        sumPrime += num;
                    }
                }  
            }

            primeNumbers.Sort();//Listeleri sıralama işlemi.
            primeNumbers.Reverse(); //Sıralamayı tersine çevirme
            notPrimeNumbers.Sort();
            notPrimeNumbers.Reverse();

            Console.WriteLine("Count of Prime Numbers : " + primeNumbers.Count);
            Console.WriteLine("Average of Prime Numbers : " + sumPrime/primeNumbers.Count);

            Console.WriteLine("Count of Not Prime Numbers : " + notPrimeNumbers.Count);
            Console.WriteLine("Average of Not Prime Numbers : " + sumNotPrime/notPrimeNumbers.Count);
        }
    }
}
