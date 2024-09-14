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
        static void Main(string[] args)
        {
            Random rng = new Random();
            char escolha;

            Console.WriteLine("=========================================================");
            Console.WriteLine("Testes 1");
            Console.WriteLine("'Combate'");
            Console.WriteLine("=========================================================");

        inicio:

            int eHP, pHP, eDMG, pDMG;
            bool pBlock = false;
            bool eBlock = false;
            eHP = int.Parse("20");
            pHP = int.Parse("20");
            eDMG = int.Parse("2");
            pDMG = int.Parse("3");
            int turn = rng.Next(2); // Só pode ser 0 e 1

        iCombate:
            Console.Clear();
            char pAction;
            int eAction = rng.Next(3); // Pode ser 0, 1 e 2

            if (eHP <= 0 || pHP <= 0)
            {
                string mensagem;

                Console.WriteLine("Combate encerrado.");
                mensagem =
                eHP <= 0 ? "Você venceu!" : "Você perdeu...";
                Console.WriteLine(mensagem);
            }
            else
            {
                if (turn == 0)
                {
                    eBlock = false;
                    Console.WriteLine("Inimigo teste");
                    Console.WriteLine("{0} HP", eHP);
                    Console.WriteLine("{0} Dano", eDMG);
                    Console.WriteLine("");

                    switch (eAction)
                    {
                        case 0:
                            Console.WriteLine("Inimigo teste o atacou!");
                            if (pBlock == true)
                            {
                                Console.WriteLine("Você consegue se defender com sucesso!");
                                pHP = pHP - (eDMG - 2);
                                Console.WriteLine("Você sofreu {0} de dano!", eDMG - 2);
                                pBlock = false;
                            }
                            else
                            {
                                Console.WriteLine("Você recebeu {0} de dano!", eDMG);
                                pHP = pHP - eDMG;
                            }
                            break;

                        case 1:
                            if (eHP >= 20)
                            {
                                Console.WriteLine("Seu inimigo tentou se curar, mas já estava de vida cheia.");
                            }
                            else
                            {
                                Console.WriteLine("Seu inimigo se curou!");
                                eHP++;
                            }
                            break;

                        case 2:
                            Console.WriteLine("Seu inimigo levanta sua guarda!");
                            eBlock = true;
                            break;
                    }
                    Console.ReadKey();
                    turn = 1;
                    goto iCombate;
                }
                else
                {
                    pBlock = false;
                    Console.WriteLine("Player beta");
                    Console.WriteLine("{0} HP", pHP);
                    Console.WriteLine("{0} Dano", pDMG);
                    Console.WriteLine("Atacar (A)");
                    Console.WriteLine("Curar (S)");
                    Console.WriteLine("Defender (D)");

                    pAction = char.Parse(Console.ReadLine());

                    switch (pAction)
                    {
                        case 'A':
                        case 'a':
                            if (eBlock == true)
                            {
                                Console.WriteLine("Seu inimigo se defendeu!");
                                eHP = eHP - (pDMG - 2);
                                eBlock = false;
                            }
                            else
                            {
                                Console.WriteLine("Seu ataque causou {0} de dano!", pDMG);
                                eHP = eHP - pDMG;
                            }
                            break;

                        case 'S':
                        case 's':
                            if (pHP >= 20)
                            {
                                Console.WriteLine("Vida já está cheia!");
                            }
                            else
                            {
                                Console.WriteLine("Curou 1 de vida!");
                                pHP++;
                            }
                            break;

                        case 'D':
                        case 'd':
                            Console.WriteLine("Você levanta sua guarda!");
                            pBlock = true;
                            break;

                        default:
                            Console.WriteLine("Ação inválida");
                            break;
                    }
                    Console.ReadKey();
                    turn = 0;
                    goto iCombate;
                }

            }
            Console.WriteLine("Caso deseja encerrar o programa pressione qualquer tecla.");
            Console.WriteLine("Pressione R para recomeçar o combate.");
            escolha = char.Parse(Console.ReadLine());
            if (escolha == 'r' || escolha == 'R')
            {
                goto inicio;
            }
            else
            {
                Console.WriteLine("Programa encerrado.");
                Console.WriteLine("Pressione qualquer tecla para fechar.");
                Console.WriteLine("");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
