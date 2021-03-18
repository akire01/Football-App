using DAL.Models;
using Newtonsoft.Json;
using WindowsForms.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repo
    {
        
        public static List<Utakmica> utakmice = new List<Utakmica>();
        public static string FifaCode{ get; private set; }
        
        //AppData->Roaming->OOP
        public static string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OOP");
        
        //Jezik i prvenstvo
        private static string dokument1 = 
            Path.Combine(folderPath, "OOPDocument1.txt");
        
        //Omiljeni igraci
        private static string dokument2 =
         Path.Combine(folderPath, "OOPDocument2.txt");
        
        //Omiljena reprezentacija
        private static string dokument3 =
         Path.Combine(folderPath, "OOPDocument3.txt");

        public static string slikeFolder = Path.Combine(folderPath, "Slike");


         //DOHVATI SLIKE
        public static String[] GetFilesFrom(String searchFolder, String[] filters)
        {
            List<String> filesFound = new List<String>();
          
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter)));
            }
            return filesFound.ToArray();
        }


        public static void WriteOmiljenaRep(string rep)
        {
            string json = JsonConvert.SerializeObject(rep);
            System.IO.File.WriteAllText(dokument3, json);
        }
        public static string ReadOmiljenaRep()
        {
            try
            {
                using (StreamReader r = new StreamReader(dokument3))
                {
                    string json = r.ReadToEnd();
                    string item = JsonConvert.DeserializeObject<string>(json);
                    return item;
                }
            }
            catch
            {
                Directory.CreateDirectory(folderPath);
                File.Create(dokument3).Close();
                return null;
            }
            
        }


        public static void WriteOmiljeniIgraci(List<Player> omiljeniIgraci)
        {
            string json = JsonConvert.SerializeObject(omiljeniIgraci);
            System.IO.File.WriteAllText(dokument2, json);
        }

        public static List<Player> ReadOmiljeniIgraci()
        {
            try
            {
                using (StreamReader r = new StreamReader(dokument2))
                {
                    string json = r.ReadToEnd();
                    List<Player> item = JsonConvert.DeserializeObject<List<Player>>(json);
                    return item;
                }
            }
            catch
            {
                Directory.CreateDirectory(folderPath);
                File.Create(dokument2).Close();
                return new List<Player>();
            }
           
        }
         
        private static InfoZaPostavke ReadInfo()
        {
            try
            {
                using (StreamReader r = new StreamReader(dokument1))
                {
                    string json = r.ReadToEnd();
                    InfoZaPostavke item = JsonConvert.DeserializeObject<InfoZaPostavke>(json);
                    return item;
                }
            } catch (Exception e)
            {
                Directory.CreateDirectory(folderPath);
                File.Create(dokument1).Close();
                return null;
            }
            
        }

        private static void WriteInfo(InfoZaPostavke info)
        {
            string json = JsonConvert.SerializeObject(info);

            System.IO.File.WriteAllText(dokument1, json);
        }
        public static void WriteJezik(string jezik)
        {
            InfoZaPostavke postavke = ReadInfo();

            if (postavke == null)
            {
                postavke = new InfoZaPostavke();
            }

            postavke.Jezik = jezik;
            WriteInfo(postavke);
        }

        public static void WritePrvenstvo(string prvenstvo)
        {
            InfoZaPostavke postavke = ReadInfo();

            if(postavke == null)
            {
                postavke = new InfoZaPostavke();
            }

            postavke.Prvenstvo = prvenstvo;
            WriteInfo(postavke);
        }

       
        public static string ReadJezik()
        {
            InfoZaPostavke postavke = ReadInfo();

            if(postavke == null) { return null; }

            return postavke.Jezik;
        }

        public static string ReadPrventsvo()
        {
            InfoZaPostavke postavke = ReadInfo();

            if (postavke == null) { return null; }

            return postavke.Prvenstvo;
        }

        public static Task<List<Reprezentacija>> GetPodatci(string prvenstvo)
        {
            try
            {
                if (prvenstvo == "z")
                {
                    return Task.Run(() =>
                    {
                        var restKlijent = new RestClient("https://worldcup.sfg.io/teams/results");

                        var rezultat = restKlijent.Execute<List<Reprezentacija>>(new RestRequest());

                        return JsonConvert.DeserializeObject<List<Reprezentacija>>(rezultat.Content);
                    });

                }
                else
                {
                    return Task.Run(() =>
                    {
                        var restKlijent = new RestClient("https://world-cup-json-2018.herokuapp.com/teams/results");

                        var rezultat = restKlijent.Execute<List<Reprezentacija>>(new RestRequest());

                        return JsonConvert.DeserializeObject<List<Reprezentacija>>(rezultat.Content);
                    });
                }
               
            }
            catch(Exception e)
            {
                return null;
            }
         
        }

        public static Task<List<Utakmica>> DohvatiUtakmice(string code, string prventsvo)
        {
            try
            {
                FifaCode = code;

                if (prventsvo == "z")
                {
                    return Task.Run(() =>
                    {
                        var restKlijent = new RestClient($"https://worldcup.sfg.io/matches/country?fifa_code={FifaCode}");

                        var rezultat = restKlijent.Execute<List<Utakmica>>(new RestRequest());

                        utakmice = JsonConvert.DeserializeObject<List<Utakmica>>(rezultat.Content);

                        return utakmice;
                    });
                }
                else
                {
                    return Task.Run(() =>
                    {
                        var restKlijent = new RestClient($"https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code={FifaCode}");

                        var rezultat = restKlijent.Execute<List<Utakmica>>(new RestRequest());

                        try
                        {
                            utakmice = JsonConvert.DeserializeObject<List<Utakmica>>(rezultat.Content);

                            return utakmice;
                        } catch (Exception e)
                        {
                            return null;
                        }
                
                    });
                }
            }
           
            catch(Exception e)
            {
                return null;
            }
        }
        public static Task<List<Player>> DohvatiIgrace(List<Utakmica> utakmice, string fifaCode)
        {
            return Task.Run(() =>
            {
                List<Player> players = new List<Player>();

                if (utakmice[0].HomeTeam.Code == fifaCode)
                {
                    utakmice[0].HomeTeamStatistics.StartingEleven.ForEach(p => players.Add(p));
                    utakmice[0].HomeTeamStatistics.Substitutes.ForEach(p => players.Add(p));
                }
                else
                {
                    utakmice[0].AwayTeamStatistics.StartingEleven.ForEach(p => players.Add(p));
                    utakmice[0].AwayTeamStatistics.Substitutes.ForEach(p => players.Add(p));
                }
                return players;
            });
        }

        public static Task<List<Player>> DohvatiPocetnuPostavu(List<Utakmica> utakmice, string rep1, string rep2)
        {
            return Task.Run(() =>
            {
                List<Player> players = new List<Player>();

                foreach (var utakmica in utakmice)
                {
                    if (utakmica.HomeTeam.Code == rep1 && utakmica.AwayTeam.Code == rep2)
                    { 
                        utakmica.HomeTeamStatistics.StartingEleven.ForEach(p => players.Add(p));
                    }

                    else if ((utakmica.HomeTeam.Code == rep2 && utakmica.AwayTeam.Code == rep1))
                    {
                        utakmica.AwayTeamStatistics.StartingEleven.ForEach(p => players.Add(p));
                    }

                    if (players.Count == 11)
                    {
                        break;
                    }
                }
                
                return players;
            });
        }

        public static Task<List<TeamEvent>> DohvatiEventeUtakmice(List<Utakmica> utakmice, string rep1, string rep2)
        {
            return Task.Run(() =>
            {
                List<TeamEvent> eventi = new List<TeamEvent>();

                foreach (var utakmica in utakmice)
                {
                    if (utakmica.HomeTeam.Code == rep1 && utakmica.AwayTeam.Code == rep2)
                    {
                        utakmica.HomeTeamEvents.ForEach(e => eventi.Add(e));
                        
                    }

                    else if ((utakmica.HomeTeam.Code == rep2 && utakmica.AwayTeam.Code == rep1))
                    {
                        utakmica.AwayTeamEvents.ForEach(e => eventi.Add(e));
                    }
                }

                return eventi;
            });
        }

        public static Task<List<Team>> DohvatiProtivnike(List<Utakmica> utakmice, string fifaCode)
        {
            return Task.Run(() =>
            {
                List<Team> protivnici = new List<Team>();

                foreach (var utak in utakmice)
                {
                    if (utak.HomeTeam.Code == fifaCode)
                    {
                        protivnici.Add(utak.AwayTeam);
                    }
                    else
                    {
                        protivnici.Add(utak.HomeTeam);
                    }
                }
                
                return protivnici;
            });
          
        }

       
        public static Task<List<InfoZaUtakmice>> DohvatiInfoZaUtakmice(string FifaCode, string prvenstvo)
        {
            List<Utakmica> utakmice = new List<Utakmica>();
            List<InfoZaUtakmice> InfoZaUtakmice = new List<InfoZaUtakmice>();

            try
            {
                if (prvenstvo == "m")
                {
                    return Task.Run(() =>
                    {
                        var restKlijent = new RestClient($"https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code={FifaCode}");

                        var rezultat = restKlijent.Execute<List<Utakmica>>(new RestRequest());

                        try
                        {
                            utakmice = JsonConvert.DeserializeObject<List<Utakmica>>(rezultat.Content);
                            for (int i = 0; i < utakmice.Count; i++)
                            {
                                InfoZaUtakmice.Add(new Models.InfoZaUtakmice
                                {
                                    Lokacija = utakmice[i].Location,
                                    Posjetitelji = utakmice[i].Attendance,
                                    DomaciTim = utakmice[i].HomeTeamCountry,
                                    GostujuciTim = utakmice[i].AwayTeamCountry
                                });
                            }
                            return InfoZaUtakmice;
                        } catch (Exception e)
                        {
                            return null;
                        }

                        
                    });
                }

                else
                {
                    return Task.Run(() =>
                    {
                        var restKlijent = new RestClient($"https://worldcup.sfg.io/matches/country?fifa_code={FifaCode}");

                        var rezultat = restKlijent.Execute<List<Utakmica>>(new RestRequest());

                        utakmice = JsonConvert.DeserializeObject<List<Utakmica>>(rezultat.Content, new JsonSerializerSettings { 
                            NullValueHandling = NullValueHandling.Ignore
                        });

                        for (int i = 0; i < utakmice.Count; i++)
                        {
                            InfoZaUtakmice.Add(new Models.InfoZaUtakmice
                            {
                                Lokacija = utakmice[i].Location,
                                Posjetitelji = utakmice[i].Attendance,
                                DomaciTim = utakmice[i].HomeTeamCountry,
                                GostujuciTim = utakmice[i].AwayTeamCountry
                            });
                        }
                        return InfoZaUtakmice;
                    });
                }
            }
            catch(Exception e)
            {
                return null;
            }
           
        }

    }
}

