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
            /*Tarefas
             * Perguntar de quantas pessoas se deseja calcular o IMC - armazenar em um array - OK
             * Implementar método para perguntar de qual pessoa deseja olhar o IMC (por nome, nome+sobrenome ou número)
             * Manter o programa em execução até que o usuário digite SAIR - OK
             * Caso o usuário digite a palavra TROCAR, programa deve permitir que ele escolha(por nome ou número, de qual pessoa deseja trocar os dados)
             * Verificar no cadastro da pessoa e na hora de trocar informações que não exista nenhum nome+sobrenome igual
             * Calcular IMC por sexo - 1/2 OK
             * Modificar mensagens ao usuário(algumas estão para apenas uma pessoa, não se aplicando ao novo modelo) - OK
             * Pesquisar e implementar tabelas de IMC para homens e para mulheres e suas diferenças - OK
             */

            //muda para cultura EUA, para utilizar ponto ao invés de vírgula
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            //criação variáveis
            string nome;
            string sobrenome;
            double peso = 0;
            double altura = 0;
            double imc = 0;
            int idade = 0;
            int quantidade = 0;
            Console.WriteLine("De quantas pessoas você deseja calcular o IMC?");
            string inputQuantidade = Console.ReadLine();
            if (int.TryParse(inputQuantidade, out quantidade) == false)
                quantidade = 0;
            while (quantidade < 1)
            {
                Console.WriteLine(Environment.NewLine + "Digite uma quantidade válida!" + Environment.NewLine);
                Console.WriteLine("De quantas pessoas você deseja calcular o IMC?");
                inputQuantidade = Console.ReadLine();
                if (int.TryParse(inputQuantidade, out quantidade) == false)
                    quantidade = 0;
            }

            ClassePessoa[] pessoas = new ClassePessoa[quantidade];

            //tabela informativa
            Console.WriteLine("                        TESTE IMC  " + Environment.NewLine);
            Console.WriteLine("       IMC              CLASSIFICAÇÃO     RISCO DE DOENÇA" + Environment.NewLine);
            Console.WriteLine("Menos de 18,5           Magreza             Elevado");
            Console.WriteLine("Entre 18,5 e 24,9       Normal	            --------");
            Console.WriteLine("Entre 25 e 29,9	        Sobrepeso	    Elevado");
            Console.WriteLine("Entre 30 e 39,9	        Obesidade	    Muito elevado");
            Console.WriteLine("Igual ou maior de 40    Obesidade grave	    Muitíssimo elevado" + Environment.NewLine);

            for (int i = 0; i < pessoas.Length; i++)
            {
                Console.WriteLine("Digite o nome da pessoa:");
                nome = Console.ReadLine();
                Console.WriteLine("Digite o sobrenome de " + nome + ":");
                sobrenome = Console.ReadLine();

                //pedir idade
                //input serve armazenar o valor inserido em uma string, para verificar se são apenas números
                //TryParse tentar converter, se não conseguir retornará como falso e substituirá por 0 (idade inválida) então entrará no while
                //Environment independente do ambiente (sistema operacional) em que ele está, criará uma nova linha
                Console.WriteLine("Insira a idade de " + nome + ":");
                string inputIdade = Console.ReadLine();
                if (int.TryParse(inputIdade, out idade) == false)
                    idade = 0;
                while (idade < 20 || idade > 65)
                {
                    Console.WriteLine(Environment.NewLine + "Este IMC é apenas para adultos entre 20 e 65 anos!" + Environment.NewLine);
                    Console.WriteLine("Insira a idade de " + nome + ":");
                    inputIdade = Console.ReadLine();
                    if (int.TryParse(inputIdade, out idade) == false)
                        idade = 0;
                }

                //while \/ enquanto a entrada for diferente de M e F
                Console.WriteLine("Insira M para masculino e F para feminino:");
                string sexo = Console.ReadLine();
                while (!sexo.ToUpper().Equals("M") && !sexo.ToUpper().Equals("F"))
                {
                    Console.WriteLine("Insira M para masculino e F para feminino:");
                    sexo = Console.ReadLine();
                }
                ClassePessoa pessoa = new ClassePessoa(idade, nome, sobrenome, sexo);
                pessoas[i] = pessoa;
                //pedir peso
                Console.WriteLine("Insira o peso de " + nome + ":");
                String inputPeso = Console.ReadLine();
                inputPeso = inputPeso.Replace(',', '.');
                if (double.TryParse(inputPeso, out peso) == false)
                    peso = 0;
                while (peso > 300 || peso < 30)
                {
                    Console.WriteLine(Environment.NewLine + "Este peso é inválido!" + Environment.NewLine);
                    Console.WriteLine("Insira o peso de " + nome + ":");
                    inputPeso = Console.ReadLine();
                    inputPeso = inputPeso.Replace(',', '.');
                    if (double.TryParse(inputPeso, out peso) == false)
                        peso = 0;
                }

                pessoas[i].Peso = peso;


                //pedir altura

                Console.WriteLine("Insira a altura de " + nome + ":");
                string inputAltura = Console.ReadLine();
                inputAltura = inputAltura.Replace(',', '.');
                if (double.TryParse(inputAltura, out altura) == false)
                    altura = 0;
                while (altura > 2.8 || altura < 1)
                {
                    Console.WriteLine(Environment.NewLine + "Esta altura é inválida!" + Environment.NewLine);
                    Console.WriteLine("Insira a altura de " + nome + ":");
                    inputAltura = Console.ReadLine();
                    inputAltura = inputAltura.Replace(',', '.');
                    if (double.TryParse(inputAltura, out altura) == false)
                        altura = 0;
                }
                pessoas[i].Altura = altura;
            }
            for (int i = 0; i < pessoas.Length; i++)
            {
                imc = pessoas[i].CalculaIMC();
                Console.Write("O IMC de " + pessoas[i].Nome + " " + pessoas[i].Sobrenome + " ");
                Console.WriteLine(MensagemIMC(imc));
            }

            // comando = "" inicializa a variável
            // ToUpper passa para caixa alta
            // Equals serve para comparar strings
            // ! = diferente
            string comando = "";
            while (!comando.ToUpper().Equals("SAIR"))
            {
                Console.WriteLine("Insira a palavra mágica:");
                comando = Console.ReadLine().ToUpper();

                if (comando.Equals("RESULTADOS"))

                {
                    for (int i = 0; i < pessoas.Length; i++)
                    {
                        imc = pessoas[i].CalculaIMC();

                        Console.Write("O IMC de " + pessoas[i].Nome + " " + pessoas[i].Sobrenome);
                        Console.WriteLine(MensagemIMC(imc));
                    }
                }
                else if (comando.Equals("TROCAR"))
                {

                }
                else if (comando.Equals("SAIR"))
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "Comando inválido!" + Environment.NewLine);
                }
            }
        }
        public static string MensagemIMC(double imc)
        {
            if (imc < 18.5)
                return (" é: " + imc + " ele indica Magreza");
            else if (imc <= 24.9)
                return (" é: " + imc + " ele indica estar Normal");
            else if (imc <= 29.9)
                return (" é: " + imc + " ele indica Sobrepeso");
            else if (imc <= 39.9)
                return (" é: " + imc + " ele indica Obesidade");
            else
                return (" é: " + imc + " ele indica Obesidade Grave");
        }
    }
}
