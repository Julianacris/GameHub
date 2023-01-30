using System;
using System.ComponentModel;

namespace GameHub.Model
{
    public class Jogador
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int ScoreJogoDaVelha { get; set; }

        public int ScoreBatalhaNaval { get; set; }

        public Jogador(string login, string password, string name)
        {
            Login = login;
            Password = password;
            Name = name;

        }
    }

    public class JogadorManager
    {

        public List<Jogador> ListaDeJogadores;

        public JogadorManager()
        {
            ListaDeJogadores = new List<Jogador>();
        }

        public void CadastraJogador(string login, string password, string name)
        {
            ListaDeJogadores.Add(new Jogador(login, password, name));
        }

        public int FindIndexPlayer(string login)
        {
            try
            {
                return ListaDeJogadores.FindIndex(players => players.Login == login);

            }
            catch (NullReferenceException e)
            {
                return -1;
            }
        }


        public Jogador ExecuteLogin(string login, string password)
        {
            int Index = FindIndexPlayer(login);

            if (ListaDeJogadores[Index].Password == password)
            {
                return ListaDeJogadores[Index];
            }
            else
            {
                throw new InvalidOperationException("Senha Incorreta"); ;
            }
        }
    }

    public class RankingToShow
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
