using System;
using plik;

namespace projektumg
{
    class Program
    {
        static void Main(string[] args)
        {

            Int32 konto, wycieczki = 0, nrWycieczki = 0, osoby = 0, rodzaj = 0, wybor = 0, czy_wiza2, miejsce_zbiorki = 0, rodzaj_transportu = 0, dokad = 0, zwierze, zwierze_cena = 0, dziecko_cena = 0, dorosly_cena = 0, dorosly = 0, dziecko = 0, wyzywienie = 0, wybranie_polisy = 0, ilosc_osob = 0;
            String login, haslo, imie, nazwisko, mail, typ = "t", w1, w2, w3, dodBagaz, rabaty, fImie, fNazwisko, fNumerTel, fEmail, fNrDowodu, data_urodzenia, nr_tel, czy_wiza, do_kiedy, od_kiedy, zwierze_tn, wybranie_zwierzaka = "n", waga_bagazu, fDataUro, kodRabatowy, fTypWycieczki, fZwierze, polisa;
            Boolean logowanie = true, zarzadzanie = true, wycieczka = true, czy_liczba = true, czy_dziala = true;
            double suma = 0, polisy_premium_cena = 0, polisy_cena = 0, price_dorosly, price_dziecko, price_zwierze, zwierzak, price_bagaze, price_wyzywienie, price_polisa;

            Class1 MySqlzap = new Class1();
            Class2 Wyswietlanie = new Class2();
            Console.WriteLine("Witaj w biurze podróży Dżordan!");
            Console.WriteLine();

            //logowanie do systemu
            Console.WriteLine("Wybierz opcję logowania: ");
            while (logowanie == true)
            {
                try
                {
                    Wyswietlanie.tabelka_gora();
                    Wyswietlanie.tabelka_srodek("1. Logowanie");
                    Wyswietlanie.tabelka_srodek("2. Utwórz konto klienta");
                    Wyswietlanie.tabelka_srodek("3. Wyjście");
                    Wyswietlanie.tabelka_dol();
                    konto = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                }
                catch
                {
                    konto = 10;
                    Console.Clear();
                }

                if (konto == 1)
                {
                    //łączenie z kontami klientów z bazy danych
                    do
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj login: ");
                            login = Console.ReadLine();
                        } while (!MySqlzap.czy_istnieje_login(login));//sprawdza czy login istnieje w bazie

                        Console.WriteLine("Podaj hasło: ");
                        haslo = Console.ReadLine();
                    } while (!MySqlzap.czy_login_i_haslo(login, haslo));//sprawdza czy login i chasło są poprawne

                    logowanie = false;
                    if (MySqlzap.get_status(login))//sprawdza rodzaj konta
                    {
                        typ = "admin";
                    }
                    else
                    {
                        typ = "klient";
                    }
                }
                else if (konto == 2)
                {
                    //tworzenie nowego użytkownika
                    do
                    {
                        Console.WriteLine("Podaj imie: ");
                        imie = Console.ReadLine();
                        Console.Clear();
                    } while (imie.Length <= 2);
                    do
                    {

                        Console.WriteLine("Podaj naziwsko: ");
                        nazwisko = Console.ReadLine();
                        Console.Clear();
                    } while (imie.Length <= 2);
                    do
                    {
                        Console.WriteLine("Podaj datę urodzenia(YYYY-MM-DD): ");
                        data_urodzenia = Console.ReadLine();
                        Console.Clear();
                        czy_liczba = true;
                        try
                        {

                            if (int.Parse(data_urodzenia.Substring(0, 4)) < 1900 || int.Parse(data_urodzenia.Substring(0, 4)) > 2023)
                            {
                                Console.WriteLine("Podaj poprawną date");
                                czy_liczba = false;
                            }
                            if (int.Parse(data_urodzenia.Substring(5, 2)) > 12 || int.Parse(data_urodzenia.Substring(5, 2)) < 1)
                            {
                                Console.WriteLine("Podaj poprawną date");
                                czy_liczba = false;
                            }
                            else
                            if (int.Parse(data_urodzenia.Substring(8, 2)) > 31 || int.Parse(data_urodzenia.Substring(8, 2)) < 1)
                            {
                                Console.WriteLine("Podaj poprawną date");
                                czy_liczba = false;
                            }
                        }
                        catch
                        {
                            czy_liczba = false;
                            Console.Clear();
                        }
                    } while (!czy_liczba || data_urodzenia[4] != '-' || data_urodzenia[7] != '-' || data_urodzenia.Length != 10);
                    do
                    {
                        Console.WriteLine("Podaj nr_tel(123456789): ");
                        nr_tel = Console.ReadLine();
                    } while (nr_tel.Length != 9);
                    do
                    {
                        Console.WriteLine("Podaj maila: ");
                        mail = Console.ReadLine();
                    } while (!mail.Contains("@"));

                    do
                    {
                        Console.WriteLine("Podaj czy posiadasz wizę (t/n): ");
                        czy_wiza = Console.ReadLine();
                    } while (czy_wiza != "t" && czy_wiza != "n");
                    czy_wiza2 = 0;
                    if (czy_wiza == "t")
                        czy_wiza2 = 1;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Ustaw swój login: ");
                        login = Console.ReadLine();
                    } while (MySqlzap.czy_istnieje_login(login));//sprawdza czy login istnieje w bazie

                    Console.WriteLine("Ustaw hasło: ");
                    haslo = Console.ReadLine();
                    MySqlzap.create_konta(login, haslo, 0, MySqlzap.create_dane_klienta(imie, nazwisko, data_urodzenia, nr_tel, mail, czy_wiza2));
                    Console.Clear();
                    Console.WriteLine("Gratulacje, twoje konto zostało utworzone i możesz się na nie zalogować.");
                }
                else if (konto == 3)
                {
                    System.Environment.Exit(1);//wychodzenie z programu
                }
                else
                {
                    //wybranie niepoprawnej opcji
                    logowanie = true;
                    Console.WriteLine("Wybrałeś niepoprawną opcję. Wybierz ponownie opcję logowania: ");
                };
            };

            Console.Clear();

            if (typ == "klient")
            {
                //menu klienta

                Console.WriteLine("Jesteś zalogowany jako " + typ + ". " + "(Wciśnij ENTER, aby kontynuować)");
                Console.ReadKey(true);
                Console.Clear();

                Console.WriteLine("Wybierz rodzaj wycieczki: ");
                while (wycieczka == true)
                {
                    //Wybieranie rodzaju wycieczki
                    try
                    {

                        Wyswietlanie.tabelka_gora();
                        Wyswietlanie.tabelka_srodek("1. Wycieczka krajowa");
                        Wyswietlanie.tabelka_srodek("2. Wycieczka zagraniczna");
                        Wyswietlanie.tabelka_srodek("3. Wyjście");
                        Wyswietlanie.tabelka_dol();

                        rodzaj = Int32.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch
                    {
                        rodzaj = 10;
                        Console.Clear();
                    }

                    if (rodzaj == 1)
                    {
                        do
                        {

                            czy_dziala = true;
                            try
                            {
                                //Wycieczki krajowe

                                Console.WriteLine("Lista wycieczek krajowych: ");
                                Console.WriteLine();

                                //Tutaj rozwija się lista wycieczek krajowych
                                MySqlzap.pobierz_all_wycieczki("miejsca_wycieczek.kraj = 'Polska'");

                                //Wybranie wycieczki przez klienta
                                Console.WriteLine("Podaj numer wycieczki, która ciebie interesuje: ");
                                wybor = Int32.Parse(Console.ReadLine());
                                Console.Clear();
                            }
                            catch
                            {
                                czy_dziala = false;
                                Console.Clear();
                            }
                        } while (!czy_dziala || !MySqlzap.czy_istnieje_wycieczka(wybor, " AND miejsca_wycieczek.kraj = 'Polska'"));
                        wycieczka = false;
                    }
                    else if (rodzaj == 2)
                    {
                        do
                        {

                            czy_dziala = true;
                            try
                            {
                                //Wycieczki zagraniczne
                                Console.WriteLine("Lista wycieczek zagranicznych: ");
                                Console.WriteLine();

                                //Tutaj rozwija się lista wycieczek zagranicznych
                                MySqlzap.pobierz_all_wycieczki("miejsca_wycieczek.kraj != 'Polska'");

                                //Wybranie wycieczki przez klienta
                                Console.WriteLine("Podaj numer wycieczki, która ciebie interesuje: ");
                                wybor = Int32.Parse(Console.ReadLine());
                                Console.Clear();
                            }
                            catch
                            {
                                czy_dziala = false;
                                Console.Clear();
                            }
                        } while (!czy_dziala || !MySqlzap.czy_istnieje_wycieczka(wybor, " AND miejsca_wycieczek.kraj != 'Polska'"));
                        wycieczka = false;
                    }
                    else if (rodzaj == 3)
                    {
                        //Wybranie wyjścia
                        System.Environment.Exit(1);
                    }
                    else
                    {
                        //Wybranie niepoprawnej opcji
                        Console.WriteLine("Wybrałeś niepoprawną opcję. Wybierz ponownie rodzaj wycieczki: ");
                    };

                };

                //Podanie ilości osób
                do
                {
                    czy_dziala = true;
                    try
                    {
                        //Ilość dorosłych w wycieczce
                        Console.WriteLine("Podaj ilość osób dorosłych uczestniczących w wycieczce: ");
                        ilosc_osob += dorosly = Int32.Parse(Console.ReadLine());// należy pokazywać czy sa miejsca
                        price_dorosly = MySqlzap.pobierz_cene(wybor, "cena_dorosly");
                        suma = suma + (dorosly * price_dorosly);
                        Console.Clear();
                    }
                    catch
                    {
                        czy_dziala = false;
                        Console.Clear();
                    }
                } while (MySqlzap.ilosc_osob(wybor) >= ilosc_osob && !czy_dziala);
                do
                {
                    czy_dziala = true;
                    try
                    {
                        //Ilość dzieci w wycieczce
                        Console.WriteLine("Podaj ilość dzieci uczestniczących w wycieczce: ");
                        ilosc_osob += dziecko = Int32.Parse(Console.ReadLine());
                        price_dziecko = MySqlzap.pobierz_cene(wybor, "cena_dziecko");
                        suma = suma + (dziecko * price_dziecko);
                        Console.Clear();
                    }
                    catch
                    {
                        czy_dziala = false;
                        Console.Clear();
                    }
                } while (MySqlzap.ilosc_osob(wybor) >= ilosc_osob && !czy_dziala);

                //Możliwość zabrania zwierzęcia
                zwierzak = MySqlzap.pobierz_cene(wybor, "cena_zwierze");

                if (zwierzak != 0)
                {
                    do
                    {
                        Console.WriteLine("Czy chcesz ze sobą wziąć zwierze? (t/n)");
                        wybranie_zwierzaka = Console.ReadLine();
                        Console.Clear();
                    } while (wybranie_zwierzaka != "t" && wybranie_zwierzaka != "n");

                    if (wybranie_zwierzaka == "t")
                    {
                        price_zwierze = MySqlzap.pobierz_cene(wybor, "cena_zwierze");
                        suma = suma + price_zwierze;
                    }
                    Console.Clear();
                }

                //Czy klient ma dodatkowe bagaże
                do
                {
                    Console.WriteLine("Czy posiadasz dodatkowy bagaż? (t/n)");
                    dodBagaz = Console.ReadLine();
                    Console.Clear();
                } while (dodBagaz != "t" && dodBagaz != "n");

                if (dodBagaz == "t")
                {
                    do
                    {
                        Console.WriteLine("Czy twój dodatkowy bagaż przekracza 4 kilogramy? (t/n)");
                        waga_bagazu = Console.ReadLine();
                        Console.Clear();
                    } while (waga_bagazu != "t" && waga_bagazu != "n");
                    if (waga_bagazu == "t")
                    {
                        price_bagaze = MySqlzap.pobierz_bagaze(3, "doplata");
                        suma = suma + price_bagaze;
                    }
                    if (waga_bagazu == "n")
                    {
                        price_bagaze = MySqlzap.pobierz_bagaze(1, "doplata");
                        suma = suma + price_bagaze;
                    }

                }


                //Czy klient chce wykupić wyżywienie
                do
                {
                    czy_dziala = true;
                    try
                    {
                        Console.WriteLine("Wybierz rodzaj wyżywienia: ");
                        MySqlzap.pobierz_wyzywienia();
                        wyzywienie = int.Parse(Console.ReadLine());
                        price_wyzywienie = MySqlzap.pobierz_cene_wyzywienia(wyzywienie, "cena");
                        suma = suma + (((dorosly + dziecko) * price_wyzywienie) /* *ilosc_dni*/);
                        Console.Clear();
                    }
                    catch
                    {
                        czy_dziala = false;
                        Console.Clear();
                    }
                } while (wyzywienie < 1 || wyzywienie > 5);

                //Wykupienie polisy

                do
                {
                    Console.WriteLine("Czy chcesza wykupić polisę? (t/n)");
                    polisa = Console.ReadLine();
                    Console.Clear();
                } while (polisa != "t" && polisa != "n");

                if (polisa == "t")
                {
                    Console.WriteLine("Wybierz rodzaj polisy: ");
                    MySqlzap.pobierz_polise(wybor);
                    do
                    {

                        czy_liczba = true;
                        try
                        {
                            wybranie_polisy = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            czy_liczba = false;
                            Console.Clear();
                        }
                    } while (!czy_liczba);
                    if (wybranie_polisy == 1)
                    {
                        price_polisa = MySqlzap.pobierz_cene(wybor, "polisa_podstawowa");
                        suma = suma + (((dorosly + dziecko) * price_polisa));
                    }
                    if (wybranie_polisy == 2)
                    {
                        price_polisa = MySqlzap.pobierz_cene(wybor, "polisa_premium");
                        suma = suma + (((dorosly + dziecko) * price_polisa));
                    }

                    Console.Clear();
                }


                Console.Clear();

                //Czy klient posiada kod rabatowy
                do
                {
                    Console.WriteLine("Czy posiadasz kod rabatowy? (t/n)");
                    rabaty = Console.ReadLine();
                    Console.Clear();
                } while (rabaty != "t" && rabaty != "n");

                if (rabaty == "t")
                {
                    czy_dziala = true;
                    kodRabatowy = " ";
                    Console.WriteLine("Podaj kod rabatowy: ");
                    kodRabatowy = Console.ReadLine(); //kod musi byc konkretny zeby był warunek
                    if (MySqlzap.czy_istnieje_kod(kodRabatowy) != 0)
                    {
                        suma = suma * MySqlzap.czy_istnieje_kod(kodRabatowy);
                    }
                    Console.Clear();
                }

                //Uzupełnienie danych klienta do faktury               
                Console.WriteLine("Proszę uzupełnić dane do faktury.");
                Console.WriteLine();
                do
                {
                    Console.WriteLine("Podaj imie:");
                    fImie = Console.ReadLine();
                    Console.Clear();
                } while (fImie.Length <= 2);
                do
                {
                    Console.WriteLine("Podaj nazwisko:");
                    fNazwisko = Console.ReadLine();
                    Console.Clear();
                } while (fNazwisko.Length <= 2);
                do
                {
                    Console.WriteLine("Podaj datę urodzenia(YYYY-MM-DD): ");
                    fDataUro = Console.ReadLine();
                    Console.Clear();
                    czy_liczba = true;
                    try
                    {

                        if (int.Parse(fDataUro.Substring(0, 4)) < 1900 || int.Parse(fDataUro.Substring(0, 4)) > 2023)
                        {
                            Console.WriteLine("Podaj poprawną date");
                            czy_liczba = false;
                        }
                        if (int.Parse(fDataUro.Substring(5, 2)) > 12 || int.Parse(fDataUro.Substring(5, 2)) < 1)
                        {
                            Console.WriteLine("Podaj poprawną date");
                            czy_liczba = false;
                        }
                        else
                        if (int.Parse(fDataUro.Substring(8, 2)) > 31 || int.Parse(fDataUro.Substring(8, 2)) < 1)
                        {
                            Console.WriteLine("Podaj poprawną date");
                            czy_liczba = false;
                        }
                    }
                    catch
                    {
                        czy_liczba = false;
                        Console.Clear();
                    }
                } while (!czy_liczba || fDataUro[4] != '-' || fDataUro[7] != '-' || fDataUro.Length != 10);
                do
                {
                    Console.WriteLine("Podaj numer telefonu(123456789): ");
                    fNumerTel = Console.ReadLine();
                    Console.Clear();
                } while (fNumerTel.Length != 9);
                do
                {
                    Console.WriteLine("Podaj adres email: ");
                    fEmail = Console.ReadLine();
                    Console.Clear();
                } while (!fEmail.Contains("@"));
                do
                {
                    Console.WriteLine("Podaj numer dowodu osobistego(ABC123456): ");
                    fNrDowodu = Console.ReadLine();
                    Console.Clear();
                    czy_liczba = true;
                    try
                    {
                        if ((int)(char)fNrDowodu[0] < 65 || (int)(char)fNrDowodu[0] > 95) { czy_liczba = false; };
                        if ((int)(char)fNrDowodu[1] < 65 || (int)(char)fNrDowodu[1] > 95) { czy_liczba = false; };
                        if ((int)(char)fNrDowodu[2] < 65 || (int)(char)fNrDowodu[2] > 95) { czy_liczba = false; };
                        int.Parse(fNrDowodu.Substring(3, 6));
                    }
                    catch
                    {
                        czy_liczba = false;
                        Console.Clear();
                    }
                } while (!czy_liczba);

                //Wypisanie faktury
                Console.WriteLine("FAKTURA");
                Console.WriteLine();

                Console.WriteLine("Dane:");
                Console.WriteLine();
                Console.WriteLine("Imię: " + fImie);
                Console.WriteLine("Nazwisko: " + fNazwisko);
                Console.WriteLine("Numer telefonu: " + fNumerTel);
                Console.WriteLine("Email: " + fEmail);
                Console.WriteLine("Data urodzenia: " + fDataUro);
                Console.WriteLine("Numer dowodu osobistego: " + fNrDowodu);
                Console.WriteLine();

                if (rodzaj == 1)
                {
                    Console.WriteLine("Rodzaj wycieczki: krajowa");
                    fTypWycieczki = "krajowa";
                }
                else
                {
                    Console.WriteLine("Rodzaj wycieczki: zagraniczna");
                    fTypWycieczki = "zagraniczna";
                }

                MySqlzap.pobierz_wycieczke(wybor);
                Console.WriteLine("Ilość osób dorosłych: " + dorosly);
                Console.WriteLine("Ilość dzieci: " + dziecko);

                MySqlzap.pobierz_wybrana_wycieczke(wybor);
                if (wybranie_zwierzaka == "t")
                {
                    Console.WriteLine("Zwierzęta: tak");
                    fZwierze = "tak";
                }
                else
                {
                    Console.WriteLine("Zwierzęta: nie");
                    fZwierze = "nie";
                }


                Console.WriteLine();
                Console.WriteLine("Do zapłaty: " + suma + " PLN");

                //wpisanie faktury do bazy danych
                MySqlzap.create_faktura(fImie, fNazwisko, fNumerTel, fEmail, fDataUro, fNrDowodu, wybor, fTypWycieczki, fZwierze, suma);

                //Zmiana ilości dostępnych miejsc w wycieczce
                MySqlzap.update_osoby(wybor, ilosc_osob);

            }
            else
            {
                //menu admina

                Console.WriteLine("Jesteś zalogowany jako " + typ + ". " + "(Wciśnij ENTER, aby kontynuować)");
                Console.ReadKey(true);
                Console.Clear();

                Console.WriteLine("Zarządzanie wycieczkami: ");
                while (zarzadzanie == true)
                {
                menu:
                    try
                    {
                        Wyswietlanie.tabelka_gora(43);
                        Wyswietlanie.tabelka_srodek("1. Edycja istniejącej wycieczki", 43);
                        Wyswietlanie.tabelka_srodek("2. Dodanie nowej wycieczki", 43);
                        Wyswietlanie.tabelka_srodek("3. Usunięcie wycieczki", 43);
                        Wyswietlanie.tabelka_srodek("4. Wyjście", 43);
                        Wyswietlanie.tabelka_dol(43);
                        wycieczki = Int32.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch
                    {
                        wycieczki = 10;
                        Console.Clear();
                    }

                    if (wycieczki == 1)
                    {
                        do
                        {
                            //edytowanie wycieczki
                            Console.Clear();
                            Console.WriteLine("Wybierz wycieczkę, którą chcesz edytować: ");
                            MySqlzap.pobierz_wycieczki();//tutaj rozwija się lista wszystkich wycieczek
                            Console.WriteLine("Jeśli chcesz wrócić kliknij (0)");
                            nrWycieczki = Int32.Parse(Console.ReadLine());//zadanie dla Dawidka
                            czy_dziala = true;
                            try
                            {

                                if (nrWycieczki == 0)
                                {
                                    Console.Clear();
                                    goto menu;
                                }
                            }
                            catch
                            {
                                czy_dziala = false;
                            }
                        } while (!czy_dziala || !MySqlzap.czy_istnieje_wycieczka(nrWycieczki));
                        Console.Clear();

                        //odniesienie do danej wycieczki

                        //zmiana terminu
                        do
                        {
                            Console.WriteLine("Chcesz zmienić termin? (t/n)");
                            w1 = Console.ReadLine();
                            Console.Clear();
                        } while (w1 != "t" && w1 != "n");
                        //tworzenie zapytania 
                        string sqlPomoc = "UPDATE `wycieczki` SET ";

                        if (w1 == "t")
                        {
                            do
                            {
                                Console.WriteLine("Wprowadź nowy termin od_kiedy (YYYY-MM-DD): ");
                                od_kiedy = Console.ReadLine();
                                Console.Clear();
                                czy_liczba = true;
                                try
                                {
                                    if (int.Parse(od_kiedy.Substring(0, 4)) < 1900 || int.Parse(od_kiedy.Substring(0, 4)) > 2023)
                                    {
                                        Console.WriteLine("Podaj poprawną date");
                                        czy_liczba = false;
                                    }
                                    if (int.Parse(od_kiedy.Substring(5, 2)) > 12 || int.Parse(od_kiedy.Substring(5, 2)) < 1)
                                    {
                                        Console.WriteLine("Podaj poprawną date");
                                        czy_liczba = false;
                                    }
                                    else
                                    if (int.Parse(od_kiedy.Substring(8, 2)) > 31 || int.Parse(od_kiedy.Substring(8, 2)) < 1)
                                    {
                                        Console.WriteLine("Podaj poprawną date");
                                        czy_liczba = false;
                                    }
                                }
                                catch
                                {
                                    czy_liczba = false;
                                    Console.Clear();
                                }
                            } while (!czy_liczba || od_kiedy[4] != '-' || od_kiedy[7] != '-' || od_kiedy.Length != 10);
                            do
                            {
                                Console.WriteLine("Wprowadź nowy termin do_kiedy (YYYY-MM-DD): ");
                                do_kiedy = Console.ReadLine();
                                Console.Clear();
                                czy_liczba = true;
                                try
                                {
                                    if (int.Parse(do_kiedy.Substring(0, 4)) < 1900 || int.Parse(do_kiedy.Substring(0, 4)) > 2023)
                                    {
                                        Console.WriteLine("Podaj poprawną date");
                                        czy_liczba = false;
                                    }
                                    if (int.Parse(do_kiedy.Substring(5, 2)) > 12 || int.Parse(do_kiedy.Substring(5, 2)) < 1)
                                    {
                                        Console.WriteLine("Podaj poprawną date");
                                        czy_liczba = false;
                                    }
                                    else
                                    if (int.Parse(do_kiedy.Substring(8, 2)) > 31 || int.Parse(do_kiedy.Substring(8, 2)) < 1)
                                    {
                                        Console.WriteLine("Podaj poprawną date");
                                        czy_liczba = false;
                                    }
                                }
                                catch
                                {
                                    czy_liczba = false;
                                    Console.Clear();
                                }
                            } while (!czy_liczba || do_kiedy[4] != '-' || do_kiedy[7] != '-' || do_kiedy.Length != 10);
                            sqlPomoc += "`od_kiedy`='" + od_kiedy + "', `do_kiedy`= '" + do_kiedy + "' ";//dodanie zmiany terminu do zapytania
                        };
                        Console.Clear();

                        //zmiana ceny
                        do
                        {
                            Console.WriteLine("Chcesz zmienić cenę? (t/n)");
                            w2 = Console.ReadLine();
                            Console.Clear();
                        } while (w2 != "t" && w2 != "n");
                        if (w2 == "t")
                        {
                            do
                            {
                                czy_dziala = true;
                                try
                                {
                                    Console.WriteLine("Wprowadź nową cenę zwierzęcia: ");
                                    zwierze_cena = Int32.Parse(Console.ReadLine());
                                    Console.Clear();
                                }
                                catch
                                {
                                    czy_dziala = false;
                                    Console.Clear();
                                }
                            } while (!czy_dziala);
                            do
                            {
                                czy_dziala = true;
                                try
                                {
                                    Console.WriteLine("Wprowadź nową cenę dziecka: ");
                                    dziecko_cena = Int32.Parse(Console.ReadLine());
                                    Console.Clear();
                                }
                                catch
                                {
                                    czy_dziala = false;
                                    Console.Clear();
                                }
                            } while (!czy_dziala);
                            do
                            {
                                czy_dziala = true;
                                try
                                {
                                    Console.WriteLine("Wprowadź nową cenę dorosłego: ");
                                    dorosly_cena = Int32.Parse(Console.ReadLine());
                                    Console.Clear();
                                }
                                catch
                                {
                                    czy_dziala = false;
                                    Console.Clear();
                                }
                            } while (!czy_dziala);
                            if (w1 == "t") sqlPomoc += ",";//sprawdzenie czy trzeba wstawić przecinek
                            sqlPomoc += "cena_zwierze = " + zwierze_cena + ", cena_dziecko = " + dziecko_cena + ", cena_dorosly = " + dorosly_cena;//dodanie zmiany ceny do zapytania
                            //ustawienie nowej ceny w bazie danych
                        };
                        Console.Clear();

                        //zmiana ilości osób
                        do
                        {
                            Console.WriteLine("Chcesz zmienić ilość osób? (t/n)");
                            w3 = Console.ReadLine();
                            Console.Clear();
                        } while (w3 != "t" && w3 != "n");
                        if (w3 == "t")
                        {
                            do
                            {
                                czy_dziala = true;
                                try
                                {
                                    Console.WriteLine("Wprowadź nową ilość osób: ");
                                    osoby = Int32.Parse(Console.ReadLine());
                                    Console.Clear();
                                }
                                catch
                                {
                                    czy_dziala = false;
                                    Console.Clear();
                                }
                            } while (!czy_dziala);
                            if (w1 == "t" || w2 == "t") sqlPomoc += ",";//sprawdzenie czy trzeba wstawić przecinek
                            sqlPomoc += " ilosc_miejsc = '" + osoby + "'";//dodanie zmiany ilości miejsc do zapytania
                            //ustawienie nowej ilości osób w bazie danych
                        };
                        Console.Clear();

                        if (w1 == "t" || w2 == "t" || w3 == "t")
                        {
                            MySqlzap.update(sqlPomoc + "WHERE id=" + nrWycieczki);
                            Console.WriteLine("Zmiany zostały zapisane.");
                        }

                        Console.WriteLine("Wciśnij ENTER, aby kontynuować.");
                        Console.ReadKey(true);
                        Console.Clear();

                    }
                    else if (wycieczki == 2)
                    {
                        //tworzenie nowej wycieczki

                        Console.Clear();

                        do
                        {
                            czy_dziala = true;
                            try
                            {
                                Console.WriteLine("Podaj ilość osób, które mogą uczestniczyć w  wycieczce: ");
                                osoby = Int32.Parse(Console.ReadLine());
                                Console.Clear();
                            }
                            catch
                            {
                                czy_dziala = false;
                                Console.Clear();
                            }
                        } while (!czy_dziala);
                        do
                        {
                            czy_dziala = true;
                            try
                            {
                                Console.WriteLine("Podaj miejsce_zbiurk: ");
                                MySqlzap.pobierz_miejsca_wycieczek();
                                miejsce_zbiorki = int.Parse(Console.ReadLine());
                                Console.Clear();
                            }
                            catch
                            {
                                czy_dziala = false;
                                Console.Clear();
                            }
                        } while (!czy_dziala);
                        do
                        {
                            czy_dziala = true;
                            try
                            {
                                Console.WriteLine("Podaj rodzaj transportu: ");
                                MySqlzap.pobierz_transporty();
                                rodzaj_transportu = int.Parse(Console.ReadLine());
                                Console.Clear();
                            }
                            catch
                            {
                                czy_dziala = false;
                                Console.Clear();
                            }
                        } while (!czy_dziala);
                        do
                        {
                            czy_dziala = true;
                            try
                            {
                                Console.WriteLine("Podaj dokąd wycieczka się ma odbyć: ");
                                MySqlzap.pobierz_miejsca_wycieczek();
                                dokad = int.Parse(Console.ReadLine());
                                Console.Clear();
                            }
                            catch
                            {
                                czy_dziala = false;
                                Console.Clear();
                            }
                        } while (!czy_dziala);
                        do
                        {
                            Console.WriteLine("Podaj od kiedy będzie wycieczka (YYYY-MM-DD): ");
                            od_kiedy = Console.ReadLine();
                            Console.Clear();
                            czy_liczba = true;
                            try
                            {
                                if (int.Parse(od_kiedy.Substring(0, 4)) < 1900 || int.Parse(od_kiedy.Substring(0, 4)) > 2023)
                                {
                                    Console.WriteLine("Podaj poprawną date");
                                    czy_liczba = false;
                                }
                                if (int.Parse(od_kiedy.Substring(5, 2)) > 12 || int.Parse(od_kiedy.Substring(5, 2)) < 1)
                                {
                                    Console.WriteLine("Podaj poprawną date");
                                    czy_liczba = false;
                                }
                                else
                                if (int.Parse(od_kiedy.Substring(8, 2)) > 31 || int.Parse(od_kiedy.Substring(8, 2)) < 1)
                                {
                                    Console.WriteLine("Podaj poprawną date");
                                    czy_liczba = false;
                                }
                            }
                            catch
                            {
                                czy_liczba = false;
                                Console.Clear();
                            }
                        } while (!czy_liczba || od_kiedy[4] != '-' || od_kiedy[7] != '-' || od_kiedy.Length != 10);
                        do
                        {
                            Console.WriteLine("Podaj do kiedy będzie wycieczka (YYYY-MM-DD): ");
                            do_kiedy = Console.ReadLine();
                            Console.Clear();
                            czy_liczba = true;
                            try
                            {
                                if (int.Parse(do_kiedy.Substring(0, 4)) < 1900 || int.Parse(do_kiedy.Substring(0, 4)) > 2023)
                                {
                                    Console.WriteLine("Podaj poprawną date");
                                    czy_liczba = false;
                                }
                                if (int.Parse(do_kiedy.Substring(5, 2)) > 12 || int.Parse(do_kiedy.Substring(5, 2)) < 1)
                                {
                                    Console.WriteLine("Podaj poprawną date");
                                    czy_liczba = false;
                                }
                                else
                                if (int.Parse(do_kiedy.Substring(8, 2)) > 31 || int.Parse(do_kiedy.Substring(8, 2)) < 1)
                                {
                                    Console.WriteLine("Podaj poprawną date");
                                    czy_liczba = false;
                                }
                            }
                            catch
                            {
                                czy_liczba = false;
                                Console.Clear();
                            }
                        } while (!czy_liczba || do_kiedy[4] != '-' || do_kiedy[7] != '-' || do_kiedy.Length != 10);
                        do
                        {
                            Console.WriteLine("Podaj czy możliwe jest zabranie zwierzęcia(t/n): ");
                            zwierze_tn = Console.ReadLine();
                        } while (zwierze_tn != "t" && zwierze_tn != "n");
                        zwierze = 0;
                        if (zwierze_tn == "t")
                            zwierze = 1;
                        Console.Clear();

                        zwierze_cena = 0;
                        if (zwierze == 1)
                        {
                            do
                            {
                                czy_dziala = true;
                                try
                                {
                                    Console.WriteLine("Podaj cene zwierza: ");
                                    zwierze_cena = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                }
                                catch
                                {
                                    czy_dziala = false;
                                    Console.Clear();
                                }
                            } while (!czy_dziala);
                        }
                        do
                        {
                            czy_dziala = true;
                            try
                            {
                                Console.WriteLine("Podaj cene dziecka: ");
                                dziecko_cena = int.Parse(Console.ReadLine());
                                Console.Clear();
                            }
                            catch
                            {
                                czy_dziala = false;
                                Console.Clear();
                            }
                        } while (!czy_dziala);
                        do
                        {
                            czy_dziala = true;
                            try
                            {
                                Console.WriteLine("Podaj cene dorosłego: ");
                                dorosly_cena = int.Parse(Console.ReadLine());
                                Console.Clear();
                            }
                            catch
                            {
                                czy_dziala = false;
                                Console.Clear();
                            }
                        } while (!czy_dziala);
                        do
                        {
                            czy_dziala = true;
                            try
                            {
                                Console.WriteLine("Podaj cene podstawowej polisy: ");
                                polisy_cena = double.Parse(Console.ReadLine());
                                Console.Clear();
                            }
                            catch
                            {
                                czy_dziala = false;
                                Console.Clear();
                            }
                        } while (!czy_dziala);
                        do
                        {
                            czy_dziala = true;
                            try
                            {
                                Console.WriteLine("Podaj cene premium polisy: ");
                                polisy_premium_cena = double.Parse(Console.ReadLine());
                                Console.Clear();
                            }
                            catch
                            {
                                czy_dziala = false;
                                Console.Clear();
                            }
                        } while (!czy_dziala);

                        //Zapisanie wycieczki do bazy danych
                        MySqlzap.create_wycieczki(osoby, miejsce_zbiorki, rodzaj_transportu, dokad, od_kiedy, do_kiedy, zwierze, zwierze_cena, dziecko_cena, dorosly_cena, polisy_cena, polisy_premium_cena);
                        Console.WriteLine("Dodałeś wycieczkę do " + dokad + ", o terminie: " + od_kiedy + " oraz cenie " + dorosly_cena + " zł. Ilość uczestników wycieczki wynosi: " + osoby + ".");

                        Console.WriteLine("Wciśnij ENTER, aby kontynuować.");
                        Console.ReadKey(true);
                        Console.Clear();

                    }
                    else if (wycieczki == 3)
                    {
                        //usuwanie wycieczki
                        Console.Clear();

                        Console.WriteLine("Wybierz wycieczkę, którą chcesz usunąć: ");
                        MySqlzap.pobierz_all_wycieczki();
                        Console.WriteLine("Jeśli chcesz wrócić kliknij (0)");
                        do
                        {
                            czy_dziala = true;
                            try
                            {
                                if (int.Parse(Console.ReadLine()) == 0)
                                {
                                    Console.Clear();
                                    goto menu;
                                }
                            }
                            catch
                            {
                                czy_dziala = false;
                            }
                        } while (!czy_dziala);

                        //tutaj rozwija się lista wszystkich wycieczek

                        //usunięcie danej wycieczki
                        MySqlzap.delate("wycieczki", Console.ReadLine());
                        Console.WriteLine("Wciśnij ENTER, aby kontynuować.");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else if (wycieczki == 4)
                    {
                        //wyjście

                        zarzadzanie = false;
                    }
                    else
                    {

                        //wybranie niepoprawnej opcji
                        Console.Clear();
                        Console.WriteLine("Wybrałeś niepoprawną opcję. Wybierz ponownie opcję logowania: ");
                    };
                };
            };
        }
    }
}