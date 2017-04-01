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

            //muda para cultura EUA, para utilizar ponto ao invés de vírgula
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            //criação variáveis
            double peso=0;
            double altura=0;
            double imc=0;
            int idade = 0;
            ClassePessoa[] pessoas= new ClassePessoa[2];
            
            //tabela informativa
            Console.WriteLine("                        TESTE IMC  " + Environment.NewLine);
            Console.WriteLine("       IMC              CLASSIFICAÇÃO     RISCO DE DOENÇA" + Environment.NewLine);
            Console.WriteLine("Menos de 18,5           Magreza             Elevado");
            Console.WriteLine("Entre 18,5 e 24,9       Normal	            --------");
            Console.WriteLine("Entre 25 e 29,9	        Sobrepeso	    Elevado");
            Console.WriteLine("Entre 30 e 39,9	        Obesidade	    Muito elevado");
            Console.WriteLine("Igual ou maior de 40    Obesidade grave	    Muitíssimo elevado" + Environment.NewLine);

            //pedir idade
            //input serve armazenar o valor inserido em uma string, para verificar se são apenas números
            //TryParse tentar converter, se não conseguir retornará como falso e substituirá por 0 (idade inválida) então entrará no while
            //Environment independente do ambiente (sistema operacional) em que ele está, criará uma nova linha
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
            ClassePessoa pessoa = new ClassePessoa(idade);
            pessoas[0] = pessoa;
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

            pessoa.Peso = peso;


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
            pessoa.Altura = altura;

            //calculo do IMC
            imc = pessoa.CalculaIMC();

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
            //perguntar quantas pessoas deseja calcular - array
            //metodo para pedir qual pessoa olhar o imc
            //prog não acaba
            //até caracter especial
            //fechar aplicação
            //windows Forms
            //possibilidade de digitar a possibilidade de digitar TROCAR
            //pedir dados da pessoa da qual eu desejo substituir pelo nome da pessoa
            //não possuir dois João
            //por sexo


        }
    }
}
