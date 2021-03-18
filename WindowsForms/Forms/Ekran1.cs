using DAL;
using DAL.Models;
using Newtonsoft.Json;
using WindowsForms.Models;
using WindowsForms.Properties;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Windows.Forms;

namespace WindowsForms.Forms
{
    public partial class Ekran1 : Form
    {
        private PrintDocument printDocument;
        
        private Reprezentacija rep = null; //odabrana reprezentacija
        private List<Reprezentacija> reprezentacije;
        private List<Utakmica> utakmice = new List<Utakmica>();
        private List<Player> igraci = new List<Player>();

        public static string jezik = Repo.ReadJezik();
        public static string prvenstvo = Repo.ReadPrventsvo();
        DataTable dt = new DataTable();

        public Ekran1()
        {
            promjeniJezik(jezik ?? "en");
            NapuniPodatkeUListu(prvenstvo);
            SetupPrintDocument();
            string fifaCode = Repo.ReadOmiljenaRep();

            if (fifaCode != "" && fifaCode != null)
            {
                cbDrzave.Text = fifaCode;
                DohvatiUtakmice(fifaCode);
                NapuniPodatkeTablice();
            }
        }

        public Ekran1(string nemaOmiljeneRep)
        {
            promjeniJezik(jezik ?? "en");
            NapuniPodatkeUListu(prvenstvo);
            SetupPrintDocument();
        }


        public void promjeniJezik(string kultura, int postavke = 0)
        {
            if (postavke == 1)
            {
                Repo.WriteOmiljenaRep("");
            }
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(kultura);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(kultura);
            jezik = kultura;
            this.Controls.Clear();
            InitializeComponent();
            prvenstvo = Repo.ReadPrventsvo();
            NapuniPodatkeUListu(prvenstvo);
            dt.Clear();
            NapuniPodatkeTablice();
           
        }


        private void SetupPrintDocument()
        {
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest,
        int nXDest, int nYDest, int nWidth, int nHeight,
        IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
          
            memoryImage = ControlPrinter.ScrollableControlToBitmap(this, true, true);

            Graphics memoryGraphics = Graphics.FromImage(
                memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width,
                this.ClientRectangle.Height, dc1, 0, 0,
                13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
 
        private void btnPrint_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();

        }
        private async void NapuniPodatkeUListu(string prvenstvo)
        {
            try
            {
                var podatci = await Repo.GetPodatci(prvenstvo);
                reprezentacije = podatci;
                reprezentacije.Sort((x, y) => string.Compare(x.Country, y.Country));

                label2.Text = "";

                cbDrzave.Items.Clear();
                foreach (var item in podatci)
                {
                    cbDrzave.Items.Add($"{item.Country} ({item.FifaCode})");
                }

                label2.ForeColor = Color.Black;
                if (jezik == "en")
                {
                    infoLbl.Text = "Representations loaded";
                }
                if (Thread.CurrentThread.CurrentCulture.Name == "hr")
                {
                    infoLbl.Text = "Reprezentacije učitane";
                }
            }
            catch
            {
                MessageBox.Show("Dohvaćanje podataka nije uspjelo");
            }
        }
        //event koji se poziva odabirom reprezentacije
        private void OdabranaReprezentacija(object sender, EventArgs e)
        {
            rep = reprezentacije[cbDrzave.SelectedIndex];
            DohvatiUtakmice(rep.FifaCode); //prvo dohvati utakmice, da mozes i igrace
            NapuniPodatkeTablice();
        }
       
        private async void DohvatiUtakmice(string FifaCode)
        {
            string p = Repo.ReadPrventsvo();
            var podatci = await Repo.DohvatiUtakmice(FifaCode, p);
            utakmice = podatci;
            DohvatiIgrace(utakmice, FifaCode);
        }

        private async void DohvatiIgrace(List<Utakmica> utakmice, string fifaCode)
        {
            List<Player> players = await Repo.DohvatiIgrace(utakmice, fifaCode);
            igraci = players;
           
            PrikaziIgrace(igraci); //prikaze igrace u kontroli
        }

        private void PrikaziIgrace(List<Player> igraci)
        {
            String searchFolder = Repo.folderPath;
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            var files = Repo.GetFilesFrom(searchFolder, filters);

            flp1.Controls.Clear();
            flp2.Controls.Clear();
            flp2.Controls.Add(lblOmiljen);
            flp1.AutoSize = false;
            flp2.AutoSize = false;


            if (jezik == "en")
            {
                lblOmiljen.Text = "Favourite players:";
            }
            else lblOmiljen.Text = "Omiljeni igrači:";

            InitDnD(); //omoguci DnD
            List<Player> omiljeniIgraci = Repo.ReadOmiljeniIgraci();

            foreach (Player p in igraci)
            {
                IgracController igrac = new IgracController(p);
                igrac.Width = flp1.Width-50;
                foreach (var item in files)
                {
                    string ime = item.Substring(item.LastIndexOf(("\\")) + 1);
                    if (ime.Equals("Slike"+ igrac.ToString() + ".jpg"))
                    {
                        igrac.UcitajSliku(item);
                    }
                }
               
                igrac.KlikMisa += Igrac_KlikMisa;
                igrac.PrebaciOmiljenogIgraca += Igrac_PrebaciOmiljenogIgraca;
                igrac.UrediSlikuIgrača += Igrac_UrediSlikuIgraca;
                igrac.VratiIgraca += Igrac_VratiIgraca;

                Player postoji = omiljeniIgraci.Find(ig => ig.Name == igrac.igrac.Name);

                if (postoji != null)
                {
                    igrac.imaZvijezdu(true);
                    flp2.Controls.Add(igrac);
                } else
                {
                    flp1.Controls.Add(igrac);
                }

            }
            if (jezik == "en")
            {
                infoLbl.Text = "Data is shown";
            }
            else infoLbl.Text = "Podatci prikazani";
        }

        //lijevi klik(DnD) ili desni(Context Menu Strip)
        private void Igrac_KlikMisa(object sender, EventArgs e)
        {
            IgracController igrac = sender as IgracController;
            IgracController.KlikMisaArgs args = (IgracController.KlikMisaArgs)e;
            switch (args.button)
            {
                //maksimalno 3 igraca na flp2 = sveukupno moguce 4 kontrole (3 igraca + lbl)
                case MouseButtons.Left:
                    if (flp2.Controls.Count == 3 + 1 && flp1.Controls.Contains(igrac))
                    {
                        if (jezik == "hr") MessageBox.Show("Moguće je dodati maksimalno 3 omiljena igrača");
                        if (jezik == "en") MessageBox.Show("You can choose maximum 3 favourite players");
                        return;
                    }
                    igrac.DoDragDrop(igrac, DragDropEffects.Move);
                    //args.pb.ImageLocation = @"C:\Users\ER\Desktop\FAKS\4.SEMESTAR\PROJEKTI\OOP\ProjektOOPErikaRaguž\WindowsForms\Resources\MyStar.png";
                    break;
                case MouseButtons.Right:
                    if (flp1.Controls.Contains(igrac))
                    {
                        igrac.ContextMenuStrip.Items[1].Available = false;
                    }
                    else
                    {
                        igrac.ContextMenuStrip.Items[0].Available = false;
                        igrac.ContextMenuStrip.Items[1].Available = true;
                    }
                    break;
            }
        }

        private void InitDnD()
        {
            flp1.AllowDrop = true;
            flp1.DragEnter += Flp1_DragEnter;
            flp1.DragDrop += Flp1_DragDrop;

            flp2.AllowDrop = true;
            flp2.DragEnter += Flp2_DragEnter;
            flp2.DragDrop += Flp2_DragDrop;
        }
        //Dnd
        private void Flp2_DragDrop(object sender, DragEventArgs e)
        {
            IgracController kontrolerIgrac = (IgracController)e.Data.GetData(typeof(IgracController));
            kontrolerIgrac.imaZvijezdu(true);
            kontrolerIgrac.Width = flp2.Width - 50;
            flp2.Controls.Add(kontrolerIgrac);
        }

        private void Flp2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Flp1_DragDrop(object sender, DragEventArgs e)
        {
            IgracController kontrolerIgrac = (IgracController)e.Data.GetData(typeof(IgracController));
            kontrolerIgrac.imaZvijezdu(false);
            flp1.Controls.Add(kontrolerIgrac);
        }

        private void Flp1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        //Dnd

        //cms
        private void Igrac_PrebaciOmiljenogIgraca(object sender, EventArgs e)
        {
            if (flp2.Controls.Count == 3 + 1)
            {
                if (jezik == "hr") MessageBox.Show("Moguće je dodati maksimalno 3 omiljena igrača");
                if (jezik == "en") MessageBox.Show("You can choose maximum 3 favourite players");
                return;
            }
            IgracController igrac = sender as IgracController;
            igrac.imaZvijezdu(true);     
            flp1.Controls.Remove(igrac);
            flp2.Controls.Add(igrac);
    
        }
        private void Igrac_UrediSlikuIgraca(object sender, EventArgs e)
        {
            IgracController igrac = sender as IgracController;
            IgracController.UrediSlikuIgračaArgs args = (IgracController.UrediSlikuIgračaArgs)e;
            PictureBox pb1 = args.pb;
       
            OpenFileDialog open = new OpenFileDialog(); 
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Repo.slikeFolder;
                string iName = igrac.ToString();
                string filepath = open.FileName;
                File.Copy(filepath, folderPath + iName + ".jpg");
                pb1.Image = new Bitmap(open.FileName);
            }

        }

        private void Igrac_VratiIgraca(object sender, EventArgs e)
        {
            IgracController igrac = sender as IgracController;
            igrac.imaZvijezdu(false);
            flp2.Controls.Remove(igrac);
            flp1.Controls.Add(igrac);
        }
        //cms

        //Rang po golovima
        private void btnGolovi_Click(object sender, EventArgs e)
        {
            if (rep == null && cbDrzave.Text == "")
            {
                if (jezik == "hr") MessageBox.Show("Niste odabrali omiljenu reprezentaciju");
                if (jezik == "en") MessageBox.Show("You didn't choose favourite representation");
                return;
            }
            Form rangGolovi = new RangGolovi();
            rangGolovi.Show();
        }

        //Rang po zutim kartonima
        private void btnZutiKartoni_Click(object sender, EventArgs e)
        {
            if (rep == null && cbDrzave.Text == "")
            {
                if (jezik == "hr") MessageBox.Show("Niste odabrali omiljenu reprezentaciju");
                if (jezik == "en") MessageBox.Show("You didn't choose favourite representation");
                return;
            }
            Form rangZutiKartoni = new RangZutiKartoni();
            rangZutiKartoni.Show();
        }

        private async void NapuniPodatkeTablice()
        {
            
            if (jezik == "hr") infoLbl.Text = "Dohvaćanje podataka";
            else infoLbl.Text = "Reaching data";

            while (dt.Columns.Count != 0)
            {
                dt.Columns.RemoveAt(dt.Columns.Count - 1);
            }
            while (dt.Rows.Count != 0)
            {
                dt.Rows.RemoveAt(dt.Rows.Count - 1);
            }

            if (jezik == "hr")
            {
                dt.Columns.AddRange(
               new DataColumn[4]
               { new DataColumn("Lokacija", typeof(string)),
                  new DataColumn ("Broj posjetitelja", typeof(string)),
                  new DataColumn("Domaći tim", typeof(string)),
                  new DataColumn("Gostujući tim", typeof(string))
               });

            }
            else
            {
               dt.Columns.AddRange(
               new DataColumn[4]
              { new DataColumn("Location", typeof(string)),
                  new DataColumn ("Number of visitors", typeof(string)),
                  new DataColumn("Home team", typeof(string)),
                  new DataColumn("Away team", typeof(string))
              });
            }

            grv.DataSource = dt;

            
            if (cbDrzave.Text == "" || cbDrzave.Text == null)
            {
                return;
            }

            List<InfoZaUtakmice> informacije = null;
            if (rep != null)
            {
               informacije = await Repo.DohvatiInfoZaUtakmice(rep.FifaCode, prvenstvo);
            }
            else
            {
               informacije = await Repo.DohvatiInfoZaUtakmice(cbDrzave.Text, prvenstvo);
            }
           
            if(informacije == null)
            {
                if (jezik == "hr") MessageBox.Show("Dohvaćanje podataka nije uspjelo");
                else MessageBox.Show("Data loading failed");
                return;
            }


            List<InfoZaUtakmice> sortedInformacije = informacije.OrderBy(i => i.Posjetitelji).Reverse().ToList();
            foreach (var info in sortedInformacije)
            {
                dt.Rows.Add(info.Lokacija, info.Posjetitelji, info.DomaciTim, info.GostujuciTim);
            }
            
            grv.DataSource = dt;
            if (jezik == "en")
            {
                infoLbl.Text = "Data is shown";
            }
           else infoLbl.Text = "Podatci prikazani";
        }

        private void btnPostavke_Click(object sender, EventArgs e)
        {
            Form postavke = new Postavke(this);
            postavke.Show();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)  
            {
                e.Cancel = true;
                Zatvaranje formaZatvaranja = new Zatvaranje();
                formaZatvaranja.Show();
            }       
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            List<Player> listaOmiljenih = new List<Player>();
            foreach (var item in flp2.Controls)
            {
                if (item is IgracController)
                {
                    listaOmiljenih.Add((item as IgracController).igrac);
                }
            }

            if (rep != null)
            {
                Repo.WriteOmiljenaRep(rep.FifaCode);
            }
            Repo.WriteOmiljeniIgraci(listaOmiljenih);
        }
    }
   
}
