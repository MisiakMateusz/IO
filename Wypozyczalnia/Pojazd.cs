using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    public class Pojazd
    {
        int IDPojazdu;
        string Rejestracja;
        string Marka;
        string Silnik;
        int Cena;



        public int IDPojazdu1 { get => IDPojazdu; set => IDPojazdu = value; }
        public string Rejestracja1 { get => Rejestracja; set => Rejestracja = value; }
        public string Marka1 { get => Marka; set => Marka = value; }
        public string Silnik1 { get => Silnik; set => Silnik = value; }
        public int Cena1 { get => Cena; set => Cena = value; }

        public override string ToString()
        {
            return Marka1 + " " + Rejestracja1 + " ";
        }
    }
}
