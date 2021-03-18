using DAL;
using WindowsForms.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            string jezik = Repo.ReadJezik();
            string prventsvo = Repo.ReadPrventsvo();

            if (jezik == null || jezik == "" || prventsvo == null || prventsvo=="")
            {
                Application.Run(new Form1());
            } else
            {
                Application.Run(new Ekran1());

            }

        }
    }
}
