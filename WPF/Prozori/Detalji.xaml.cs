using DAL;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF.Prozori
{
    /// <summary>
    /// Interaction logic for Detalji.xaml
    /// </summary>
    public partial class Detalji : Window
    {
        public Detalji(Reprezentacija rep)
        {
            string jezik = Repo.ReadJezik();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(jezik);
            InitializeComponent();
            lblNaziv.Content = rep.Country;
            lblFifaKod.Content = rep.FifaCode;
            lblUtakmice.Content = rep.GamesPlayed.ToString();
            lblPobjede.Content = rep.Wins.ToString();
            lblPorazi.Content = rep.Losses.ToString();
            lblNeodluceno.Content = rep.Draws.ToString();
            lblZabijeno.Content = rep.GoalsFor.ToString();
            lblPrimljeno.Content = rep.GoalsAgainst.ToString();
            lblRazlika.Content = rep.GoalDifferential.ToString();
        }
    }
}
