using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Radio
{    
    class Program
    {
        class Szam
        {
            public int radio;
            public int perc;
            public int masodperc;
            public string eloado;
            public string cim;
        }

        static void Main(string[] args)
        {
            List<Szam> szamok = new List<Szam>();
            StreamReader sr = new StreamReader("zenek.txt");

            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] kettospont = sr.ReadLine().Split(':');
                string[] reszek = kettospont[0].Split(' ');

                Szam szam = new Szam();

                szam.radio = int.Parse(reszek[0]);
                szam.perc = int.Parse(reszek[1]);
                szam.masodperc = int.Parse(reszek[2]);

                szam.eloado = "";
                for (int i = 3; i < reszek.Length; i++)
                    szam.eloado += reszek[i] + " ";
                szam.eloado = szam.eloado.Trim();

                reszek = kettospont[1].Split(' ');
                szam.cim = "";
                foreach( string s in reszek )
                    szam.cim += s + " ";
                szam.cim = szam.cim.Trim();

                szamok.Add(szam);
            }
            sr.Close();

            Console.WriteLine("1. feladat");
            List<string> clapton = new List<string>();
            foreach( Szam szam in szamok )
                if (szam.eloado == "Eric Clapton")
                {
                    bool voltmar = false;
                    foreach (string s in clapton)
                        if (s == szam.cim)
                            voltmar = true;
                    if (voltmar == false)
                        clapton.Add(szam.cim);
                }
            Console.WriteLine($"{clapton.Count} darab Eric Clapton szam van.");

            Console.WriteLine("2. feladat");
            int[] idok = { 0, 0, 0 };

            foreach (Szam szam in szamok)
                idok[szam.radio - 1] += szam.perc * 60 + szam.masodperc;

            for(int i=0; i<3; i++)
                Console.WriteLine($"{i+1}. radio musorideje: {idok[i]/3600,0:D2}:{(idok[i] % 3600)/60,1:D2}:{idok[i]% 60,2:D2}");

            Console.WriteLine("3. feladat");
            int mennyi = 0;
            foreach(Szam szam in szamok)
                foreach (Szam s in szamok)
                    if (szam.cim == s.cim && szam.eloado == s.eloado && szam.radio != s.radio)
                        ++mennyi;
            Console.WriteLine(mennyi > 1 ? "vannak" : mennyi == 1 ? "van" : "nincs");

            Console.WriteLine("nyomjon egy billentyut...");
            Console.ReadKey(true);
        }
    }
}