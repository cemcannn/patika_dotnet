using System;

namespace InterfaceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Focus focus = new Focus(); //focus instance'ı oluşturuyoruz.
            Console.WriteLine(focus.HangiMarkaninAraci().ToString()); //gelen değer object sınıfında olduğu için string değerine döndürüp yazdırıyoruz.
            Console.WriteLine(focus.KacTekerlektenOlusur().ToString());
            Console.WriteLine(focus.HangiMarkaninAraci().ToString());

            Civic civic = new Civic(); //civic instance'ı oluşturuyoruz.
            Console.WriteLine(civic.HangiMarkaninAraci().ToString());
            Console.WriteLine(civic.KacTekerlektenOlusur().ToString());
            Console.WriteLine(civic.HangiMarkaninAraci().ToString());

            Corolla corolla = new Corolla(); //corolla instance'ı oluşturuyoruz.
            Console.WriteLine(corolla.HangiMarkaninAraci().ToString());
            Console.WriteLine(corolla.KacTekerlektenOlusur().ToString());
            Console.WriteLine(corolla.HangiMarkaninAraci().ToString());
        }
    }
}
