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
            int idade = 0;

            //tabela informativa
            Console.WriteLine("                        TESTE IMC  " + Environment.NewLine);
            Console.WriteLine("       IMC              CLASSIFICAÇÃO     RISCO DE DOENÇA" + Environment.NewLine);
            Console.WriteLine("Menos de 18,5           Magreza             Elevado");
            Console.WriteLine("Entre 18,5 e 24,9       Normal	            --------");
            Console.WriteLine("Entre 25 e 29,9	        Sobrepeso	    Elevado");
            Console.WriteLine("Entre 30 e 39,9	        Obesidade	    Muito elevado");
            Console.WriteLine("Igual ou maior de 40    Obesidade grave	    Muitíssimo elevado" + Environment.NewLine);

            //pedir idade
            Console.WriteLine("Insira sua idade:");
            string inputIdade = Console.ReadLine();
            if (int.TryParse(inputIdade, out idade) == false)
                idade = 0;
            while (idade < 20 || idade > 65)
            {
                Console.WriteLine(Environment.NewLine + "Este IMC é apenas para adultos entre 20 e 65 anos!" + Environment.NewLine);
                Console.WriteLine("Insira sua idade:");
                inputIdade = Console.ReadLine();
                if (int.TryParse(inputIdade, out idade) == false)
                    idade = 0;
            }

            //pedir peso
            Console.WriteLine("Insira o seu peso:");
            String inputPeso = Console.ReadLine();
            inputPeso = inputPeso.Replace(',', '.');
            if (double.TryParse(inputPeso, out peso) == false)
                peso = 0;
            while (peso > 300 || peso < 30)
            {
                Console.WriteLine(Environment.NewLine + "Seu peso é inválido!" + Environment.NewLine);
                Console.WriteLine("Insira o seu peso:");
                inputPeso = Console.ReadLine();
                inputPeso = inputPeso.Replace(',', '.');
                if (double.TryParse(inputPeso, out peso) == false)
                    peso = 0;
            }

            


            //pedir altura

            Console.WriteLine("Insira sua altura");
            string inputAltura = Console.ReadLine();
            inputAltura = inputAltura.Replace(',', '.');
            if (double.TryParse(inputAltura, out altura) == false)
                altura = 0;
   
            while (altura > 2.8 || altura < 1)
            {
                Console.WriteLine(Environment.NewLine + "Sua altura é inválida!" + Environment.NewLine);
                Console.WriteLine("Insira sua altura");
                inputAltura = Console.ReadLine();
                inputAltura = inputAltura.Replace(',', '.');
                if (double.TryParse(inputAltura, out altura) == false)
                    altura = 0;
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
