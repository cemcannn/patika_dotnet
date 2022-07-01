using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample
{
    public abstract class Otomobil
    {
        public int KacTekerlektenOlusur() // 3 araç için de tekerlek sayısı standart o yüzden tek bir class oluşturduk.
        {
            return 4;
        }
        public virtual Renk StandartRengiNe() // 2 aracın rengi aynı 1 tanesinin farklı olduğu için virtual keyword'ünü ekledik, yani farklı olan 1 araç için override yapacağız.
        {
            return Renk.Beyaz;
        }
        public abstract Marka HangiMarkaninAraci(); //3 aracın da markası farklı olduğu için abstract class oluşturuyoruz ve kalıtım alan class'ları bu class'ı yazmaya ve override etmeye zorluyoruz.
    }   
}
