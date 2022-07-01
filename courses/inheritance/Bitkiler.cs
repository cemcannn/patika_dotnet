using System;

namespace inheritance
{
    public class Bitkiler : Canlilar //Canlılar sınıfından kalıtım alıyor.
    {
        protected void FotosentezYapmak(){//Sadece bulunduğu class ve kalıtım alan sınıf erişebilir.
            System.Console.WriteLine("Bitkiler fotosentez yapar.");
        }

        public override void UyaranTepki()//Canlılar sınıfındaki UyaranTepki sınıfını override etti.
        {
            base.UyaranTepki();
            System.Console.WriteLine("Bitkiler güneşe tepki verir.");
        }
    }
    public class TohumluBitkiler : Bitkiler { //Bitkiler sınıfından kalıtım alıyor.
        public TohumluBitkiler(){//Bitkiler ve Canlilar sınıfının property'lerine erişmek için constructor  method oluşturuyoruz.
            base.FotosentezYapmak();//base ifadesini kullanarak kalıtım aldığımız Bitkiler sınıfındaki protected property'lere erişebiliyoruz.
            base.Beslenme();//base ifadesini kullanarak kalıtım aldığımız Canlılar sınıfındaki protected property'lere erişebiliyoruz.
            base.Bosaltim();
            base.Solunum();
        }
        public void TohumlaCogalma(){
            System.Console.WriteLine("Tohumlu bitkiler tohumla çoğalır.");
        }
    }
    public class TohumsuzBitkiler : Bitkiler { //Bitkiler sınıfından kalıtım alıyor.
        public void SporlaCogalma(){
            System.Console.WriteLine("Tohumsuz bitkiler sporla çoğalır.");
        }
    }
}