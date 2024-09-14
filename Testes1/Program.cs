using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Testes1
{
    internal class Program
    {
        bool pBlock;
        bool eBlock;
        int eHP;
        int pHP;
        int eDMG;
        int pDMG;
        int turn;

        static void SendInitMessage()
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("Testes 1");
            Console.WriteLine("'Combate'");
            Console.WriteLine("=========================================================");
        }
        static bool GetFinalKey()
        {
            Console.WriteLine("Caso deseja encerrar o programa pressione qualquer tecla.");
            Console.WriteLine("Pressione R para recomeçar o combate.");

            escolha = char.Parse(Console.ReadLine());

            return escolha;
        }
        static void PrintEnemyStatus()
        {
            Console.WriteLine("Inimigo teste");
            Console.WriteLine("{0} HP", this.eHP);
            Console.WriteLine("{0} Dano", this.eDMG);
            Console.WriteLine("");
        }
        static void PrintPlayerStatus()
        {

            Console.WriteLine("Player beta");
            Console.WriteLine("{0} HP", this.pHP);
            Console.WriteLine("{0} Dano", this.pDMG);
            Console.WriteLine("Atacar (A)");
            Console.WriteLine("Curar (S)");
            Console.WriteLine("Defender (D)");
        }
        static void AvaliatePlayerAction(string pAction)
        {
            switch (char.Parse(pAction))
            {
                case 'A':
                case 'a':
                    if (this.eBlock == true)
                    {
                        Console.WriteLine("Seu inimigo se defendeu!");
                        this.eHP = this.eHP - (this.pDMG - 2);
                        this.eBlock = false;
                    }
                    else
                    {
                        Console.WriteLine("Seu ataque causou {0} de dano!", this.pDMG);
                        this.eHP = this.eHP - this.pDMG;
                    }
                    break;

                case 'S':
                case 's':
                    if (this.pHP >= 20)
                    {
                        Console.WriteLine("Vida já está cheia!");
                    }
                    else
                    {
                        Console.WriteLine("Curou 1 de vida!");
                        this.pHP++;
                    }
                    break;

                case 'D':
                case 'd':
                    Console.WriteLine("Você levanta sua guarda!");
                    this.pBlock = true;
                    break;

                default:
                    Console.WriteLine("Ação inválida");
                    break;
            }
        }
        static void AvaliateEnemyStatus(int eAction)
        {
            switch (eAction)
            {
                case 0:
                    Console.WriteLine("Inimigo teste o atacou!");
                    if (this.pBlock == true)
                    {
                        Console.WriteLine("Você consegue se defender com sucesso!");
                        this.pHP = this.pHP - (this.eDMG - 2);
                        Console.WriteLine("Você sofreu {0} de dano!", this.eDMG - 2);
                        this.pBlock = false;
                    }
                    else
                    {
                        Console.WriteLine("Você recebeu {0} de dano!", this.eDMG);
                        this.pHP = this.pHP - this.eDMG;
                    }
                    break;

                case 1:
                    if (this.eHP >= 20)
                    {
                        Console.WriteLine("Seu inimigo tentou se curar, mas já estava de vida cheia.");
                    }
                    else
                    {
                        Console.WriteLine("Seu inimigo se curou!");
                        this.eHP++;
                    }
                    break;

                case 2:
                    Console.WriteLine("Seu inimigo levanta sua guarda!");
                    this.eBlock = true;
                    break;
            }
        }
        static void Main(string[] args)
        {
            bool initCombat = true;
            Random rng = new Random();

            SendInitMessage();

            while (initCombat)
            {
                this.pBlock = false;
                this.eBlock = false;
                this.eHP = 20;
                this.pHP = 20;
                this.eDMG = 2;
                this.pDMG = 3;
                this.turn = rng.Next(2); // Só pode ser 0 e 1

                while (true)
                {
                    Console.Clear();
                    char pAction;
                    int eAction = rng.Next(3); // Pode ser 0, 1 e 2

                    if (this.eHP <= 0 || this.pHP <= 0)
                    {
                        string mensagem;

                        Console.WriteLine("Combate encerrado.");
                        mensagem =
                        this.eHP <= 0 ? "Você venceu!" : "Você perdeu...";
                        Console.WriteLine(mensagem);

                        break;
                    }

                    if (this.turn == 0)
                    {
                        this.eBlock = false;
                        PrintEnemyStatus();

                        AvaliateEnemyStatus(eAction);

                        Console.ReadKey();
                        this.turn = 1;

                        continue;
                    }
                    else
                    {
                        this.pBlock = false;
                        PrintPlayerStatus();

                        string pAction = Console.ReadLine();

                        if (pAction == null)
                        {
                            Console.WriteLine("Ação inválida");
                            continue; // antigo goto
                        }

                        AvaliatePlayerAction(pAction);

                        Console.ReadKey();
                        this.turn = 0;

                        continue;
                    }
                }

                char escolha = GetFinalKey();
                if (escolha.ToLower() != 'r')
                {
                    initCombat = false;
                }
            }

            Console.WriteLine("Programa encerrado.");
            Console.WriteLine("Pressione qualquer tecla para fechar.");
            Console.WriteLine("");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
