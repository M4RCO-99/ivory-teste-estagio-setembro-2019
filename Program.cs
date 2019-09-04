using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nome_na_matriz
{
    struct elementos // Criação de um tipo para compor a matriz
    {
        //O tipo elemento possui um tipo int e um tipo char
        public int n;
        public char c;
    }

    class Program
    {
        static elementos[,] FazMatriz(elementos[,] matriz, string nome, char[] letras, int x) // Função para criar e retornar matriz
        {
            int l = 0;   // l é a váriavel responsável para percorrer o vetor letras

            int y;

            y = x + x + 1;

            for (int k = 0; k < 3; k++)
            {
                for (int i = 0; i < x; i++)
                {
                    if (k == 0)   // responsável em indexar os números da primeira linha
                        matriz[i, k].n = (i + 1);
                    else if (k == 1)   //responsável em indexar as letras e os números da sugunda linha
                    {
                        if (i > 0 && i < (nome.Length + 1)) // responsavel em indexar as letras da segunda linha
                        {
                            matriz[i, k].c = letras[l];
                            l++;
                        }
                        else if (i == 0)   // responsável em indexar o primeiro número da segunda linha
                            matriz[i, k].n = y + 1;
                        else   // responsável em indexar o ultimo número da segunda linha
                            matriz[i, k].n = x + 1;
                    }
                    else   // responsável em indexar os números da terceira linha
                    {
                        matriz[i, k].n = y;
                        y--;
                    }
                }
            }
            return matriz;
        }

        static void MostraMatriz(elementos[,] matriz, int x) // Procedimento para mostra ao usuário a matriz criada 
        {
            for (int k = 0; k < 3; k++)
            {
                for (int i = 0; i < x; i++)
                {
                    if (matriz[i, k].n != 0)
                        Console.Write("   {0:00}   ", matriz[i, k].n);
                    else
                        Console.Write("    {0}   ", matriz[i, k].c);
                }
                Console.WriteLine("\n");
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            string nome;
            int x;

            Console.WriteLine("Informe um nome: ");
            nome = Console.ReadLine();

            x = nome.Length + 2; // número de colunas em uma linha ("comprimento da linha")

            char[] letras = nome.ToCharArray(); // converter o nome dado em string para char

            elementos[,] matriz = new elementos[x, 3];

            FazMatriz(matriz, nome, letras, x);

            Console.Clear();

            MostraMatriz(matriz, x);
        }
    }
}
