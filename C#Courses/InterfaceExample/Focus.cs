using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    internal class Focus : IOtomobil //IOtomobil'den kalıtım alıyor.
    {
        public Marka HangiMarkaninAraci() //IOtomobil'den implemente ediyoruz.
        {
            return Marka.Ford; //Marka enum'ı içerisinden Ford'u veriyoruz.
        }

        public int KacTekerlektenOlusur() //IOtomobil'den implemente ediyoruz.
        {
            return 4; //4 değerini atıyoruz.
        }

        public Renk StandartRengiNe() //IOtomobil'den implemente ediyoruz.
        {
            return Renk.Gri; //Renk enum'ı içerisinden griyi veriyoruz
        }
    }
}
