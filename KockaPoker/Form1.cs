using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KockaPoker.SajatOsztalyok;

namespace KockaPoker
{
    public partial class Form1 : Form
    {
        Leosztas l = new Leosztas();
        Jatekos j = new Jatekos("Szerencsés Pista");

        public Form1()
        {
            InitializeComponent();
            pbElsoJatekos1.Image = Properties.Resources.kek1;
            pbElsoJatekos2.Image = Properties.Resources.kek2;
            pbElsoJatekos3.Image = Properties.Resources.kek3;
            pbElsoJatekos4.Image = Properties.Resources.kek4;
            pbElsoJatekos5.Image = Properties.Resources.kek5;
        }

        private void btnKilepes_Click(object sender, EventArgs e)
        {
            MessageBox.Show(j.ToString());
            Application.Exit();
        }
    }
}
