using System;
using System.Collections.Generic;

namespace GrafFeladat_CSharp
{
    class Graf
    {
        int csucsokSzama;

        readonly List<El> elek = new List<El>();
        readonly List<Csucs> csucsok = new List<Csucs>();


        public Graf(int csucsok)
        {
            this.csucsokSzama = csucsok;


            for (int i = 0; i < csucsok; i++)
            {
                this.csucsok.Add(new Csucs(i));
            }
        }

        public void Hozzaad(int cs1, int cs2)
        {
            if (cs1 < 0 || cs1 >= csucsokSzama ||
                cs2 < 0 || cs2 >= csucsokSzama)
            {
                throw new ArgumentOutOfRangeException("A csucs indexe hibás");
            }
            foreach (var el in elek)
            {
                if (el.Csucs1 == cs1 && el.Csucs2 == cs2)
                {
                    return;
                }
            }
            elek.Add(new El(cs1, cs2));
            elek.Add(new El(cs2, cs1));
        }

        public void SzelessegiBejar(int kezdopont)
        {
            List<int> bejart = new List<int>();
            List<int> kovetkezok = new List<int>();

            kovetkezok.Add(kezdopont);
            bejart.Add(kezdopont);
            while (kovetkezok.Count != 0)
            {
                kezdopont = kovetkezok[0];
                kovetkezok.RemoveAt(0);

                Console.WriteLine(this.csucsok[kezdopont]);
                foreach (var el in this.elek)
                {
                    if (el.Csucs1 == kezdopont && !bejart.Contains(el.Csucs2))
                    {
                        kovetkezok.Add(el.Csucs2);
                        bejart.Add(el.Csucs2);
                    }
                }
            }
        }

        public void MelysegiBejar(int kezdopont)
        {
            List<int> bejart = new List<int>();

            bejart.Add(kezdopont);
            this.MelysegiBejarRekurziv(kezdopont, bejart);
        }

        public void MelysegiBejarRekurziv(int kezdopont, List<int> bejart)
        {
            Console.WriteLine(this.csucsok[kezdopont]);
            foreach (var el in this.elek)
            {
                if (el.Csucs1 == kezdopont && !bejart.Contains(el.Csucs2))
                {
                    bejart.Add(el.Csucs2);
                    this.MelysegiBejarRekurziv(el.Csucs2, bejart);
                }
            }
        }

        public bool Osszefuggo()
        {
            List<int> bejart = new List<int>();
            List<int> kovetkezok = new List<int>();

            kovetkezok.Add(0);
            bejart.Add(0);
            int k;
            while (kovetkezok.Count != 0)
            {
                k = kovetkezok[0];
                kovetkezok.RemoveAt(0);

                foreach (var el in this.elek)
                {
                    if (el.Csucs1 == k && !bejart.Contains(el.Csucs2))
                    {
                        kovetkezok.Add(el.Csucs2);
                        bejart.Add(el.Csucs2);
                    }
                }
            }
            return (bejart.Count == this.csucsokSzama ? true : false);
        }

        public override string ToString()
        {
            string str = "Csucsok:\n";
            foreach (var cs in csucsok)
            {
                str += "     " + cs + "\n";
            }
            str += "\nElek:\n";

            foreach (var el in elek)
            {
                str += "   " + el + "\n";
            }
            return str;
        }
    }
}