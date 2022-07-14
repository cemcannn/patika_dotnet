using System;

namespace class_concept
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Çalışan Sayısı: {0}", Calisan.CalisanSayisi); //Burada bahsettiğimiz gibi static method'da nesne tanımlamadan metod adı aracılığıyla erişim sağlıyoruz.

            Calisan calisan = new Calisan("Ayşe", "yılmaz", "İK"); // Ardından "Calisan" sınıfından bir "calisan" adından bir nesne tanımlıyoruz ve nesne özelliklerine public olarak erişim sağlamadığımız için özellikleri parametre olarak geçiyoruz.
            System.Console.WriteLine("Çalışan Sayısı: {0}", Calisan.CalisanSayisi); //Yukarıda Calisan constructor ına erişim sağlandığı için çalışan sayısı 1 artıyor ve tekrar static method'a erişim sağladığımızda çalışan sayısının 2 olduğunu görüyoruz.

            Islemler islemler = new Islemler(); //Bunu oluşturmanın bir önemi yok!
            System.Console.WriteLine("Toplama işlemi sonucu: {0}", Islemler.Topla(100,200)); //Static sınıfların içerisine Class ismiyle erişebiliyoruz, oluşturduğumuz örnek ile değil!
            System.Console.WriteLine("Çıkarma işlemi sonucu: {0}", Islemler.Cikar(200-50));
             
        }
        
    }
    class Calisan
    {
        private static int calisanSayisi;

        public static int CalisanSayisi { get => calisanSayisi; }

        private string Isim;
        private string SoyIsim;
        private string Departman;

        static Calisan(){ //Statik kurucuların erişim belirteci yoktur.
            calisanSayisi = 0;
        }
            
        public Calisan(string isim, string soyisim, string departman)
        {
            this.Isim = isim;
            this.SoyIsim = soyisim;
            this.Departman = departman;
            calisanSayisi ++;
        }
    }

    static class Islemler //Static bir class yaratmak istediğimizde class içindeki her şeyin static olması gerekmektedir.
    {
        public static long Topla (int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        public static long Cikar (int sayi1, int sayi2)
        {
            return sayi1 - sayi2;
        }
    }
}