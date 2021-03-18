using DAL;
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
    /// Interaction logic for Postavke.xaml
    /// </summary>
    public partial class Postavke : Window
    {
        string prvenstvo;
        string jezik;
        public Postavke()
        {
            jezik = Repo.ReadJezik();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(jezik);
            prvenstvo = Repo.ReadPrventsvo();
            InitializeComponent();
            switch (jezik)
            {
                case "hr":
                    cbJezik.SelectedItem = cbJezik.Items.OfType<ComboBoxItem>().FirstOrDefault(cbItem => cbItem.Tag.ToString() == "hr");
                    break;
                case "en":
                    cbJezik.SelectedItem = cbJezik.Items.OfType<ComboBoxItem>().FirstOrDefault(cbItem => cbItem.Tag.ToString() == "en");
                    break;
            }
            switch(prvenstvo)
            {
                case "m":
                    cbPrvenstvo.SelectedItem = cbPrvenstvo.Items.OfType<ComboBoxItem>().FirstOrDefault(cbItem => cbItem.Tag.ToString() == "m");
                    break;
                case "z":
                    cbPrvenstvo.SelectedItem = cbPrvenstvo.Items.OfType<ComboBoxItem>().FirstOrDefault(cbItem => cbItem.Tag.ToString() == "z");
                    break;
            }
               
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Zapisi();
            Close();
        }

        private void Zapisi()
        {
            ComboBoxItem typeprvenstvo = (ComboBoxItem)cbPrvenstvo.SelectedItem;
            string prvenstvo = typeprvenstvo.Tag.ToString();

            ComboBoxItem typejezik = (ComboBoxItem)cbJezik.SelectedItem;
            string jezik = typejezik.Tag.ToString();

            try
            {
                if (jezik == "hr") Repo.WriteJezik("hr");
                else Repo.WriteJezik("en");

                if (prvenstvo != Repo.ReadPrventsvo())
                {
                    if (prvenstvo == "m") Repo.WritePrvenstvo("m");
                    else Repo.WritePrvenstvo("z");
                    Repo.WriteOmiljenaRep("");
                }
               
            }
            catch
            {
                MessageBox.Show("Zapisivanje nije uspjelo", "Upozorenje",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Information);
            }

            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
            if (e.Key == Key.Enter)
            {
                Zapisi();
                Close();
            }
        }
    }
}
