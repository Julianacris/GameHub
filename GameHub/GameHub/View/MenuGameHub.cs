using GameHub.Model;
using GameHub.Repository;
using System;
using System.Linq.Expressions;

namespace GameHub.View
{
    public class MenuGameHub
    {
        private JogadorManager JogadorManager;
        private GameRepository Repository;

        public MenuGameHub(JogadorManager manager, GameRepository repository)
        {
            JogadorManager = manager;
            Repository = repository;
        }

        public string ShowMenu()
        {
            Console.WriteLine("1 - Para cadastrar Jogador");
            Console.WriteLine("2 - Para Jogar Batalha Naval");
            Console.WriteLine("3 - Para Jogar Jogo da Velha");
            Console.WriteLine("4 - Para exibir o ranking da Batalha Naval em formato JSON");
            Console.WriteLine("5 - Para exibir o ranking do Jogo Da Velha em formato JSON");
            Console.WriteLine("6 - Para salvar os dados dos jogadores em formato JSON");
            Console.WriteLine("7 - Para Carregar JSON");
            Console.WriteLine("0 - Para sair do GameHub");
            Console.WriteLine("Digite a opção desejada");

            return Console.ReadLine();
        }

        public void ScreenJogoDaVelha(List<Jogador> ListaJogadores)
        {
            try
            {
                Jogador jogador1 = ScreenLogin(1);
                Jogador jogador2 = ScreenLogin(2);

                if (jogador1.Login == jogador2.Login)
                {
                    Console.WriteLine("Login duplicado não permitido, voltando ao menu inicial...");
                    throw new ReturnMainMenu();
                }

                new JogoDaVelha(jogador1, jogador2).IniciarJogoDaVelha();

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (ExcptPlayerNotExists e2)
            {
                return;
            }
        }
        public void ScreenBatalhaNaval(List<Jogador> ListaJogadores)
        {
            try
            {
                Jogador jogador1 = ScreenLogin(1);
                Jogador jogador2 = ScreenLogin(2);

                if (jogador1.Login == jogador2.Login)
                {
                    Console.WriteLine("Login duplicado não permitido, voltando ao menu inicial...");
                    throw new ReturnMainMenu();
                }

                new BatalhaNaval(jogador1, jogador2).IniciaJogo();

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (ExcptPlayerNotExists e2)
            {
                return;
            }
        }

        public void ScreenCadastroJogador()
        {
            Boolean UserExists = true;
            string newTry = "";
            string login = "";
            Console.WriteLine("Bem vindo ao cadastro de novo Jogador");

            do
            {
                Console.WriteLine("Informe o novo Login para check de disponibilidade:");
                login = Console.ReadLine();
                if (JogadorManager.FindIndexPlayer(login) != -1)
                {
                    UserExists = true;
                    Console.WriteLine("Login indisponivel");
                    Console.WriteLine("1 - Para tentar outro login");
                    Console.WriteLine("0 - Para voltar ao Menu Principal");

                    do
                    {
                        newTry = Console.ReadLine();
                        if (newTry == "0") 
                        { 
                            throw new ReturnMainMenu(); 
                        }
                    } while (newTry != "1");
                }
                else
                {
                    UserExists = false;
                }
            } while (UserExists != false);

            Console.WriteLine("Informe o nome do novo jogador:");
            string name = Console.ReadLine();

            Console.WriteLine("Informe a senha do novo jogador:");
            string password = Console.ReadLine();

            JogadorManager.CadastraJogador(login, password, name);
        }

        public Boolean playerExists(string login)
        {

            if (JogadorManager.FindIndexPlayer(login) == -1)
            {
                Console.WriteLine("Jogador não cadastrado");
                return false;
            }
            else
            {
                return true;
            }


        }

        public Jogador ScreenLogin(int numeroJogador)
        {
            Console.WriteLine($"Informe o Login do primeiro Jogador{numeroJogador}:");
            string Login = Console.ReadLine();
            if (playerExists(Login))
            {
                Console.WriteLine("Informe a senha:");
                string password = Console.ReadLine();

                try
                {
                    return JogadorManager.ExecuteLogin(Login, password);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    throw new InvalidOperationException(e.Message);
                }

            }
            else
            {
                Console.WriteLine("Cadastre o usuario e tente novamente");
                throw new ExcptPlayerNotExists();
            }

        }

        public void MainMenuHandler(string option)
        {
            try
            {
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    case "1":
                        ScreenCadastroJogador();
                        break;
                    case "2":
                        ScreenBatalhaNaval(JogadorManager.ListaDeJogadores);
                        break;
                    case "3":
                        ScreenJogoDaVelha(JogadorManager.ListaDeJogadores);
                        break;
                    case "4":
                        Repository.ShowRankingPerGame(JogadorManager.ListaDeJogadores,"BatalhaNaval");
                        break;
                    case "5":
                        Repository.ShowRankingPerGame(JogadorManager.ListaDeJogadores, "JogoDaVelha");
                        break;
                    case "6":
                        Repository.SalvarCadastro(JogadorManager.ListaDeJogadores);
                        break;
                    case "7":
                        JogadorManager.ListaDeJogadores = Repository.getJogadorJson();
                        break;
                }
            } 
            catch (ReturnMainMenu e)
            { 
                return; 
            }
        }
    }

    public class ExcptPlayerNotExists : Exception { }
    public class ReturnMainMenu: Exception { }
}
