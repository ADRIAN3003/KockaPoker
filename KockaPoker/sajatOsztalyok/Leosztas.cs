using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockaPoker.SajatOsztalyok
{
    public class Leosztas
    {
        List<int> kockak = new List<int>();

        public void UjLeosztas()
        {
            kockak = Keveres();
        }

        public Leosztas()
        {
            kockak = Keveres();
        }

        private List<int> Keveres()
        {
            List<int> k = new List<int>();
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 5; i++)
            {
                k.Add(rnd.Next(1, 7));
            }
            return k;
        }

        public override string ToString()
        {
            StringBuilder tmp = new StringBuilder();
            foreach (var k in kockak)
            {
                tmp.Append($"{k} ");
            }

            return tmp.ToString();
        }

        public int MilyenErtek(int hanyadikKocka)
        {
            return kockak[hanyadikKocka];
        }
        public void LeosztasBeallitasa(List<int> kockak)
        {
            this.kockak = kockak;
        }

        public string LeosztasErteke()
        {

            /*kockak.Sort();
            if (kockak[0] == kockak[1] && kockak[1] == kockak[2] && kockak[2] == kockak[3] && kockak[3] == kockak[4])
            {
                return $"{kockak[0]} Nagy Póker";
            }
            else if (kockak[0] == 1 && kockak[1] == 2 && kockak[2] == 3 && kockak[3] == 4 && kockak[4] == 5)
            {
                return $"Kissor";
            }
            else if (kockak[0] == 2 && kockak[1] == 3 && kockak[2] == 4 && kockak[3] == 5 && kockak[4] == 6)
            {
                return $"Nagysor";
            }
            else if (kockak[0] == kockak[1] && kockak[1] == kockak[2] && kockak[2] == kockak[3])
            {
                return $"{kockak[0]} Póker";
            }
            else if (kockak[1] == kockak[2] && kockak[2] == kockak[3] && kockak[3] == kockak[4])
            {
                return $"{kockak[1]} Póker";
            }
            else if (kockak[0] == kockak[1] && kockak[2] == kockak[3] && kockak[3] == kockak[4])
            {
                return $"{kockak[2]} - {kockak[0]} Full";
            }
            else if (kockak[0] == kockak[1] && kockak[1] == kockak[2] && kockak[3] == kockak[4])
            {
                return $"{kockak[0]} - {kockak[3]} Full";
            }*/

            Dictionary<int, int> stat = Statisztika(kockak);

            if (stat.Count == 1)
            {
                return $"Nagypóker";
            }

            return "Semmi";
        }

        private Dictionary<int, int> Statisztika(List<int> kockak)
        {
            Dictionary<int, int> tmp = new Dictionary<int, int>();
            foreach (var k in kockak)
            {
                if (tmp.ContainsKey(k))
                {
                    tmp[k]++;
                }
                else
                {
                    tmp.Add(k, 1);
                }
            }

            return tmp;
        }
    }
}
