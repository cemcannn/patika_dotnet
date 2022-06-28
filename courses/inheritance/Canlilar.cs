using System;

namespace inheritance
{
    class Canlilar
    {
        protected void Beslenme(){//Sadece bulunduğu class ve kalıtım alan sınıf erişebilir.
            System.Console.WriteLine("Canlılar beslenir.");
        }
        protected void Solunum(){//Sadece bulunduğu class ve kalıtım alan sınıf erişebilir.
            System.Console.WriteLine("Canlılar solunum yapar.");
        }
        protected void Bosaltim(){//Sadece bulunduğu class ve kalıtım alan sınıf erişebilir.
            System.Console.WriteLine("Canlılar boşaltım yapar.");
        }
    }
}