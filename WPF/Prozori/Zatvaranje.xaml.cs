using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Zatvaranje.xaml
    /// </summary>
    public partial class Zatvaranje : Window
    {
        string omiljenaRep;

        public Zatvaranje()
        {
            string jezik = Repo.ReadJezik();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(jezik);
            InitializeComponent();
        }

        public Zatvaranje(string omiljena)
        {
            omiljenaRep = omiljena;
            string jezik = Repo.ReadJezik();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(jezik);
            InitializeComponent();
        }

      
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
            if (e.Key == Key.Enter)
            {
                if (omiljenaRep != "" && omiljenaRep != null) Repo.WriteOmiljenaRep(omiljenaRep);
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void btnDa_Click(object sender, RoutedEventArgs e)
        {
            if (omiljenaRep != "" && omiljenaRep != null) Repo.WriteOmiljenaRep(omiljenaRep);
          
            System.Windows.Application.Current.Shutdown();
        }

        private void btnNe_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
