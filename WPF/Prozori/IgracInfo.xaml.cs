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
using System.Windows.Shapes;

namespace WPF.Prozori
{
    /// <summary>
    /// Interaction logic for IgracInfo.xaml
    /// </summary>
    public partial class IgracInfo : Window
    {
        public IgracInfo(Player p, int goals, int yellow)
        {

            InitializeComponent();
            lblIme.Content += $": {p.Name}";
            lblBroj.Content += $": {p.ShirtNumber}";
            lblPozicija.Content += $": {p.Position}";
            lblKapetan.Content += $": {p.Captain}";
            lblGolovi.Content += $": {goals}";
            lblZutiKartoni.Content += $": {yellow}";
        }

       
        public void UcitajSliku(string picturePath)
        {
            slika.Source = new BitmapImage(new Uri(picturePath));

        }

    }
}
