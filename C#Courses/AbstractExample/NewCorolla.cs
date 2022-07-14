using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample
{
    internal class NewCorolla : Otomobil
    {
        public override Marka HangiMarkaninAraci() //Marka hepsinde farklı olduğu için ve abstract class olduğu için mecbur override ediyoruz.
        {
            return Marka.Toyota; 
        }
        //KacTekerlektenOlusur ve StandartRengiNe metodlarını override etmeye gerek yok, zaten 4 tekerlek ve standart rengi beyaz. 
    }
}
