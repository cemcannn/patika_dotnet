using System;

namespace inheritance
{
    public class Hayvanlar : Canlilar //Canlılar sınıfından kalıtım alıyor.
    {
        protected void Adaptasyon(){//Sadece bulunduğu class ve kalıtım alan sınıf erişebilir.
            System.Console.WriteLine("Hayvanlar adaptasyon kurabilir.");
        }
    }
    public class Surungenler : Hayvanlar { //Hayvanlar sınıfından kalıtım alıyor.
        public Surungenler(){//Hayvanlar ve Canlilar sınıfının property'lerine erişmek için constructor method oluşturuyoruz.
            base.Adaptasyon();//base ifadesini kullanarak kalıtım aldığımız Hayvanlar sınıfındaki protected property'lere erişebiliyoruz.
            base.Beslenme();//base ifadesini kullanarak kalıtım aldığımız Canlılar sınıfındaki protected property'lere erişebiliyoruz.
            base.Bosaltim();
            base.Solunum();
        }
        public void SurunerekHareketEtmek(){
            System.Console.WriteLine("Sürüngenler sürünerek hareket eder.");
        }
    }
    public class Kuslar : Hayvanlar { //Hayvanlar sınıfından kalıtım alıyor.
        public void Ucmak(){
            System.Console.WriteLine("Kuşlar uçar.");
        }
    }
}