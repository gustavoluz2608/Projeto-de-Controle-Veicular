using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp13
{
    internal class Program
    {
        static StreamReader arq_entrada = new StreamReader("entrada.txt");
        static StreamWriter arq_saida = new StreamWriter("saida.txt");


        static void mostraDadosCarros(string[,] dados, int ano)
        {
            string [] tags = { "Placa: ", "Modelo: ", "Ano do carro: ", "Proprietário: ", "Horas estacionadas: " };
            for (int i = 0; i < dados.GetLength(0); i++)
            {
                if (Convert.ToInt16(dados[i, 2]) == ano)
                {
                    for (int j = 0; j < dados.GetLength(1); j++)
                    {
                        arq_saida.WriteLine(dados[i, j]);
                        Console.Write(tags[j]);
                        Console.WriteLine(dados[i, j]);
                    }
                }

            }
        }

        static int determineMaisNovo(string[,] dados, int j)
        {
            int anoMaisNovo = Convert.ToInt16(dados[0, j]);


            for (int i = 1; i < dados.GetLength(0); i++)
            {
                if (anoMaisNovo < Convert.ToInt16(dados[i, j]))
                {
                    anoMaisNovo = Convert.ToInt16(dados[i, j]);
                }
            }

            return anoMaisNovo;
        }

        static int determineMaisAntigo(string[,] dados, int j)
        {
            int anoMaisAntigo = Convert.ToInt16(dados[0, j]);


            for (int i = 1; i < dados.GetLength(0); i++)
            {
                if (anoMaisAntigo > Convert.ToInt16(dados[i, j]))
                {
                    anoMaisAntigo = Convert.ToInt16(dados[i, j]);
                }
            }

            return anoMaisAntigo;
        }

        static float mediaIdade(string[,] dados, int j)
        {
            float media, mediaAno;
            int soma = 0;

            for (int i = 0; i < dados.GetLength(0); i++)
            {
                soma = soma + Convert.ToInt16(dados[i, j]);
            }

            media = soma / dados.GetLength(0);

            mediaAno = 2022 - media;

            return mediaAno;
        }

        static float montanteTotal(string[,] dados, int j, float valorHora)
        {
            float qtndHoras = 0, montante;

            for (int i = 0; i < dados.GetLength(0); i++)
            {
                qtndHoras = qtndHoras + Convert.ToInt16(dados[i, j]);
            }

            montante = qtndHoras * valorHora;

            return montante;
        }
        static string[,] leiaDados(int num_veiculos)
        {
            string[,] dados = new string[num_veiculos, 5];

            for (int i = 0; i < num_veiculos; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    dados[i, j] = arq_entrada.ReadLine();
                }
            }
            return dados;
        }

        static int leiaNumVeiculos()
        {
            int num;

            num = int.Parse(arq_entrada.ReadLine());

            return num;
        }

        static float leiaValorHora()
        {
            float valor;

            valor = float.Parse(arq_entrada.ReadLine());

            return valor;
        }
        static string leiaNome()
        {
            string nome;

            nome = arq_entrada.ReadLine();

            return nome;
        }

        static void Main(string[] args)
        {
            string[,] dados;
            string nome;
            int numVeiculos, anoMaisAntigo, anoMaisNovo;
            float valorHora, montante, valor_medio, media_idade;


            nome = leiaNome();
            Console.WriteLine(nome);
            arq_saida.WriteLine(nome);

            valorHora = leiaValorHora();
            Console.WriteLine(valorHora);
            arq_saida.WriteLine(valorHora);

            numVeiculos = leiaNumVeiculos();
            Console.WriteLine(numVeiculos);
            arq_saida.WriteLine(numVeiculos);

            dados = leiaDados(numVeiculos);

            montante = montanteTotal(dados, 3, valorHora);
            Console.WriteLine(montante);
            arq_saida.WriteLine(montante);

            valor_medio = montante / numVeiculos;
            Console.WriteLine(valor_medio);
            arq_saida.WriteLine(valor_medio);

            media_idade = mediaIdade(dados, 2);
            Console.WriteLine(media_idade);
            arq_saida.WriteLine(media_idade);

            anoMaisAntigo = determineMaisAntigo(dados, 2);
            mostraDadosCarros(dados, anoMaisAntigo);

            anoMaisNovo = determineMaisNovo(dados, 2);
            mostraDadosCarros(dados, anoMaisNovo);



            arq_entrada.Close();
            arq_saida.Close();

            Console.ReadKey();



        }
    }
}
