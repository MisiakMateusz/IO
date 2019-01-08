using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    public class Wypozyczenie
    {

        DateTime DataWynajmu;
        DateTime DataZwrotu;
        string NazwiskoKlienta;
        string RejestracjaPojazdu;

        public DateTime DataWynajmu1 { get => DataWynajmu; set => DataWynajmu = value; }
        public DateTime DataZwrotu1 { get => DataZwrotu; set => DataZwrotu = value; }
        public string NazwiskoKlienta1 { get => NazwiskoKlienta; set => NazwiskoKlienta = value; }
        public string RejestracjaPojazdu1 { get => RejestracjaPojazdu; set => RejestracjaPojazdu = value; }

        public override string ToString()
        {
            return NazwiskoKlienta1 + " " + RejestracjaPojazdu1 + " \n" + DataWynajmu1 + " " + DataZwrotu1;
        }
    }
}
