using DAL;
using DAL.Models;
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
    /// Interaction logic for KontrolaIgraca.xaml
    /// </summary>
    public partial class KontrolaIgraca : UserControl
    {
        Player player = null;
        int goals = 0;
        int yellow = 0;
        public KontrolaIgraca(Player p, List<TeamEvent> eventi)
        {
            player = p;
            foreach (var e in eventi)
            {
                if (e.TypeOfEvent == "goal" || e.TypeOfEvent == "goal-penalty")
                {
                    if (player.Name.ToString() == e.Player)
                    {
                        goals++;
                    }
                   
                }

                if (e.TypeOfEvent == "yellow-card")
                {
                    if (player.Name.ToString() == e.Player)
                    {
                        yellow++;
                    }
                }
            }
            InitializeComponent();
            lblIme.Content = player.Name;
            lblBroj.Content = player.ShirtNumber;
            

        }

        private void igrac_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IgracInfo prozorIgraca = new IgracInfo(player, goals, yellow);
            //prozorIgraca.Owner = MainWindow;
            String searchFolder = Repo.folderPath;
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            var files = Repo.GetFilesFrom(searchFolder, filters);
           
            foreach (var item in files)
            {
                string ime = item.Substring(item.LastIndexOf(("\\")) + 1);
                string test = "Slike" + player.ToString() + ".jpg";
                if (ime.Equals("Slike" + player.ToString() + ".jpg"))
                {
                    prozorIgraca.UcitajSliku(item);
                }
            }
           
            prozorIgraca.Show();
        }

        public void UcitajSliku(string picturePath)
        {
            slika.Source = new BitmapImage(new Uri(picturePath));
        }
    }
}
