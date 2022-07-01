using System;

namespace AbstractExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NewFocus focus = new NewFocus(); //focus instance'ı oluşturuyoruz.
            Console.WriteLine(focus.HangiMarkaninAraci().ToString()); //gelen değer object sınıfında olduğu için string değerine döndürüp yazdırıyoruz.yazdırıyoruz.
            Console.WriteLine(focus.KacTekerlektenOlusur().ToString());
            Console.WriteLine(focus.HangiMarkaninAraci().ToString());

            NewCivic civic = new NewCivic(); //civic instance'ı oluşturuyoruz.
            Console.WriteLine(civic.HangiMarkaninAraci().ToString());
            Console.WriteLine(civic.KacTekerlektenOlusur().ToString());
            Console.WriteLine(civic.HangiMarkaninAraci().ToString());

            NewCorolla corolla = new NewCorolla(); //corolla instance'ı oluşturuyoruz.
            Console.WriteLine(corolla.HangiMarkaninAraci().ToString());
            Console.WriteLine(corolla.KacTekerlektenOlusur().ToString());
            Console.WriteLine(corolla.HangiMarkaninAraci().ToString());
        }
    }
}
