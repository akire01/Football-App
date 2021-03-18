using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.Forms
{
    public partial class RangZutiKartoni : Form
    {
        List<Statistika> statistike = new List<Statistika>();
        List<Utakmica> utakmice = Repo.utakmice;
        string fifaCode = Repo.FifaCode;
        string ucitano = Repo.ReadOmiljenaRep();
        public RangZutiKartoni()
        {
            InitializeComponent();
            if (fifaCode != "")
            {
                DohvatiIgrace(utakmice, fifaCode);
            }
            else
                DohvatiIgrace(utakmice, ucitano);
        }

        private async void DohvatiIgrace(List<Utakmica> utakmice, string fifaCode)
        {
            List<Player> players = new List<Player>();
            players = await Repo.DohvatiIgrace(utakmice, fifaCode);
            PrikaziIgrace(utakmice, fifaCode, players);
        }

        private void PrikaziIgrace(List<Utakmica> utakmice, string fifaCode, List<Player> players)
        {
            flp.Controls.Clear();

            DohvatiEvente(utakmice, players, fifaCode);

            List<Statistika> sortitanaLista = statistike.OrderBy(o => o.yellowCards).Reverse().ToList();
            int iteracija = 0;
            foreach (var item in sortitanaLista)
            {

                Player p = item.player;
                IgracController igrac = new IgracController(p);
                igrac.PostaviVrijednost($"Žuti kartoni: {sortitanaLista[iteracija].yellowCards}");
                flp.Controls.Add(igrac);
                iteracija++;
            }
        }

        private void DohvatiEvente(List<Utakmica> utakmice, List<Player> igraci, string fifaCode)
        {

            foreach (var p in igraci)
            {
                statistike.Add(new Statistika { player = p });
            }

            foreach (var utakmica in utakmice)
            {
                foreach (var teamEvent in utakmica.HomeTeamEvents)
                {
                    if (teamEvent.TypeOfEvent == "yellow-card")
                    {
                        foreach (var player in statistike)
                        {
                            if (teamEvent.Player == player.ToString())
                            {
                                player.yellowCards++;
                            }
                        }
                    }
                }

                foreach (var teamEvent in utakmica.AwayTeamEvents)
                {
                    if (teamEvent.TypeOfEvent == "yellow-card" )
                    {
                        foreach (var player in statistike)
                        {
                            if (teamEvent.Player == player.ToString())
                            {
                                player.yellowCards++;
                            }
                        }
                    }
                }
            }
        }

    }
}
