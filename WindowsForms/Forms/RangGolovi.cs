using DAL;
using DAL.Models;
using WindowsForms.Models;
using RestSharp.Extensions;
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
    public partial class RangGolovi : Form
    {
        List<Statistika> statistike = new List<Statistika>();
        List<Utakmica> utakmice = Repo.utakmice;
        string fifaCode = Repo.FifaCode;
        string ucitano = Repo.ReadOmiljenaRep();
        public RangGolovi()
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

            List<Statistika> sortitanaLista = statistike.OrderBy(o => o.goals).Reverse().ToList();
            int iteracija = 0;
            foreach (var item in sortitanaLista)
            {
                
                Player p = item.player;
                IgracController igrac = new IgracController(p);
                igrac.PostaviVrijednost($"Golovi: {sortitanaLista[iteracija].goals}");
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
                    if (teamEvent.TypeOfEvent == "goal" || teamEvent.TypeOfEvent == "goal-penalty")
                    {
                        foreach (var player in statistike)
                        {
                            if (teamEvent.Player == player.ToString())
                            {
                                player.goals++;
                            }
                        }
                    }
                }

                foreach (var teamEvent in utakmica.AwayTeamEvents)
                {
                    if (teamEvent.TypeOfEvent == "goal" || teamEvent.TypeOfEvent == "goal-penalty")
                    {
                        foreach (var player in statistike)
                        {
                            if (teamEvent.Player == player.ToString())
                            {
                                player.goals++;
                            }
                        }
                    }
                }
            }
        }

        
       
    }
}
