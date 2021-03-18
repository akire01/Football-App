using DAL;
using DAL.Models;
using WindowsForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Prozori;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Reprezentacija> reprezentacije = new List<Reprezentacija>();
        List<Team> protivnickeReprezentacije = new List<Team>();
        private Reprezentacija omiljenaRep = null;
        private Reprezentacija protivnik = null;
        private Team protivnickaRep = null;
        string prvenstvo;
        string jezik;
        
        public MainWindow(int height, int width)
        {
            Height = height;
            Width = width;
            jezik = Repo.ReadJezik();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(jezik);
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            NapuniComboBox();
        }

        private async void NapuniComboBox()
        {
            prvenstvo = Repo.ReadPrventsvo();
            var podatci = await Repo.GetPodatci(prvenstvo);
            if (podatci == null)
            {
                if (jezik == "hr")
                {
                    MessageBox.Show("Dohvaćanje podataka nije uspjelo", "Upozorenje",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Information);
                }
                else MessageBox.Show("Reaching the data did not succeeded", "Warning",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Information);
                return;
            }
            reprezentacije = podatci;
            reprezentacije.Sort((x, y) => string.Compare(x.Country, y.Country));

            foreach (var item in podatci)
            {
                cbOmiljenaRep.Items.Add($"{item.Country} ({item.FifaCode})");

            }

            //AKO VEC POSTOJI OMILJENA
            if (Repo.ReadOmiljenaRep() != "" && Repo.ReadOmiljenaRep() != null)
            {
                string orKod = Repo.ReadOmiljenaRep();
                
                int i = 0;
                int indexOmiljene = 0;
                foreach (var r in reprezentacije)
                {
                   
                    if (r.FifaCode == orKod)
                    {
                        indexOmiljene = i;
                        omiljenaRep = r;
                        break;
                    }
                    i++;
                }
                cbOmiljenaRep.SelectedIndex = indexOmiljene;

                NapuniDrugiComboBox(omiljenaRep);
            }
           
        }

        private void btnDomaci_Click(object sender, RoutedEventArgs e)
        {
            if (omiljenaRep == null)
            {
                if (jezik == "hr")
                {
                    MessageBox.Show("Niste odabrali omiljenu reprezentaciju" + System.Environment.NewLine + "iz padajućeg izbornika", "Upozorenje",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Warning);
                }
               else
                    MessageBox.Show("You did not choose favourite representation" + System.Environment.NewLine + " from combobox", "Warning",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Warning);
            }

            else
            {
                Window detalji = new Detalji(omiljenaRep);
                detalji.Owner = this;
                detalji.Show();
            }

        }

        private void btnProtivnik_Click(object sender, RoutedEventArgs e)
        {
            if (protivnik == null)
            {
                if (jezik == "hr")
                {
                    MessageBox.Show("Niste odabrali suparničku reprezentaciju" + System.Environment.NewLine + "iz padajućeg izbornika", "Upozorenje",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Warning);
                }
               else
                    MessageBox.Show("You did not choose the opponent " + System.Environment.NewLine + " from combobox", "Warning",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Warning);
            }
            if (protivnik != null)
            {
                Window detalji = new Detalji(protivnik);
                detalji.Owner = this;
                detalji.Show();
            }

        }
        private void cbOmiljenaRep_DropDownClosed(object sender, EventArgs e)
        {
            foreach (StackPanel childOfChild in PronadiElemente<StackPanel>(this))
            {
                childOfChild.Children.Clear();
            }

            if (cbOmiljenaRep.SelectedIndex > reprezentacije.Capacity || cbOmiljenaRep.SelectedIndex < 0)
            {
                return;
            }
            omiljenaRep = reprezentacije[cbOmiljenaRep.SelectedIndex];
            NapuniDrugiComboBox(omiljenaRep);

        }

        private async void NapuniDrugiComboBox(Reprezentacija omiljenaRep)
        {
            try
            {
                protivnickeReprezentacije.Clear();
                cbProtivnici.Items.Clear();
                List<Utakmica> utakmice = await Repo.DohvatiUtakmice(omiljenaRep.FifaCode, prvenstvo);
                List<Team> protivnici = await Repo.DohvatiProtivnike(utakmice, omiljenaRep.FifaCode);

                foreach (var item in protivnici)
                {

                    cbProtivnici.Items.Add($"{item.Country} ({item.Code})");

                    protivnickeReprezentacije.Add(item);

                }
            }
            catch
            {
                if (jezik == "hr")
                {
                    MessageBox.Show("Dohvaćanje podataka nije uspjelo", "Upozorenje",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Information);
                }
                else MessageBox.Show("Reaching the data did not succeeded", "Warning",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Information);
            }
            

        }

        private void cbProtivnici_DropDownClosed(object sender, EventArgs e)
        {
         
            if (cbProtivnici.SelectedIndex > protivnickeReprezentacije.Capacity || cbProtivnici.SelectedIndex < 0)
            {
                return;
            }
            protivnickaRep = protivnickeReprezentacije[cbProtivnici.SelectedIndex];
            
            GetProtinickaRep(protivnickaRep);

        }

        private async void GetProtinickaRep(Team protivnickaRep)
        {
            try
            {
                List<Reprezentacija> sveReprezentacije = await Repo.GetPodatci(prvenstvo);
                foreach (var rep in sveReprezentacije)
                {
                    if (rep.FifaCode == protivnickaRep.Code)
                    {
                        protivnik = rep;
                        break;
                    }
                }

                PrikaziIgrace();
            }
            catch
            {
                if (jezik == "hr")
                {
                    MessageBox.Show("Dohvaćanje podataka nije uspjelo", "Upozorenje",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Information);
                }
                else MessageBox.Show("Reaching the data did not succeeded", "Warning",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Information);
            }
           

        }

        public static IEnumerable<T> PronadiElemente<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in PronadiElemente<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private async void PrikaziIgrace()
        {
            try
            {
                List<Utakmica> utakmice = await Repo.DohvatiUtakmice(omiljenaRep.FifaCode, prvenstvo);
                List<Player> igraci = await Repo.DohvatiPocetnuPostavu(utakmice, omiljenaRep.FifaCode, protivnik.FifaCode);
                List<Player> igraci2 = await Repo.DohvatiPocetnuPostavu(utakmice, protivnik.FifaCode, omiljenaRep.FifaCode);

                List<TeamEvent> eventi1 = await Repo.DohvatiEventeUtakmice(utakmice, omiljenaRep.FifaCode, protivnik.FifaCode);
                List<TeamEvent> eventi2 = await Repo.DohvatiEventeUtakmice(utakmice, protivnik.FifaCode, omiljenaRep.FifaCode);


                foreach (StackPanel childOfChild in PronadiElemente<StackPanel>(this))
                {
                    childOfChild.Children.Clear();
                }

                String searchFolder = Repo.folderPath;
                var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
                var files = Repo.GetFilesFrom(searchFolder, filters);

                foreach (var igrac in igraci)
                {
                    KontrolaIgraca kontrola = new KontrolaIgraca(igrac, eventi1);
                    foreach (var item in files)
                    {
                        string ime = item.Substring(item.LastIndexOf(("\\")) + 1);
                        string test = "Slike" + igrac.ToString() + ".jpg";
                        if (ime.Equals("Slike" + igrac.ToString() + ".jpg"))
                        {
                            kontrola.UcitajSliku(item);
                        }
                    }

                    switch (igrac.Position)
                    {
                        case "Goalie":
                            spGolman.Children.Add(kontrola);
                            break;
                        case "Defender":
                            spDefender.Children.Add(kontrola);
                            break;
                        case "Midfield":
                            spMidfield.Children.Add(kontrola);
                            break;
                        case "Forward":
                            spForward.Children.Add(kontrola);
                            break;
                        default:
                            break;
                    }
                }

                foreach (var igrac in igraci2)
                {
                    KontrolaIgraca kontrola = new KontrolaIgraca(igrac, eventi2);
                    switch (igrac.Position)
                    {
                        case "Goalie":
                            sp2Golman.Children.Add(kontrola);
                            break;
                        case "Defender":
                            sp2Defender.Children.Add(kontrola);
                            break;
                        case "Midfield":
                            sp2Midfield.Children.Add(kontrola);
                            break;
                        case "Forward":
                            sp2Forward.Children.Add(kontrola);
                            break;
                        default:
                            break;
                    }
                }

            }
            catch
            {
                if (jezik == "hr")
                {
                    MessageBox.Show("Dohvaćanje podataka nije uspjelo", "Upozorenje",
                                           MessageBoxButton.OK,
                                           MessageBoxImage.Information);
                }
                else MessageBox.Show("Reaching the data did not succeeded", "Warning",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Information);
            }
            
        }

        private void btnPostavke_Click(object sender, RoutedEventArgs e)
        {
            Postavke postavke = new Postavke();
            postavke.Owner = this;
            postavke.Show();

            postavke.Closed += Postavke_Closed;

        }
       
        private void Postavke_Closed(object sender, EventArgs e)
        {
            string noviJezik = Repo.ReadJezik();
            string novoPrvenstvo = Repo.ReadPrventsvo();
            if (jezik != noviJezik || prvenstvo !=  novoPrvenstvo)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(noviJezik);

                prikaziZatvaranje = false;
                MainWindow mw = new MainWindow(700, 1200);
                mw.Show();
                this.Close();
            }
        }

        private bool prikaziZatvaranje = true;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!prikaziZatvaranje)
            {
                return;
            }

            if (omiljenaRep == null)
            {
                Zatvaranje zatvaranje1 = new Zatvaranje();
                zatvaranje1.Owner = this;
                zatvaranje1.Show();
            }
            else
            {
                Zatvaranje zatvaranje2 = new Zatvaranje(omiljenaRep.FifaCode);
                zatvaranje2.Owner = this;
                zatvaranje2.Show();
            }
          

            e.Cancel = true; //blokiraj event zatvaranja

        }
    }
}
