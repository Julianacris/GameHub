using GameHub.Model;
using GameHub.View;
using GameHub.Repository;

namespace GameHub
{
    public class program
    {
        public static void Main(string[] args)
        {
            
            JogadorManager JogadorManager = new JogadorManager();
            GameRepository repository = new GameRepository();

            MenuGameHub Menu = new MenuGameHub(JogadorManager, repository);
            Console.WriteLine("Bem vindo GameHub");

            string option;
            do
            {
                option = Menu.ShowMenu();
                Menu.MainMenuHandler(option);

            } while (option != "0");
        }   
    }
}