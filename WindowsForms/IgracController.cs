using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Models;

namespace WindowsForms
{
    public partial class IgracController : UserControl
    {
        public Player igrac;
        //public PictureBox pb = null;
        public IgracController()
        {
            InitializeComponent();
            //pb = pbZvjezdica;

        }

        public IgracController(Player player)
        {
            InitializeComponent();
            igrac = player;
            lblIme.Text = player.Name;
            lblBroj.Text = player.ShirtNumber.ToString();
            lblPozicija.Text = player.Position;
            lblKapetan.Text = player.Captain.ToString();
            if (lblKapetan.Text == "True" || lblKapetan.Text == "Da")
            {
                BackColor = Color.Gold;
            }
            igrac = player;
        }

        public  void UcitajSliku(string picturePath)
        {
            pbPlayer.Image = Image.FromFile(picturePath);
        }

        public override string ToString()
        {
            return igrac.Name;
        }

        public void PostaviVrijednost(string opis)
        {
            lblPlus.Text = opis;
            lblPlus.Visible = true;
            
        }

        public void imaZvijezdu(bool ima)
        {
            if(ima)
            {
                pbZvjezdica.Image = Properties.Resources.MyStar;
                //pbZvjezdica.ImageLocation = @"C:\Users\ER\Desktop\FAKS\4.SEMESTAR\PROJEKTI\OOP\ProjektOOPErikaRaguž\WindowsForms\Resources\MyStar.png";
            } else
            {
                pbZvjezdica.Image = null;
            }
        }


        public event EventHandler PrebaciOmiljenogIgraca;
        public class PrebaciOmiljenogIgračaArgs : EventArgs
        {
            public PictureBox pb { get; set; }
        }
        private void OnSelected(object sender, EventArgs e)
        {
            PrebaciOmiljenogIgraca?.Invoke(this, new PrebaciOmiljenogIgračaArgs { pb = pbZvjezdica });
           
        }

        public event EventHandler UrediSlikuIgrača;
        public class UrediSlikuIgračaArgs : EventArgs
        {
            public PictureBox pb { get; set; }
        }
        private void OnUrediSliku(object sender, EventArgs e)
        {
            UrediSlikuIgrača?.Invoke(this, new UrediSlikuIgračaArgs { pb = pbPlayer });
        }

        public event EventHandler VratiIgraca;
        public class VratiIgraIgracaArgs : EventArgs
        {
            public PictureBox pb { get; set; }
        }
        private void OnUnselected(object sender, EventArgs e)
        {
            VratiIgraca?.Invoke(this, new VratiIgraIgracaArgs { pb = pbZvjezdica});
        }

       
        public event EventHandler KlikMisa;
        public class KlikMisaArgs : EventArgs
        {
            public MouseButtons button{ get; set; }
            public PictureBox pb{ get; set; }
        }
       
        private void onMouseDown(object sender, MouseEventArgs e)
        {
            KlikMisa?.Invoke(this, new KlikMisaArgs { button = e.Button, pb=pbZvjezdica });
        }
    }
}
