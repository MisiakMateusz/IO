using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    public class Klient
    {
        string Pesel;
        string Imie;
        string Nazwisko;
        int Wiek;
        string TypKlienta;
        string NumerTelefonu;

        public string Pesel1 { get => Pesel; set => Pesel = value; }
        public string Imie1 { get => Imie; set => Imie = value; }
        public string Nazwisko1 { get => Nazwisko; set => Nazwisko = value; }
        public int Wiek1 { get => Wiek; set => Wiek = value; }
        public string TypKlienta1 { get => TypKlienta; set => TypKlienta = value; }
        public string NumerTelefonu1 { get => NumerTelefonu; set => NumerTelefonu = value; }


        public override string ToString()
        {
            return " "+Imie1 + " " + Nazwisko1 + " " + Pesel1 ;
        }
    }
}
