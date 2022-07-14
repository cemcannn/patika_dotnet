using System;

namespace constructor_method
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("***** Çalışan 1 *****"); //1. tip  çalışan tanımlaması.
            Calisan calisan1 = new Calisan();
            calisan1.Ad = "Ayşe";
            calisan1.Soyad = "Kara";
            calisan1.No = 5556566666;
            calisan1.Departman = "İnsan Kaynakları";

            calisan1.CalisanBilgileri();

            System.Console.WriteLine("***** Çalışan 2 *****"); //2. tip  çalışan tanımlaması.
            Calisan calisan2 = new Calisan("Deniz","Arda",5556566622,"Satın Alma");

            calisan2.CalisanBilgileri();

            System.Console.WriteLine("***** Çalışan 3 *****"); //Burada da sadece 2 parametre giriliyor, açıklaması aşağıda kurucu method bölümünde.
            Calisan calisan3 = new Calisan("Cem","Can");

            calisan3.CalisanBilgileri();
        }
    }
    class Calisan
    {
        public string Ad;
        public string Soyad;
        public int No;
        public string Departman;
        public Calisan(string ad, string soyad, int no, string departman) //Constructor method, class ismiyle aynı isimde, zorunlu olarak public alıyor.
        {
            this.Ad = ad;
            this.Soyad = soyad;
            this.No = no;
            this.Departman = departman;
        }
        public Calisan(){} //Constructor method'a "Method Overloading" yapıyoruz. Varsayılan kurucu method olarak geçiyor. Sınıfın içindeki özelliklere ilk değer atamasıyla onları okur.
        public Calisan(string ad, string soyad) //Constructor method'a "Method Overloading" yapıyoruz. Sadece ad ve soyad parametresi alıyoruz fakat bizden çıktı alırken numara ve departman parametresi de istiyor. Bu durumda parametre girilmeyen değerler için bize hata vermiyor, int değerlere 0 çıktısı, string değerlere boş çıktı, bool değerlere de False çıktısı veriyor.
        {
            this.Ad = ad;
            this.Soyad = soyad;
        }
        public void CalisanBilgileri()
        {
            Console.WriteLine("Çalışan Adı:{0}", Ad);
            Console.WriteLine("Çalışan Soyadı:{0}", Soyad);
            Console.WriteLine("Çalışan Numarası:{0}", No);
            Console.WriteLine("Çalışan Departmanı:{0}", Departman);
            
        }
    }
}