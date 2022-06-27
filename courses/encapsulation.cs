using System;

namespace encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("***** Öğrenci 1 *****");
            Ogrenci ogrenci1 = new Ogrenci();
            ogrenci1.Isim = "Ahmet";
            ogrenci1.Soyisim = "Altan";
            ogrenci1.OgrenciNo = 293;
            ogrenci1.Sinif = 3;

            ogrenci1.OgrenciBilgileriniGetir();

            ogrenci1.SinifAtlat();

            ogrenci1.OgrenciBilgileriniGetir();

            System.Console.WriteLine("***** Öğrenci 2 *****");
            Ogrenci ogrenci2 = new Ogrenci("Osman","Bostayev",256,2);

            ogrenci2.OgrenciBilgileriniGetir();

            ogrenci2.SinifDusur();
            ogrenci2.SinifDusur();

            ogrenci2.OgrenciBilgileriniGetir();
        }
    
    }
    class Ogrenci
    {
        private string isim;
        private string soyisim;
        private int ogrenciNo;
        private int sinif;

        public string Isim { get => isim; set => isim = value;} // Bu metodun açılımı aşağıdaki gibidir.
        // public string isim
        // {
        //     get { return isim;}
        //     set { isim = value; }
        // }
        public string Soyisim { get => soyisim; set => soyisim = value;}    
        public int OgrenciNo { get => ogrenciNo; set => ogrenciNo = value;}
        public int Sinif
        {
            get => sinif; 
            set 
            {
                if(value < 1)
                {
                    Console.WriteLine("Sınıf En Az 1 Olabilir!");
                    sinif = 1;
                }
                else
                {
                    sinif = value;
                }
                
            }
        }

        public Ogrenci(string isim, string soyisim, int ogrenciNo, int sinif)
        {
            Isim = isim;
            Soyisim = soyisim;
            OgrenciNo = ogrenciNo;
            Sinif = sinif;
        }

        public Ogrenci(){}

        public void OgrenciBilgileriniGetir()
        {
            Console.WriteLine("******* Öğrenci Bilgileri *******");
            System.Console.WriteLine("Öğrenci Adı       :{0}",this.Isim);
            System.Console.WriteLine("Öğrenci Soyadı    :{0}",this.Soyisim);
            System.Console.WriteLine("Öğrenci Numarası  :{0}",this.OgrenciNo);
            System.Console.WriteLine("Öğrenci Sınıfı    :{0}",this.Sinif);
        }

        public void SinifAtlat()
        {
            this.Sinif = this.Sinif + 1;
        }

        public void SinifDusur()
        {
            this.Sinif -= 1;
        }
    }
}