
namespace GameHub.Model
{
    public class JogoDaVelha
    {
       
        public bool FimDeJogo { get; set; }
        private char[] Posicoes;
        public char Vez { get; set; }
        public int QuantidadePreenchida { get; set; }

        public Jogador Jogador1 { get; set; }
        public Jogador Jogador2 { get; set; }
        public JogoDaVelha(Jogador jogador1, Jogador jogador2)
        {
            FimDeJogo = false;
            Posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Vez = 'X';
            QuantidadePreenchida = 0;

            Jogador1 = jogador1;
            Jogador2 = jogador2;
        }
        public void IniciarJogoDaVelha()
        {
            while (!FimDeJogo)
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerificarFimDoJogo();
                MudarAVez();
            }
        }
        public void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine("Jogador 1 = X, Jogador 2 = O. Bom Jogo!");
            Console.WriteLine(ObterTabela());
            Console.WriteLine($"Vez do {Vez}");
        }
        public void LerEscolhaDoUsuario()
        {
            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);
            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é inválido, por favor digite um número entre 1 e 9 que esteja disponível na tabela");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }
        public void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            Posicoes[indice] = Vez;
            QuantidadePreenchida++;
        }

        public bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            var indice = posicaoEscolhida - 1;
            if (indice < 1 && indice > 9) 
            {
                return false;
            }

            return Posicoes[indice] != 'O' && Posicoes[indice] != 'X';

        }
        public void VerificarFimDoJogo()
        {
            if (QuantidadePreenchida < 5)
            {
                return;
            }
            if (VitoriaVertical() || VitoriaHorizontal() || VitoriaDiagonal())
            {
                FimDeJogo = true;
                if (Vez == 'X')
                {
                    Jogador1.ScoreJogoDaVelha += 1;
                    Console.WriteLine($"Fim de Jogo!!! Vitória do Jogador {Jogador1.Name}");
                }
                else
                {
                    Jogador2.ScoreJogoDaVelha += 1;
                    Console.WriteLine($"Fim de Jogo!!! Vitória do Jogador {Jogador2.Name}");
                }
                Console.WriteLine($"Score acumulado jogador {Jogador1.Name} e de {Jogador1.ScoreJogoDaVelha} Vitórias");
                Console.WriteLine($"Score acumulado jogador {Jogador2.Name} e de {Jogador2.ScoreJogoDaVelha} Vitórias");
                return;
            }
            for(int j = 0; j > 8; j++)
            {
                if (Posicoes[j] != 'O' && Posicoes[j] != 'X')
                {
                    FimDeJogo = false;
                    return;
                }
                else
                {
                    FimDeJogo = true;
                    Console.WriteLine("Fim de jogo!!! EMPATE");
                }
            }
        }

        public bool VitoriaHorizontal()
        {
            bool vitoriaLinha1 = Posicoes[0] == Posicoes[1] && Posicoes[0] == Posicoes[2];
            bool vitoriaLinha2 = Posicoes[3] == Posicoes[4] && Posicoes[3] == Posicoes[5];
            bool vitoriaLinha3 = Posicoes[6] == Posicoes[7] && Posicoes[6] == Posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }
        public bool VitoriaVertical()
        {
            bool vitoriaLinha1 = Posicoes[0] == Posicoes[3] && Posicoes[0] == Posicoes[6];
            bool vitoriaLinha2 = Posicoes[1] == Posicoes[4] && Posicoes[1] == Posicoes[7];
            bool vitoriaLinha3 = Posicoes[2] == Posicoes[5] && Posicoes[2] == Posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2 || vitoriaLinha3;
        }
        public bool VitoriaDiagonal()
        {
            bool vitoriaLinha1 = Posicoes[2] == Posicoes[4] && Posicoes[2] == Posicoes[6];
            bool vitoriaLinha2 = Posicoes[0] == Posicoes[4] && Posicoes[0] == Posicoes[8];

            return vitoriaLinha1 || vitoriaLinha2;
        }
        public void MudarAVez()
        {
            Vez = Vez == 'X' ? 'O' : 'X';
        }

        public string ObterTabela()
        {
            return $"__{Posicoes[0]}__|__{Posicoes[1]}__|__{Posicoes[2]}__\n" +
                   $"__{Posicoes[3]}__|__{Posicoes[4]}__|__{Posicoes[5]}__\n" +
                   $"  {Posicoes[6]}  |  {Posicoes[7]}  |  {Posicoes[8]}  \n\n";
        }

    }

}
