using System;

namespace GameHub.Model
{
    public class BatalhaNaval
    {
        private bool FimDeJogo { get; set; }
        private string Vez { get; set; }

        private Jogador Jogador1;
        private Jogador Jogador2;
        private string[] PosicoesDisplay = new string[100];
        private bool[] PosicoesBarcos  = new bool[100];

        public BatalhaNaval(Jogador jogador1, Jogador jogador2)
        {
            Jogador1 = jogador1;
            Jogador2 = jogador2;
            FimDeJogo= false;
            Vez = "X";

            for (int i = 0; i < 100; i++)
            {
                PosicoesDisplay[i] = i.ToString();
                
            }
            
            for (int i = 0; i < 100; i++)
            {
                PosicoesBarcos[i] = false;

            }

            SetPosicaoBarcosFixo();

        }

        public void IniciaJogo() 
        {
            while (!FimDeJogo) 
            {
                RenderizarCampoFixo();
                LerEscolhaDoUsuario();
                VerificarFimDoJogo();
            }
        }

        private void RenderizarCampoFixo() 
        {
            Console.Clear();
            Console.WriteLine("Tiros Certos do Jogador 1 = X, tiros certos do Jogador 2 = 0, tiros na agua a serão espaços em branco. Boa Sorte!");
            Console.WriteLine($"|   {PosicoesDisplay[0]}  |   {PosicoesDisplay[1]}  |   {PosicoesDisplay[2]}  |   {PosicoesDisplay[3]}  |   {PosicoesDisplay[4]}  |   {PosicoesDisplay[5]}  |   {PosicoesDisplay[6]}  |   {PosicoesDisplay[7]}  |   {PosicoesDisplay[8]}  |  {PosicoesDisplay[9]} |");
            WriteHorizontalLine();
            Console.WriteLine($"|  {PosicoesDisplay[10]}  |  {PosicoesDisplay[11]}  |  {PosicoesDisplay[12]}  |  {PosicoesDisplay[13]}  |  {PosicoesDisplay[14]}  |  {PosicoesDisplay[15]}  |  {PosicoesDisplay[16]}  |  {PosicoesDisplay[17]}  |  {PosicoesDisplay[18]}  | {PosicoesDisplay[19]}  |");
            WriteHorizontalLine();
            Console.WriteLine($"|  {PosicoesDisplay[20]}  |  {PosicoesDisplay[21]}  |  {PosicoesDisplay[22]}  |  {PosicoesDisplay[23]}  |  {PosicoesDisplay[24]}  |  {PosicoesDisplay[25]}  |  {PosicoesDisplay[26]}  |  {PosicoesDisplay[27]}  |  {PosicoesDisplay[28]}  | {PosicoesDisplay[29]}  |");
            WriteHorizontalLine();
            Console.WriteLine($"|  {PosicoesDisplay[30]}  |  {PosicoesDisplay[31]}  |  {PosicoesDisplay[32]}  |  {PosicoesDisplay[33]}  |  {PosicoesDisplay[34]}  |  {PosicoesDisplay[35]}  |  {PosicoesDisplay[36]}  |  {PosicoesDisplay[37]}  |  {PosicoesDisplay[38]}  | {PosicoesDisplay[39]}  |");
            WriteHorizontalLine();
            Console.WriteLine($"|  {PosicoesDisplay[40]}  |  {PosicoesDisplay[41]}  |  {PosicoesDisplay[42]}  |  {PosicoesDisplay[43]}  |  {PosicoesDisplay[44]}  |  {PosicoesDisplay[45]}  |  {PosicoesDisplay[46]}  |  {PosicoesDisplay[47]}  |  {PosicoesDisplay[48]}  | {PosicoesDisplay[49]}  |");
            WriteHorizontalLine();
            Console.WriteLine($"|  {PosicoesDisplay[50]}  |  {PosicoesDisplay[51]}  |  {PosicoesDisplay[52]}  |  {PosicoesDisplay[53]}  |  {PosicoesDisplay[54]}  |  {PosicoesDisplay[55]}  |  {PosicoesDisplay[56]}  |  {PosicoesDisplay[57]}  |  {PosicoesDisplay[58]}  | {PosicoesDisplay[59]}  |");
            WriteHorizontalLine();
            Console.WriteLine($"|  {PosicoesDisplay[60]}  |  {PosicoesDisplay[61]}  |  {PosicoesDisplay[62]}  |  {PosicoesDisplay[63]}  |  {PosicoesDisplay[64]}  |  {PosicoesDisplay[65]}  |  {PosicoesDisplay[66]}  |  {PosicoesDisplay[67]}  |  {PosicoesDisplay[68]}  | {PosicoesDisplay[69]}  |");
            WriteHorizontalLine();
            Console.WriteLine($"|  {PosicoesDisplay[70]}  |  {PosicoesDisplay[71]}  |  {PosicoesDisplay[72]}  |  {PosicoesDisplay[73]}  |  {PosicoesDisplay[74]}  |  {PosicoesDisplay[75]}  |  {PosicoesDisplay[76]}  |  {PosicoesDisplay[77]}  |  {PosicoesDisplay[78]}  | {PosicoesDisplay[79]}  |");
            WriteHorizontalLine();
            Console.WriteLine($"|  {PosicoesDisplay[80]}  |  {PosicoesDisplay[81]}  |  {PosicoesDisplay[82]}  |  {PosicoesDisplay[83]}  |  {PosicoesDisplay[84]}  |  {PosicoesDisplay[85]}  |  {PosicoesDisplay[86]}  |  {PosicoesDisplay[87]}  |  {PosicoesDisplay[88]}  | {PosicoesDisplay[89]}  |");
            WriteHorizontalLine();
            Console.WriteLine($"|  {PosicoesDisplay[90]}  |  {PosicoesDisplay[91]}  |  {PosicoesDisplay[92]}  |  {PosicoesDisplay[93]}  |  {PosicoesDisplay[94]}  |  {PosicoesDisplay[95]}  |  {PosicoesDisplay[96]}  |  {PosicoesDisplay[97]}  |  {PosicoesDisplay[98]}  | {PosicoesDisplay[99]} |");
            WriteHorizontalLine();

            Console.WriteLine($"Vez do {Vez}");
        }

        private void SetPosicaoBarcosFixo()
        {
            PosicoesBarcos[11] = PosicoesBarcos[21] = PosicoesBarcos[31] = true;
            PosicoesBarcos[80] = PosicoesBarcos[81] = PosicoesBarcos[82] = true;
            PosicoesBarcos[4] = PosicoesBarcos[5] = PosicoesBarcos[6] = true;
            PosicoesBarcos[79] = PosicoesBarcos[89] = PosicoesBarcos[99] = true;
            PosicoesBarcos[36] = PosicoesBarcos[46] = PosicoesBarcos[56] = true;
            PosicoesBarcos[62] = PosicoesBarcos[63] = true;
            PosicoesBarcos[8] = PosicoesBarcos[9] = true;
            PosicoesBarcos[87] = PosicoesBarcos[88] = true;
            PosicoesBarcos[10] = PosicoesBarcos[20] = true;
            PosicoesBarcos[39] = true;
            PosicoesBarcos[92] = true;
            PosicoesBarcos[15] = true;
            PosicoesBarcos[77] = true;
            PosicoesBarcos[0] = true;
        }

        public void LerEscolhaDoUsuario()
        {
            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoEscolhida);
            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é inválido, por favor digite um número entre 0 e 99 que esteja disponível na tabela");
                conversao = int.TryParse(Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }

        public bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            var indice = posicaoEscolhida;
            if (indice < 0 || indice > 99)
            {
                return false;
            }

            return PosicoesDisplay[indice] != "O" && PosicoesDisplay[indice] != "X" && PosicoesDisplay[indice] != "";
            

        }

        public bool PreencherEscolha(int posicaoEscolhida)
        {
            if (PosicoesBarcos[posicaoEscolhida]) //Acerto
            {
                PosicoesDisplay[posicaoEscolhida] = Vez;
                PosicoesBarcos[posicaoEscolhida] = false;
            }
            else //agua
            {
                PosicoesDisplay[posicaoEscolhida] = "";
                MudarAVez();
            }
            return true;
        }

        public void VerificarFimDoJogo()
        {
            bool first = PosicoesBarcos.FirstOrDefault(posicao => posicao.Equals(true));
            if (!first)
            {
                FimDeJogo = true;

                int pontosJogador1 = 0;
                int pontosJogador2 = 0;
                for (int i = 0; i < 100; i++)
                {
                    if (PosicoesDisplay[i].Contains("X"))
                    {
                        pontosJogador1++;   
                    }
                    else if (PosicoesDisplay[i].Contains("O" ))
                    {
                        pontosJogador2++;
                    }
                }
                Console.WriteLine($"Jogador {Jogador1.Name} acertou {pontosJogador1} alvos inimigos");
                Console.WriteLine($"Jogador {Jogador2.Name} acertou {pontosJogador2} alvos inimigos");

                if(pontosJogador1 == pontosJogador2 )
                {
                    Console.WriteLine("Jogo empatado");
                }
                else if (pontosJogador1 > pontosJogador2)
                {
                    Console.WriteLine($"Jogador {Jogador1.Name} é o vencedor");
                    Jogador1.ScoreBatalhaNaval += 1;
                }
                else
                {
                    Console.WriteLine($"Jogador {Jogador2.Name} é o vencedor");
                    Jogador2.ScoreBatalhaNaval += 1;
                }
            }
        }

        public void MudarAVez()
        {
            Vez = Vez == "X" ? "O" : "X";
        }

        private void WriteHorizontalLine()
        {
            Console.WriteLine($"______________________________________________________________________");
        }

    }
}
