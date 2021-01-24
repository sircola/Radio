using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Radio
{    
    struct Szam {
        public int radio;
        public int perc;
        public int masodperc;
        public string eloado;
        public string cim;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Szam> szamok = new List<Szam>();
            StreamReader sr = new StreamReader("zenek.txt");

            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] kettospont = sr.ReadLine().Split(':');
                // for (int i = 0; i < kettospont.Length; i++) Console.WriteLine($"{i}: {kettospont[i]}");

                string[] reszek = kettospont[0].Split(' ');
                // for (int i = 0; i < reszek.Length; i++) Console.WriteLine($"{i}: {reszek[i]}");

                Szam szam = new Szam();

                szam.radio = int.Parse(reszek[0]);
                szam.perc = int.Parse(reszek[1]);
                szam.masodperc = int.Parse(reszek[2]);

                szam.eloado = "";
                for (int i = 3; i < reszek.Length; i++)
                {
                    if (i > 3) szam.eloado += " ";
                    szam.eloado += reszek[i];
                }

                reszek = kettospont[1].Split(' ');
                szam.cim = "";
                for (int i = 0; i < reszek.Length; i++)
                {
                    if (i > 0) szam.cim += " ";
                    szam.cim += reszek[i];
                }

                szamok.Add(szam);
            }
            sr.Close();
            // for (int i = 0; i < szamok.Count; i++) Console.WriteLine($"{i}:\n{szamok[i].radio}\n{szamok[i].perc}:{szamok[i].masodperc}\n{szamok[i].eloado}\n{szamok[i].cim}");

            Console.WriteLine("1. feladat");
            List<string> clapton = new List<string>();
            for (int i = 0; i < szamok.Count; i++)
                if (szamok[i].eloado == "Eric Clapton")
                {
                    bool voltmar = false;
                    foreach (string s in clapton)
                        if (s == szamok[i].cim)
                            voltmar = true;
                    if (voltmar == false)
                        clapton.Add(szamok[i].cim);
                }
            // foreach (string s in clapton) Console.WriteLine(s);
            Console.WriteLine($"{clapton.Count} darab Eric Clapton szam van.");

            Console.WriteLine("2. feladat");
            int[] idok = new int[3];

            for (int i = 0; i < szamok.Count; i++)
                idok[szamok[i].radio - 1] += szamok[i].perc * 60 + szamok[i].masodperc;

            for(int i=0; i<3; i++)
                Console.WriteLine($"{i+1}. radio musorideje: {idok[i]/3600,0:D2}:{(idok[i] % 3600)/60,1:D2}:{idok[i]% 60,2:D2}");

            Console.WriteLine("3. feladat");
            int mennyi = 0;
            foreach(Szam s in szamok)
                foreach (Szam i in szamok)
                    if (s.cim == i.cim && s.eloado == i.eloado && s.radio != i.radio)
                        ++mennyi;
            Console.WriteLine(mennyi > 1 ? "vannak" : mennyi == 1 ? "van" : "nincs");

            Console.WriteLine("nyomjon egy billentyut...");
            Console.ReadKey(true);
        }
    }
}