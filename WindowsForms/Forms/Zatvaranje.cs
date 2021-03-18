using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.Forms
{
    public partial class Zatvaranje : Form
    {
        public Zatvaranje()
        {
            InitializeComponent();
        }


        private void Zatvaranje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Application.Exit();
            }
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
