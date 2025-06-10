using System;
using System.Text;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using projektumg;
// bazy danych zapytania
namespace plik
{
    internal class Class1
    {

        public string cs;//komęda łącząca z serwerem
        Class2 Wyswietlanie = new Class2();
        public Class1()//funkcja wywoływana przy deklaracji klasy ustawia zmienne
        {
            //cs = @"server=mysql43.mydevil.net;userid=m1366_Jordan;password=bhQyiV4HRKhzve9;database=m1366_biuro_podrozy";
            cs = @"server=127.0.0.1;userid=root;password=;database=m1366_biuro_podrozy";
        }

        public void update(string sql)//funkcja updatująca kolumne wymaga podania pełnego zapytania
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql
            cmd.ExecuteNonQuery();//wykonywanie zapytania
            con.Close();//zamykanie połączenia z bazą danych
        }
        public void delate(string tablename, string id)//funkcja updatująca kolumne wymaga podania pełnego zapytania
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            using var cmd = new MySqlCommand("DELETE FROM " + tablename + " WHERE id = " + id, con);//twożenie komendy sql
            cmd.ExecuteNonQuery();//wykonywanie zapytania
            con.Close();//zamykanie połączenia z bazą danych
        }
        public void pobierz_wycieczki(string a = "1")
        {
            using var con = new MySqlConnection(cs); //łączenie z bazą danych
            con.Open(); //otwieranie połączenia z bazą danych
            string sql = "SELECT wycieczki.id, miejsca_wycieczek.* FROM `wycieczki` JOIN miejsca_wycieczek ON miejsca_wycieczek.id = wycieczki.dokad WHERE " + a;
            using var cmd = new MySqlCommand(sql, con); //twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString(0)} {rdr.GetString("kraj")} {rdr.GetString("miasto")} {rdr.GetString("hotel")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_all_wycieczki(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT wycieczki.`id`,`ilosc_miejsc`,miejsca.miejsca,transporty.pojazd,miejsca_wycieczek.kraj,`od_kiedy`,`do_kiedy`,`czy_zwierze`,`cena_zwierze`,`cena_dziecko`,`cena_dorosly`,`polisa_podstawowa`,`polisa_premium` FROM `wycieczki` JOIN miejsca ON `miejsce_zbiorki` = miejsca.id JOIN transporty ON `rodzaj_transportu` = transporty.id JOIN miejsca_wycieczek ON `dokad` = miejsca_wycieczek.id WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            string animal = "nie";

            while (rdr.Read())//petla wyswietlająca dane
            {
                if (rdr.GetBoolean(7))
                {
                    animal = "tak";
                }
                else
                {
                    animal = "nie";
                }
                string[] dane = new string[] { "Numer: " + $"{rdr.GetString(0)}", " Miejsca: " + $"{rdr.GetString(1)}", " Zbiórka: " + $"{rdr.GetString(2)}", " Transport: " + $"{rdr.GetString(3)}", " Cel: " + $"{rdr.GetString(4)}", " Od: " + $"{rdr.GetString(5).Remove(10)}", " Do: " + $"{rdr.GetString(6).Remove(10)}", " Zwierzęta: " + animal /*$"{rdr.GetString(7)}"*/ , " Cena zwierze: " + $"{rdr.GetString(8)}", " Cena dziecko: " + $"{rdr.GetString(9)}", " Cena dorosłego: " + $"{rdr.GetString(10)}", " Cena polisy podstawowej: " + $"{rdr.GetString(11)}", " Cena polisy premium: " + $"{rdr.GetString(11)}" };
                Wyswietlanie.automat(dane);
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_wybrana_wycieczke(int id)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //string sql = "SELECT * FROM `wycieczki` WHERE id = " + id;
            string sql = "SELECT wycieczki.`id`,`ilosc_miejsc`,miejsca.miejsca,transporty.pojazd,miejsca_wycieczek.kraj,`od_kiedy`,`do_kiedy`,`czy_zwierze`,`cena_zwierze`,`cena_dziecko`,`cena_dorosly`,`polisa_podstawowa`,`polisa_premium` FROM `wycieczki` JOIN miejsca ON `miejsce_zbiorki` = miejsca.id JOIN transporty ON `rodzaj_transportu` = transporty.id JOIN miejsca_wycieczek ON `dokad` = miejsca_wycieczek.id WHERE `wycieczki`.id = " + id;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql
            //string animal = "nie";
            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                /*if (rdr.GetBoolean(7))
                {
                    animal = "tak";
                }
                else
                {
                    animal = "nie";
                }*/
                Console.WriteLine("Miejsce zbiórki: " + $"{rdr.GetString(2)}");
                Console.WriteLine("Rodzaj transport: " + $"{rdr.GetString(3)}");
                Console.WriteLine("Cel podróży: " + $"{rdr.GetString(4)}");
                Console.WriteLine("Od: " + $"{rdr.GetString(5).Remove(10)}");
                Console.WriteLine("Do: " + $"{rdr.GetString(6).Remove(10)}");
                //Console.WriteLine("Zwierzęta: " + animal);
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_bagaze(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT * FROM `bagaze` WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString("id")} {rdr.GetString("podstawa")} {rdr.GetString("doplata")} {rdr.GetString("wymiary")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_dane_klienta(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT * FROM `dane_klienta` WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString("id")} {rdr.GetString("imie")} {rdr.GetString("nazwisko")} {rdr.GetString("data_urodzenia")} {rdr.GetString("nr_tel")} {rdr.GetString("mail")} {rdr.GetString("nr_dokumentu")} {rdr.GetString("czy_wiza")}  {rdr.GetString("ilosc_wycieczek")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_faktury(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT * FROM `faktury` WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString("id")} {rdr.GetString("cena_koncowa")} {rdr.GetString("dane_klienta")} {rdr.GetString("wycieczka")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_konta(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT * FROM `konta` WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString("id")} {rdr.GetString("login")} {rdr.GetString("rodzaj_konta")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_miejsca(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT * FROM `miejsca` WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString("id")} {rdr.GetString("miejsca")} {rdr.GetString("dojazd")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_miejsca_wycieczek(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT * FROM `miejsca_wycieczek` WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString("id")} {rdr.GetString("kraj")} {rdr.GetString("miasto")} {rdr.GetString("hotel")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_podania_o_zwrot(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT * FROM `podania_o_zwrot` WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString("id")} {rdr.GetString("zakupiona_wycieczka")} {rdr.GetString("czy_rozpatrzony")} {rdr.GetString("kwota_zwrotu")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_Rodzaje_dojazdow(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT * FROM `Rodzaje_dojazdow` WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString("id")} {rdr.GetString("jaki_dojazd")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_rodzaje_wyzywienia(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT * FROM `rodzaje_wyzywienia` WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString("id")} {rdr.GetString("rodzaj")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_rodzaj_cena_wyzywienia(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT * FROM `rodzaj_cena_wyzywienia` Join rodzaje_wyzywienia ON rodzaj_cena_wyzywienia.`rodzaj` = rodzaje_wyzywienia.id WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString("rodzaj_cena_wyzywienia.id")} {rdr.GetString("rodzaje_wyzywienia.rodzaj")} {rdr.GetString("cena")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_transporty(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT * FROM `transporty` JOIN bagaze ON transporty.`bagaz` = bagaze.id WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString(0)} {rdr.GetString("pojazd")} {rdr.GetString("czas")} {rdr.GetString("podstawa")} {rdr.GetString("doplata")} {rdr.GetString("wymiary")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_zakupione_wycieczki(string a = "1")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT * FROM `zakupione_wycieczki` Join konta ON `konto` = konta.id WHERE " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine($"{rdr.GetString("zakupione_wycieczki.id")} {rdr.GetString("wycieczki")} {rdr.GetString("konto")} {rdr.GetString("ilos_doroslych")} {rdr.GetString("ilosc_dzieci")} {rdr.GetString("wymiary")} {rdr.GetString("zaliczka")} {rdr.GetString("faktura")} {rdr.GetString("login")}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public double pobierz_cene(int id, string czego)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = $"SELECT {czego} FROM `wycieczki` WHERE id = " + id;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            rdr.Read();
            double cena = rdr.GetDouble(czego);
            con.Close();//zamykanie połączenia z bazą danych

            return cena;
        }

        public double pobierz_bagaze(int id, string doplata)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = $"SELECT {doplata} FROM `bagaze` WHERE id = " + id;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            rdr.Read();
            double cena = rdr.GetDouble(doplata);
            con.Close();//zamykanie połączenia z bazą danych

            return cena;
        }

        public void pobierz_wyzywienia()
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = $"SELECT * FROM `rodzaje_wyzywienia`";
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine("Numer: " + $"{rdr.GetString(0)}" + " Rodzaj: " + $"{rdr.GetString(1)}" + " Cena: " + $"{rdr.GetString(2)}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public double pobierz_cene_wyzywienia(int id, string price)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = $"SELECT {price} FROM `rodzaje_wyzywienia` WHERE id = " + id;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            rdr.Read();
            double cena = rdr.GetDouble(price);
            con.Close();//zamykanie połączenia z bazą danych

            return cena;
        }

        public double pobierz_ilosc_dni(int id)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = $"SELECT `do_kiedy` - `od_kiedy` FROM `wycieczki` WHERE id = " + id;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            rdr.Read();
            double dni = rdr.GetDouble(0);
            con.Close();//zamykanie połączenia z bazą danych

            return dni;
        }

        public void pobierz_wycieczke(int a = 1)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT  miejsca_wycieczek.`kraj`, miejsca_wycieczek.`miasto`, miejsca_wycieczek.`hotel` FROM wycieczki JOIN miejsca_wycieczek on wycieczki.dokad = miejsca_wycieczek.id WHERE wycieczki.id = " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania


            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine("Kraj: " + $"{rdr.GetString(0)}" + " Miasto: " + $"{rdr.GetString(1)}" + " Hotel: " + $"{rdr.GetString(2)}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void pobierz_polise(int a = 1)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT `polisa_podstawowa` , `polisa_premium` FROM `wycieczki` WHERE id = " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania


            while (rdr.Read())//petla wyswietlająca dane
            {
                Console.WriteLine("1. Polisa podstawowa: " + $"{rdr.GetString(0)}");
                Console.WriteLine("2. Polisa premium: " + $"{rdr.GetString(1)}");
            }
            con.Close();//zamykanie połączenia z bazą danych
        }


        public void create_wycieczki(int ilosc_miejsc, int miejsce_zbiorki, int rodzaj_transportu, int dokad, string od_kiedy, string do_kiedy, int czy_zwierze, int cena_zwierze, int cena_dziecko, int cena_dorosły, double polisa_podsawowa, double polisa_premium)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `wycieczki` (`ilosc_miejsc`, `miejsce_zbiorki`, `rodzaj_transportu`, `dokad`, `od_kiedy`, `do_kiedy`, `czy_zwierze`, `cena_zwierze`, `cena_dziecko`, `cena_dorosly`, `polisa_podstawowa`, `polisa_premium`) VALUES ('{ilosc_miejsc}','{miejsce_zbiorki}','{rodzaj_transportu}','{dokad}','{od_kiedy}','{do_kiedy}','{czy_zwierze}','{cena_zwierze}','{cena_dziecko}','{cena_dorosły}','{polisa_podsawowa}','{polisa_premium}')", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void create_bagaze(int podstawa, double doplata, string wymiary)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `bagaze` (`podstawa`, `doplata`, `wymiary`) VALUES ('{podstawa}', '{doplata}', '{wymiary}') ", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }

        public int create_dane_klienta(string imie, string naziwsko, string data_urodzenia, string nr_tel, string mail, int czy_wiza)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `dane_klienta`(`imie`, `nazwisko`, `data_urodzenia`, `nr_tel`, `mail`, `czy_wiza`) VALUES ('{imie}','{naziwsko}','{data_urodzenia}','{nr_tel}','{mail}',{czy_wiza})", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            return (int)cmd.LastInsertedId;
        }

        public void create_faktury(double cena_koncowa, int dane_klienta, int wycieczka)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `faktury`(`cena_koncowa`, `dane_klienta`, `wycieczka`) VALUES ({cena_koncowa},{dane_klienta},{wycieczka})", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void create_konta(string login, string haslo, int rodzaj_konta, int dane)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `konta`(`login`, `haslo`, `rodzaj_konta`, `dane`) VALUES ('{login}','{hasz(haslo)}',{rodzaj_konta},{dane})", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void create_miejsca(string miejsca, int dojazd)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `miejsca`(`miejsca`, `dojazd`) VALUES ('{miejsca}',{dojazd})", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void create_miejsca_wycieczek(string kraj, string miasto, string hotel)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `miejsca_wycieczek`(`kraj`, `miasto`, `hotel`) VALUES ('{kraj}','{miasto}','{hotel}')", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void create_podania_o_zwrot(int zakupiona_wycieczka, int czy_rozpatrzony, double kwota_zwrotu)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `podania_o_zwrot`(`zakupiona_wycieczka`, `czy_rozpatrzony`, `kwota_zwrotu`) VALUES ({zakupiona_wycieczka},{czy_rozpatrzony},{kwota_zwrotu})", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void create_Rodzaje_dojazdow(string jaki_dojazd)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `Rodzaje_dojazdow`(`jaki_dojazd`) VALUES ('{jaki_dojazd}')", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void create_rodzaje_wyzywienia(string rodzaj)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `rodzaje_wyzywienia`(`rodzaj`) VALUES ('{rodzaj}')", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void create_rodzaj_cena_wyzywienia(int rodzaj, double cena, int wycieczka)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `rodzaj_cena_wyzywienia`(`rodzaj`, `cena`, `wycieczka`) VALUES ({rodzaj},{cena},{wycieczka})", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void create_transporty(string pojazd, string czas, int bagaz)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `transporty`(`pojazd`, `czas`, `bagaz`) VALUES ('{pojazd}','{czas}',{bagaz})", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }
        public void create_zakupione_wycieczki(int wycieczki, int konto, int ilos_doroslych, int ilosc_dzieci, double zaliczka, int faktura)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `zakupione_wycieczki`(`wycieczki`, `konto`, `ilos_doroslych`, `ilosc_dzieci`, `zaliczka`, `faktura`) VALUES ({wycieczki},{konto},{ilos_doroslych},{ilosc_dzieci},{zaliczka},{faktura})", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }

        public bool czy_istnieje_login(string login)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"SELECT * FROM `konta` WHERE `login` = '{login}'", con);
            bool pomoc = false; // czy istnieje
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())//wykonywanie zapytania bez zwracania danych
                pomoc = true;
            con.Close();//zamykanie połączenia z bazą danych
            return pomoc;
        }

        public double czy_istnieje_kod(string kod)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"SELECT mnoznik_znizki FROM `kody_rabatowe` WHERE `kod` = '{kod}'", con);
            double pomoc = 0; // czy istnieje
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())//wykonywanie zapytania bez zwracania danych
                pomoc = rdr.GetDouble(0);
            con.Close();//zamykanie połączenia z bazą danych
            return pomoc;
        }

        public bool czy_login_i_haslo(string login, string haslo)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"SELECT * FROM `konta` WHERE `login` = '{login}'", con);
            bool pomoc = false; // czy istnieje
            using MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())//wykonywanie zapytania bez zwracania danych
            {
                string pass = rdr.GetString("haslo");
                if (heck_hasz(haslo, pass))
                    pomoc = true;
            }
            con.Close();//zamykanie połączenia z bazą danych
            return pomoc;
        }
        public bool get_status(string login)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"SELECT * FROM `konta` WHERE `login` = '{login}'", con);
            bool pomoc = false; // czy istnieje
            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();//wykonywanie zapytania
            pomoc = rdr.GetBoolean("rodzaj_konta");
            con.Close();//zamykanie połączenia z bazą danych
            return pomoc;
        }

        public string hasz(string h)//haszowanie hasła
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(h));

            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public bool czy_istnieje_wycieczka(int id, string reszta_zap = "")
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT Count(*) FROM `wycieczki` JOIN miejsca_wycieczek ON miejsca_wycieczek.id = wycieczki.dokad WHERE wycieczki.id = " + id + reszta_zap;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            bool bol;

            rdr.Read();//petla wyswietlająca dane

            bol = rdr.GetBoolean(0);
            con.Close();//zamykanie połączenia z bazą danych
            return bol;
        }
        public int ilosc_osob(int id)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = "SELECT ilosc_miejsc FROM `wycieczki` WHERE wycieczki.id = " + id;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania

            int ile;

            rdr.Read();//petla wyswietlająca dane

            ile = rdr.GetInt32(0);
            con.Close();//zamykanie połączenia z bazą danych
            return ile;
        }

        public bool heck_hasz(string h, string hashed)
        {
            if (SHA256.Equals(hasz(h), hashed))//sprawdza szy hasło jest zbieżne z swoim haszem
                return true;
            return false;

        }

        public void create_faktura(string imie, string nazwisko, string nrTel, string email, string dataUro, string nrDowodu, int nrWycieczki, string typWycieczki, string zwierzeta, double kwotaKoncowa)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            //twożenie komendy sql
            using var cmd = new MySqlCommand($"INSERT INTO `faktura`(`imie`, `nazwisko`, `nrTele` , `email` , `dataUro` , `nrDowodu` , `nrWycieczki` , `typWycieczki` , `zwierzeta` , `kwotaKoncowa`) VALUES ('{imie}','{nazwisko}','{nrTel}','{email}','{dataUro}','{nrDowodu}','{nrWycieczki}','{typWycieczki}','{zwierzeta}','{kwotaKoncowa}')", con);
            cmd.ExecuteNonQuery();//wykonywanie zapytania bez zwracania danych
            con.Close();//zamykanie połączenia z bazą danych
        }

        public void update_osoby(int a, int ile)
        {
            using var con = new MySqlConnection(cs);//łączenie z bazą danych
            con.Open();//otwieranie połączenia z bazą danych
            string sql = $"UPDATE wycieczki SET ilosc_miejsc = `ilosc_miejsc` - {ile} WHERE id = " + a;
            using var cmd = new MySqlCommand(sql, con);//twożenie komendy sql

            using MySqlDataReader rdr = cmd.ExecuteReader();//wykonywanie zapytania
            con.Close();//zamykanie połączenia z bazą danych
        }

    }
}