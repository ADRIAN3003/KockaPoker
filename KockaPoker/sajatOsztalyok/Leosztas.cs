using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockaPoker.SajatOsztalyok
{
    class Leosztas
    {
        List<int> kockak = new List<int>();

        public Leosztas()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < 5; i++)
            {
                kockak.Add(rnd.Next(1, 6));
            }
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
    }
}
