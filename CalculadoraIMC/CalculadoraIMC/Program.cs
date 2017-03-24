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

      

        public static void Main(string[] args)
        {
           
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); //muda para cultura EUA, para utilizar ponto ao invés de vírgula

            //criação variáveis
            double peso=0;
            double altura=0;
            double imc=0;

            //tabela informativa
            Console.WriteLine("                        TESTE IMC  " + Environment.NewLine);
            Console.WriteLine("       IMC              CLASSIFICAÇÃO     RISCO DE DOENÇA" + Environment.NewLine);
            Console.WriteLine("Menos de 18,5           Magreza             Elevado");
            Console.WriteLine("Entre 18,5 e 24,9       Normal	            --------");
            Console.WriteLine("Entre 25 e 29,9	        Sobrepeso	    Elevado");
            Console.WriteLine("Entre 30 e 39,9	        Obesidade	    Muito elevado");
            Console.WriteLine("Igual ou maior de 40    Obesidade grave	    Muitíssimo elevado" + Environment.NewLine);

            //pedir peso
            Console.WriteLine("Insira o seu peso:");
            peso = Convert.ToDouble(Console.ReadLine());
            while (peso > 300 || peso < 30)
            {
                Console.WriteLine(Environment.NewLine + "Mensagem de erro" + Environment.NewLine);
                Console.WriteLine("Insira o seu peso:");
                peso = Convert.ToDouble(Console.ReadLine());
            }




            //pedir altura

            Console.WriteLine("Insira sua altura");
            altura = Convert.ToDouble(Console.ReadLine());
            while (altura > 3.0 || altura < 1.20)
            {
                Console.WriteLine(Environment.NewLine + "Mensagem de erro" + Environment.NewLine);
                Console.WriteLine("Insira sua altura");
                altura = Convert.ToDouble(Console.ReadLine());
                
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
