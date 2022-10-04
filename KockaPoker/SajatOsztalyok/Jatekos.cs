using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockaPoker.SajatOsztalyok
{
    class Jatekos
    {
        private string nev;

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        private Leosztas leosztas;

        public Leosztas Kockak
        {
            get { return leosztas = new Leosztas(); }
        }

        public override string ToString()
        {
            return $"{Nev} - {Kockak.ToString()}";
        }

        public Jatekos(string nev)
        {
            Nev = nev;
        }
    }
}
