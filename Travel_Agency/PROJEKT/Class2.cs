using System;
using System.Collections.Generic;
using System.Text;

namespace projektumg
{
    class Class2
    {
        public char linia = '│';
        public char linial = '┤';
        public char liniap = '├';
        public char t = '┬';
        public char odwrocone_t = '┴';
        public char rog_lg = '┌';
        public char rog_pg = '┐';
        public char rog_ld = '└';
        public char rog_pd = '┘';
        public char poziome = '─';
        public char krzyz = '┼';
        public char liniax2 = '║';
        public char linialx2 = '╣';
        public char liniapx2 = '╠';
        public char tx2 = '╦';
        public char odwrocone_tx2 = '╩';
        public char rog_lgx2 = '╔';
        public char rog_pgx2 = '╗';
        public char rog_ldx2 = '╚';
        public char rog_pdx2 = '╝';
        public char poziomex2 = '═';
        public char krzyzx2 = '╬';

        public void tabelka_gora(int dlugosc = 37)
        {
            Console.Write(rog_lgx2);
            for (int i = 0; i < dlugosc - 2; i++)
            {
                Console.Write(poziomex2);
            }
            Console.Write(rog_pgx2);
            Console.WriteLine();
        }
        public void tabelka_dol(int dlugosc = 37)
        {
            Console.Write(rog_ldx2);
            for (int i = 0; i < dlugosc - 2; i++)
            {
                Console.Write(poziomex2);
            }
            Console.Write(rog_pdx2);
            Console.WriteLine();
        }
        public void tabelka_srodek(string napis, int dlugosc = 37)
        {
            Console.Write(liniapx2);
            for (int i = 0; i < 8; i++)
            {
                Console.Write(poziomex2);
            }
            Console.Write(" ");
            Console.Write(napis);
            Console.Write(" ");
            for (int i = 12; i < (dlugosc - napis.Length); i++)
            {
                Console.Write(poziomex2);
            }
            Console.Write(linialx2);
            Console.WriteLine();
        }
        public void automat(string[] napis)
        {
            int lenght = 0;
            for (int i = 0; i < 100; i++)
            {
                Console.Write(poziomex2);
            }
            Console.WriteLine();

            foreach (string a in napis)
            {
                lenght += (a.Length + 4);
                if (lenght > 101)
                {
                    lenght = a.Length + 4;
                    Console.Write(liniax2);
                    Console.WriteLine();
                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write(poziome);
                    }
                    Console.WriteLine();
                }
                Console.Write(liniax2);
                Console.Write(" ");
                Console.Write(a);
                Console.Write(" ");

            }
            Console.Write(liniax2);
            Console.WriteLine();
            for (int i = 0; i < 100; i++)
            {
                Console.Write(poziomex2);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}