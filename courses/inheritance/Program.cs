using System;

namespace inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            TohumluBitkiler tohumluBitki = new TohumluBitkiler(); //tohumluBitki instance oluşturuyoruz, TohumluBitkiler class'ından.
            // tohumluBitki.Beslenme(); //Canlılar class ının propertysi olan Beslenme methodunu kullanabiliyor.
            // tohumluBitki.Solunum(); //Canlılar class ının propertysi olan Solunum methodunu kullanabiliyor.
            // tohumluBitki.Bosaltim(); //Canlılar class ının propertysi olan Boşaltım methodunu kullanabiliyor.
            // tohumluBitki.FotosentezYapmak(); //Bitkiler class ının propertysi olan FotosentezYapmak methodunu kullanabiliyor. 
            tohumluBitki.TohumlaCogalma(); //Bitkiler class ının propertysi olan TohumluCogalma methodunu kullanabiliyor.
        
            Kuslar marti = new Kuslar();
            // marti.Solunum();
            // marti.Beslenme();
            // marti.Bosaltim();
            // marti.Adaptasyon();
            marti.Ucmak(); //Yukarıda propertyleri public'ken erişim sağlayabiliyorduk, protected yaptıktan sonra erişim kısıtlandı, sonasında Kuslar sınıfının içinde base. koduyla diğer propertylere erişim sağladık.
        }
    }
}