using GameHub.Model;
using System.Text.Json;

namespace GameHub.Repository
{
    public class GameRepository
    {

        private readonly JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        private readonly string arquivojson = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\players.json";

        public bool SalvarCadastro(List<Jogador> ListaDeJogadores)
        {
            if (ListaDeJogadores.Count == 0) 
            {
                Console.WriteLine("Não há jogadores cadastrados");
                return false; 
            }

            string jogadorJson = JsonSerializer.Serialize(ListaDeJogadores, options);
            try
            {
                File.WriteAllText(arquivojson, jogadorJson);
                Console.WriteLine($"Dados salvos na pasta {arquivojson}");
                return true;

            }
            catch(Exception ex) 
            { 
                return false;
            }

        }

        public void ShowRankingPerGame(List<Jogador> ListaDeJogadores, string gameName)
        {
            List<RankingToShow> RankingList = new List<RankingToShow>();

            if (ListaDeJogadores.Count == 0)
            {
                Console.WriteLine("Não há jogadores cadastrados");
                return;
            }

            for (int i = 0; i < ListaDeJogadores.Count(); i++)
            {
                if (gameName == "BatalhaNaval") 
                {
                    RankingList.Add(new RankingToShow
                    {
                        Name = ListaDeJogadores[i].Name,
                        Login = ListaDeJogadores[i].Login,
                        Score = ListaDeJogadores[i].ScoreBatalhaNaval
                    });

                }
                else if (gameName == "JogoDaVelha")
                {
                    RankingList.Add(new RankingToShow
                    {
                        Name = ListaDeJogadores[i].Name,
                        Login = ListaDeJogadores[i].Login,
                        Score = ListaDeJogadores[i].ScoreJogoDaVelha
                    });
                }
                
            }

            List<RankingToShow> sortedList = RankingList.OrderByDescending(x => x.Score).ToList();

            string jogadorJson = JsonSerializer.Serialize(sortedList, options);
            Console.WriteLine(jogadorJson);
        }

        public List<Jogador> getJogadorJson()
        {
            string jsonContent = File.ReadAllText(arquivojson);

            List<Jogador> listaJogador = new List<Jogador>();

            List<Jogador>? leitura = JsonSerializer.Deserialize<List<Jogador>>(jsonContent, options);

            if (leitura != null) 
            {
                listaJogador.AddRange(leitura);
            }
            return listaJogador;

        }
    }


}
