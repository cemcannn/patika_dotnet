using System;

namespace struct_concept
{
    class Program
    {
        static void Main(string[] args)
        {
             Dikdortgen dikdortgen = new Dikdortgen(); //Class yapısında parametrelere değer vermezsek, initial değerlerini verir fakat struct yapısında vermez.
             dikdortgen.KisaKenar = 3;
             dikdortgen.UzunKenar = 4;

             System.Console.WriteLine("Class Alan Hesabı    :{0}", dikdortgen.AlanHesapla());

             Dikdortgen_Struct dikdortgen_Struct = new Dikdortgen_Struct(); //Struct yapısında da nesne oluşturabiliyoruz.
             dikdortgen_Struct.KisaKenar = 3;
             dikdortgen_Struct.UzunKenar = 4;

             System.Console.WriteLine("Class Alan Hesanı    :{0}", dikdortgen_Struct.AlanHesapla());

             Dikdortgen_Struct dikdortgen_Struct1; //New yapmadan da nesne tanımlaması yapıyoruz Struct yapısında.
             dikdortgen_Struct1.KisaKenar = 5;
             dikdortgen_Struct1.UzunKenar = 6;

             System.Console.WriteLine("Class Alan Hesabı    :{0}", dikdortgen_Struct1.AlanHesapla());

            Dikdortgen_Struct dikdortgen_Struct2 = new Dikdortgen_Struct(kisaKenar = 8, uzunKenar = 9); //struct yapısı içinde defaul değeri veremiyoruz fakat, newleme yaparken parametre geçebiliyoruz.

             System.Console.WriteLine("Class Alan Hesabı    :{0}", dikdortgen_Struct1.AlanHesapla());
        }
    }
    class Dikdortgen
    {
        public int KisaKenar;
        public int UzunKenar;
        // Class içinde default olarak değer verebiliyorsun ama struct yapıda veremezsin.
        // public Dikdortgen()
        // {
        //     KisaKenar = 3;
        //     UzunKenar = 4;
        // }
        public long AlanHesapla()
        {
            return this.KisaKenar * this.UzunKenar;
        }
    }
    struct Dikdortgen_Struct
    {
        public int KisaKenar;
        public int UzunKenar;
        //Class gibi default değer veremiyoruz fakat aşağıdaki gibi tanımlama yaparak newleme yaparken parametre geçebiliyoruz.
        public Dikdortgen_Struct(int kisaKenar, int uzunKenar)
        {
            KisaKenar = kisaKenar;
            UzunKenar = uzunKenar;
        }
        public long AlanHesapla()
        {
            return this.KisaKenar * this.UzunKenar;
        }
    }
}