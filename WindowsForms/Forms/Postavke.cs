using DAL;
using WindowsForms.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Postavke : Form
    {
        public static string jezik;

        private Form parent;

        public Postavke(Form parent)
        {
            this.parent = parent;
            string jezik = Repo.ReadJezik();
            string prvenstvo = Repo.ReadPrventsvo();
           
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(jezik);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(jezik);
            InitializeComponent();
            IspuniPredefinirane(jezik, prvenstvo);
        }

        private void IspuniPredefinirane(string jezik, string prvenstvo)
        {
            if (jezik == "en") gbJezik.Controls[0].Select();
            else if (jezik == "hr") gbJezik.Controls[1].Select();

            if (prvenstvo == "z") gbPrvenstvo.Controls[0].Select();
            else if (prvenstvo == "m") gbPrvenstvo.Controls[1].Select();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Odabrani jezik
            var button = gbJezik.Controls.OfType<RadioButton>()
                            .FirstOrDefault(n => n.Checked);
            string kultura = "";
            if (button.Name == "rbHrv")
            {
                kultura = "hr";
            }
            else kultura = "en";

            //Odabrano prvenstvo
            var button2 = gbPrvenstvo.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked);
            string prvenstvo2 = "";
            if (button2.Name == "rbMen")
            {
                prvenstvo2 = "m";
            }
            else prvenstvo2 = "z";

            Repo.WriteJezik(kultura);
            Repo.WritePrvenstvo(prvenstvo2);

            (parent as Ekran1).promjeniJezik(kultura, 1);

            this.Close();
       
        }

    }
}
