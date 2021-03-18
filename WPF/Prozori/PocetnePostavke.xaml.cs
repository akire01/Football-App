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
    /// Interaction logic for PocetnePostavke.xaml
    /// </summary>
    public partial class PocetnePostavke : Window
    {
        string prvenstvo = null;
        string jezik = null;
        public PocetnePostavke()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeprvenstvo = (ComboBoxItem)cbPrvenstvo.SelectedItem;
            string prvenstvo = typeprvenstvo.Tag.ToString();
            

            ComboBoxItem typejezik = (ComboBoxItem)cbJezik.SelectedItem;
            string jezik= typejezik.Tag.ToString();

            ComboBoxItem typeformat = (ComboBoxItem)cbFormat.SelectedItem;
            string rezolucija = typeformat.Tag.ToString();

            try
            {
                if (prvenstvo == "m") Repo.WritePrvenstvo("m");
                else Repo.WritePrvenstvo("z");
            }
            catch
            {
                MessageBox.Show("Zapisivanje nije uspjelo", "Upozorenje",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Information);
            }

            try
            {
                if (jezik == "hr") Repo.WriteJezik("hr");
                else Repo.WriteJezik("en");
            }
            catch
            {
                MessageBox.Show("Zapisivanje nije uspjelo", "Upozorenje",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Information);
            }

            switch (rezolucija)
            {
                case "1":
                    MainWindow mw1 = new MainWindow(700, 1200);
                    mw1.Show();
                    this.Close();
                    break;
                case "2":
                    MainWindow mw2 = new MainWindow(750, 1350);
                    mw2.Show();
                    this.Close();
                    break;
                case "3":
                    MainWindow mw3 = new MainWindow(820, 1550);
                    mw3.Show();
                    this.Close();
                    break;

            }

        }
    }
}
