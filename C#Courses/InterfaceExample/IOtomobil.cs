using System;

namespace InterfaceExample
{
    public interface IOtomobil
    {
        int KacTekerlektenOlusur();
        Marka HangiMarkaninAraci(); //Gidiyor Program.cs i�erisinden Marka enum'�n� �ekiyor.
        Renk StandartRengiNe(); //Gidiyor Program.cs i�erisinden Renk enum'�n� �ekiyor.
    }
}