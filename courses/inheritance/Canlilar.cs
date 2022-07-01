using System;

namespace inheritance
{
    public class Canlilar
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

        public virtual void UyaranTepki(){//Virtual olarak işaretledik yani kalıtım alan override edebilir.
            System.Console.WriteLine("Canlılar uyaranlara tepki verir.");
        }
    }
}