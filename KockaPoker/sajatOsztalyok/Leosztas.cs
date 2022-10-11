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

            kockak.Sort();
            Dictionary<int, int> stat = Statisztika(kockak);
            string eredmeny = "";

            if (stat.Count == 1)
            {
                eredmeny = "Nagypóker";
            }
            else if (stat.Count == 5)
            {
                eredmeny = KissorNagysorSemmi(stat);
            }
            else if (stat.Count == 2)
            {
                eredmeny = PokerFull(stat);
            }
            else if (stat.Count == 3)
            {
                eredmeny = Drill2Par(stat);
            }
            else
            {
                eredmeny = $"{stat.OrderByDescending(x => x.Value).First().Key} Pár";
            }

            return eredmeny;
        }

        private static string Drill2Par(Dictionary<int, int> stat)
        {
            string eredmeny;
            if (stat.ContainsValue(3))
                eredmeny = $"{stat.OrderByDescending(x => x.Value).First().Key} Drill";
            else
            {
                List<int> parok = new List<int>();

                foreach (var s in stat)
                {
                    if (s.Value == 2)
                    {
                        parok.Add(s.Key);
                    }
                }

                eredmeny = $"{parok.Max()} - {parok.Min()} Pár";
            }
            return eredmeny;
        }

        private static string PokerFull(Dictionary<int, int> stat)
        {
            string eredmeny;
            if (stat.ContainsValue(4))
                eredmeny = $"{stat.OrderByDescending(x => x.Value).First().Key} Póker";
            else
                eredmeny = $"{stat.OrderByDescending(x => x.Value).First().Key} - {stat.OrderBy(x => x.Value).First().Key} Full";
            return eredmeny;
        }

        private static string KissorNagysorSemmi(Dictionary<int, int> stat)
        {
            string eredmeny;
            if (!stat.ContainsKey(1))
                eredmeny = "Nagysor";
            else if (!stat.ContainsKey(6))
                eredmeny = "Kissor";
            else
                eredmeny = "Semmi";
            return eredmeny;
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
