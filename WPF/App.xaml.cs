using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF.Prozori;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        string jezik = Repo.ReadJezik();
        private void Application_Startup(object sender, StartupEventArgs e)
        {
             if(jezik == null || jezik == "")
             {
                PocetnePostavke pp = new PocetnePostavke();
                pp.Show();
                
             }
             else
             {
                MainWindow mainWindow = new MainWindow(700, 1200);
                mainWindow.Show();
            }
        }
    }
}
