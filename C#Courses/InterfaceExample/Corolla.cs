using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    internal class Corolla : IOtomobil //IOtomobil'den kalıtım alıyor.
    {
        public Marka HangiMarkaninAraci() //IOtomobil'den implemente ediyoruz.
        {
            return Marka.Toyota; //Marka enum'ı içerisinden Toyota'yı veriyoruz.
        }

        public int KacTekerlektenOlusur() //IOtomobil'den implemente ediyoruz.
        {
            return 4; //4 değerini atıyoruz.
        }

        public Renk StandartRengiNe() //IOtomobil'den implemente ediyoruz.
        {
            return Renk.Beyaz; //Renk enum'ı içerisinden beyazı veriyoruz
        }
    }
}
