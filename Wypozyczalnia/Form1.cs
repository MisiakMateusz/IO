using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Wypozyczalnia
{
    public partial class PokazListeKlientow : Form
    {
        
        Broker broker;
        public PokazListeKlientow()
        {
            InitializeComponent();
           
            broker = new Broker();
        }


        void Czysc()
        {
            //IDPojazdu.Text = " ";
            Rejestracja.Text = " ";
            Marka.Text = " ";
            Silnik.Text = " ";
            Cena.Text = " ";


        }

        void CzyscKlienta()
        {

            Imie.Text = " ";
            Nazwisko.Text = " ";
            Pesel.Text = " ";
            Wiek.Text = " ";
            TypKlienta.Text = " ";
            NumerTelefonu.Text = " ";

        }

        private void DodajPojazd_Click(object sender, EventArgs e)
        {
            Pojazd pojazd = new Pojazd
            {
               // IDPojazdu1 = Int32.Parse(IDPojazdu.Text),
                Rejestracja1 = Rejestracja.Text,
                Marka1 = Marka.Text,
                Silnik1 = Silnik.Text,
                Cena1 = Int32.Parse(Cena.Text)

            };
            broker.Dodaj_Pojazd_Do_Bazy(pojazd);
            Czysc();

            
            

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Pesel_TextChanged(object sender, EventArgs e)
        {

        }

        private void DodajKlienta_Click(object sender, EventArgs e)
        {
            Klient klient = new Klient
            {
                Imie1 = Imie.Text,
                Nazwisko1 = Nazwisko.Text,
                Pesel1 = Pesel.Text,
                Wiek1 = Int32.Parse(Wiek.Text),
                TypKlienta1 = TypKlienta.Text,
                NumerTelefonu1 = NumerTelefonu.Text
            };

            broker.Dodaj_Klienta_Do_Bazy(klient);
            CzyscKlienta();

        }

        private void Wypozycz_Click(object sender, EventArgs e)
        {

            broker.Dodaj_Wypozyczenie(PeselKlientaWypozyczajacego.Text, RejestracjaPOjazduDOWypozyczenia.Text);
            PeselKlientaWypozyczajacego.Text = " " ;
            RejestracjaPOjazduDOWypozyczenia.Text = " ";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void IDPojazdu_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //broker.PokazListeKlientow();
            listBox1.Items.Clear();
            string klienci = " ";
            foreach (var item in broker.PokazListeKlientow())
            {
               
                listBox1.Items.Add(item.ToString());
            }
          
        }

        private void PokazPojazdy_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            foreach (var item in broker.PokazListePojazdow())
            {
                listBox2.Items.Add(item.ToString());
            }
        }

        private void PokazWypozyczenia_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            Wypozyczenie wypozyczenie = new Wypozyczenie();
            

            foreach (var item in broker.PokazListeWypozyczen())
            {
                listBox3.Items.Add(item.ToString());
            }
            
        }

        private void OddajPojazd_Click(object sender, EventArgs e)
        {
            listBox3.Text = " ";
            string rejestracja = RejestracjaPOjazduDOWypozyczenia.Text;
            broker.OddajPojazd(rejestracja);
        }
    }
}
