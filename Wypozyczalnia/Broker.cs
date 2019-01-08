using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    public class Broker
    {
        public PolaczenieZBaza polacz = new PolaczenieZBaza();

        public void Dodaj_Pojazd_Do_Bazy(Pojazd pojazd)
        {
            

            polacz.ConnectTo();
            string commandText = "insert into dbo.Pojazd(Rejestracja,Marka,Silnik,Cena) values(@p2,@p3,@p4,@p5)";
            SqlCommand command = new SqlCommand(commandText, polacz.Connection);
            
            command.Parameters.AddWithValue("@p2", pojazd.Rejestracja1);
            command.Parameters.AddWithValue("@p3", pojazd.Marka1);
            command.Parameters.AddWithValue("@p4", pojazd.Silnik1);
            command.Parameters.AddWithValue("@p5", pojazd.Cena1);

            polacz.Connection.Open();
            command.ExecuteNonQuery();
            polacz.Connection.Close();

        }

        public void Dodaj_Klienta_Do_Bazy(Klient klient)
        {

            polacz.ConnectTo();
            string commandText = "insert into dbo.Klient(Pesel,Imie,Nazwisko,Wiek,TypKlienta,NumerTelefonu) values(@p1,@p2,@p3,@p4,@p5,@p6)";
            SqlCommand command = new SqlCommand(commandText, polacz.Connection);
            command.Parameters.AddWithValue("@p1", klient.Pesel1);
            command.Parameters.AddWithValue("@p2", klient.Imie1);
            command.Parameters.AddWithValue("@p3", klient.Nazwisko1);
            command.Parameters.AddWithValue("@p4", klient.Wiek1);
            command.Parameters.AddWithValue("@p5", klient.TypKlienta1);
            command.Parameters.AddWithValue("@p6", klient.NumerTelefonu1);

            polacz.Connection.Open();
            command.ExecuteNonQuery();
            polacz.Connection.Close();

        }

        public void Dodaj_Wypozyczenie(string pesel, string rejestracja)
        {

            int Idkl = PokazIDKlienta(pesel);
            int Idpo = PokazIDPojazdu(rejestracja);
            string naz = PokazNazwisko(pesel);


            polacz.ConnectTo();
            string commandText = "insert into dbo.Wypozyczenie(IDPojazdu,IDKlienta,DataWynajmu,NazwiskoKlienta,RejestracjaPojazdu) values(@p1,@p2,@p3,@p5,@p6)";
            SqlCommand command = new SqlCommand(commandText, polacz.Connection);

            command.Parameters.AddWithValue("@p1", Idpo);
            command.Parameters.AddWithValue("@p2", Idkl);
            command.Parameters.AddWithValue("@p3", DateTime.Now);
           
            command.Parameters.AddWithValue("@p5", naz);
            command.Parameters.AddWithValue("@p6", rejestracja);
            


            polacz.Connection.Open();
            command.ExecuteNonQuery();
            polacz.Connection.Close();



        }

        public int PokazIDKlienta(string pesel)
        {
         
            polacz.ConnectTo();
            string commandText = " select IDKlienta from dbo.Klient where Pesel = @p1";
            SqlCommand command = new SqlCommand(commandText, polacz.Connection);

            command.Parameters.AddWithValue("@p1", pesel);

            int ID = 0;
            polacz.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ID = Int32.Parse(reader["IDKlienta"].ToString());
            }
                    
            polacz.Connection.Close();
            return ID;

        }

        public int PokazIDPojazdu(string rejestracja)
        {

            polacz.ConnectTo();
            string commandText = " select IDPojazdu from dbo.Pojazd where Rejestracja = @p1";
            SqlCommand command = new SqlCommand(commandText, polacz.Connection);

            command.Parameters.AddWithValue("@p1", rejestracja);

            int ID = 0;
            polacz.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ID = Int32.Parse(reader["IDPojazdu"].ToString());
            }
            
            polacz.Connection.Close();
            return ID;

        }

        public string PokazNazwisko(string pesel)
        {

            polacz.ConnectTo();
            string commandText = " select Nazwisko from dbo.Klient where Pesel = @p1";
            SqlCommand command = new SqlCommand(commandText, polacz.Connection);

            command.Parameters.AddWithValue("@p1", pesel);

            string nazwisko = " ";
            polacz.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                nazwisko = reader["Nazwisko"].ToString();
            }
            
            polacz.Connection.Close();
            return nazwisko;

        }


        public List<Klient> PokazListeKlientow()
        {
            List<Klient> listKlientow = new List<Klient>();

            polacz.ConnectTo();
            string commandText = " select Imie,Nazwisko,Pesel from dbo.klient";
            SqlCommand command = new SqlCommand(commandText, polacz.Connection);

            polacz.Connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Klient klient = new Klient();
                klient.Imie1 = reader["Imie"].ToString() ;
                klient.Nazwisko1 = reader["Nazwisko"].ToString();
                klient.Pesel1 = reader["Pesel"].ToString() ;
                klient.Pesel1 += "\n";

                listKlientow.Add(klient);

            }


            return listKlientow;
        }


        public List<Pojazd> PokazListePojazdow()
        {
            List<Pojazd> listPojazdow = new List<Pojazd>();

            polacz.ConnectTo();
            string commandText = " select Marka,Rejestracja from dbo.Pojazd";
            SqlCommand command = new SqlCommand(commandText, polacz.Connection);

            polacz.Connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                Pojazd pojazd = new Pojazd();
                pojazd.Marka1 = reader["Marka"].ToString();
                pojazd.Rejestracja1 = reader["Rejestracja"].ToString();
                pojazd.Rejestracja1 += "\n";


                listPojazdow.Add(pojazd);

            }


            return listPojazdow;
        }



        public List<Wypozyczenie> PokazListeWypozyczen()
        {
            
            List<Wypozyczenie> listWypozyczen = new List<Wypozyczenie>();
            listWypozyczen.Clear();
            

            polacz.ConnectTo();
            string commandText = " select DataWynajmu,DataZwrotu,NazwiskoKlienta,RejestracjaPojazdu from dbo.Wypozyczenie";
            SqlCommand command = new SqlCommand(commandText, polacz.Connection);

            polacz.Connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

               // System.InvalidCastException


                Wypozyczenie wypozyczenie = new Wypozyczenie();
                wypozyczenie.NazwiskoKlienta1 = reader["NazwiskoKlienta"].ToString();
                wypozyczenie.RejestracjaPojazdu1 = reader["RejestracjaPojazdu"].ToString();
                wypozyczenie.RejestracjaPojazdu1 += "\n";
                wypozyczenie.DataWynajmu1 = (DateTime)reader["DataWynajmu"];
                
               // wypozyczenie.DataZwrotu1 =(DateTime)reader["DataZwrotu"];
                try
                {
                    wypozyczenie.DataZwrotu1 = (DateTime)reader["DataZwrotu"];
                }
                catch (InvalidCastException)
                {
                    DateTime data = new DateTime();
                    data.AddDays(1);
                    data.AddMonths(1);
                    data.AddYears(1996);
                    wypozyczenie.DataZwrotu1 = data;


                }


                listWypozyczen.Add(wypozyczenie);

            }


            return listWypozyczen;
        }

        public void OddajPojazd(string rejestracja)
        {
            polacz.ConnectTo();
            string commandText = " update dbo.Wypozyczenie set DataZwrotu = @War1 Where RejestracjaPojazdu=@War2";
            SqlCommand command = new SqlCommand(commandText, polacz.Connection);
            command.Parameters.AddWithValue("@War2", rejestracja);
            command.Parameters.AddWithValue("@War1", DateTime.Now);

            polacz.Connection.Open();
            command.ExecuteNonQuery();
            polacz.Connection.Close();



        }


    }
}
