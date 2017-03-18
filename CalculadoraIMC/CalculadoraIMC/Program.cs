using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalculadoraIMC
{
    class Program
    {

        static void hrhrh()
        {
            int[] x = { 1, 2, 3, 4, 5 };

            try
            {
                for (int o = 0; o < 6; o++)
                {
                    Console.WriteLine(x[o] + Environment.NewLine);
                }
            }
            catch (IndexOutOfRangeException ix)
            {
                Console.WriteLine("O salario nãopode ser aumentado, faça manumente");
                // despafaeraumento();
            }
            catch (Exception ex)
            {
            }

            var bananai = 0;
            while (bananai < 5)
            {
                Console.WriteLine(x[bananai] + Environment.NewLine);
                bananai++;
            }
        }


        public static void Main(string[] args)
        {
            hrhrh();
            Console.ReadLine();
            return;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); //muda para cultura EUA, para utilizar ponto ao invés de vírgula

            //criação variáveis
            double peso;
            double altura;
            double imc;

            //tabela informativa
            Console.WriteLine("                        TESTE IMC  " + Environment.NewLine);
            //Console.WriteLine("");
            Console.WriteLine("       IMC              CLASSIFICAÇÃO     RISCO DE DOENÇA" + Environment.NewLine);
            //Console.WriteLine("");
            Console.WriteLine("Menos de 18,5           Magreza             Elevado");
            Console.WriteLine("Entre 18,5 e 24,9       Normal	            --------");
            Console.WriteLine("Entre 25 e 29,9	        Sobrepeso	    Elevado");
            Console.WriteLine("Entre 30 e 39,9	        Obesidade	    Muito elevado");
            Console.WriteLine("Igual ou maior de 40    Obesidade grave	    Muitíssimo elevado" + Environment.NewLine);
            //Console.WriteLine("");

            //pedir peso
            Console.WriteLine("Insira o seu peso:");
            peso = Convert.ToDouble(Console.ReadLine());

            if (peso > 300 || peso < 30) //verifica se o peso é inválido
            {
                Console.WriteLine("Seu peso é inválido");
                Console.ReadLine();
                return;
            }

            //pedir altura
            Console.WriteLine("Insira sua altura");
            altura = Convert.ToDouble(Console.ReadLine());

            if (altura > 3.0 || altura < 1.20) //verifica se a altura é inválida
            {
                Console.WriteLine("Sua altura é inválida");
                Console.ReadLine();
                return;
            }

            //calculo do IMC
            imc = peso / (altura * altura);

            //arredondar IMC para uma casa decimal
            imc = Math.Round(imc, 1); //imc recebe imc com 1 casa decimal só

            //testes IMC
            if (imc < 18.5)
                Console.WriteLine("Seu IMC é: " + imc + " ele indica Magreza");
            else if (imc <= 24.9)
                Console.WriteLine("Seu IMC é: " + imc + " ele indica estar Normal");
            else if (imc <= 29.9)
                Console.WriteLine("Seu IMC é: " + imc + " ele indica Sobrepeso");
            else if (imc <= 39.9)
                Console.WriteLine("Seu IMC é: " + imc + " ele indica Obesidade");
            else
                Console.WriteLine("Seu IMC é: " + imc + " ele indica Obesidade Grave");

            Console.ReadLine();
            return;

        }
    }
}
