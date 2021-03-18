using DAL;
using WindowsForms.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gbJezik.Controls[1].Select();
        }
       
        
        //MUSKO
        private void button1_Click(object sender, EventArgs e)
        {
            PrikaziGlavniEkran("m");
        }

        //ZENSKO
        private void button2_Click(object sender, EventArgs e)
        {
            PrikaziGlavniEkran("z");
        }

        private void PrikaziGlavniEkran(string prventsvo)
        {
            var button = gbJezik.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked);
            string kultura = "";
            if (button.Name == "rbHr")
            {
                kultura = "hr";
            }
            else kultura = "en";

            Repo.WriteJezik(kultura);
            Repo.WritePrvenstvo(prventsvo);
            Ekran1 rsp = new Ekran1("nemaOmiljeneRep");
            rsp.Show();
        }

    }
}
