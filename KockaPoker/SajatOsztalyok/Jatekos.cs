using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KockaPoker.SajatOsztalyok
{
    class Jatekos
    {
        List<PictureBox> kockaKepek = new List<PictureBox>();

        private string nev;

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        private Leosztas leosztas = new Leosztas();

        public Leosztas Kockak
        {
            get { return leosztas; }
        }

        public override string ToString()
        {
            return $"{Nev} - {Kockak.ToString()}";
        }

        public Jatekos(string nev, List<PictureBox> kockaKepek)
        {
            Nev = nev;
            this.kockaKepek = kockaKepek;
        }

        public void UjLeosztas()
        {
            leosztas.UjLeosztas();
        }

        public void KepekBeallitasa()
        {
            foreach (var k in kockaKepek)
            {
                //k.Image = KepValaszt();
            }
        }
    }
}
