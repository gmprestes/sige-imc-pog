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
            string nome = "";
            string sobrenome = "";
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
            Console.WriteLine("                         TABELA IMC MASCULINA " + Environment.NewLine);
            Console.WriteLine(">----------------------------------------------------------------------<" + Environment.NewLine);
            Console.WriteLine("       IMC           |     CLASSIFICAÇÃO     |    RISCO DE DOENÇA" + Environment.NewLine);
            Console.WriteLine(">------------------- | ------------------    | ------------------------<    " + Environment.NewLine);
            Console.WriteLine("Menos de 17,9        |     Magreza  grave    |    Elevado");
            Console.WriteLine("Entre 17,9 e 18,     |     Magreza           |    Elevado");
            Console.WriteLine("Entre 19 e 24,9      |     Normal	     |    Sem Risco");
            Console.WriteLine("Entre 25 e 27,7      |     Sobrepeso	     |    Elevado");
            Console.WriteLine("Entre 30 e 39,9	     |     Obesidade	     |    Muito elevado");
            Console.WriteLine("Igual ou maior de 40 |     Obesidade grave   |    Muitíssimo elevado" + Environment.NewLine);

            //tabela informativa
            Console.WriteLine("                         TABELA IMC FEMININA " + Environment.NewLine);
            Console.WriteLine(">----------------------------------------------------------------------<" + Environment.NewLine);
            Console.WriteLine("       IMC           |     CLASSIFICAÇÃO     |    RISCO DE DOENÇA" + Environment.NewLine);
            Console.WriteLine(">------------------- | ------------------    | ------------------------<    " + Environment.NewLine);
            Console.WriteLine("Menos de 15          |     Magreza grave     |    Elevado");
            Console.WriteLine("Entre 15 e 17,9      |     Magreza           |    Elevado");
            Console.WriteLine("Entre 18 e 24,4      |     Normal	     |    Sem Risco");
            Console.WriteLine("Entre 24,5 e 27,2    |     Sobrepeso	     |    Elevado");
            Console.WriteLine("Entre 30 e 39,9	     |     Obesidade	     |    Muito elevado");
            Console.WriteLine("Igual ou maior de 40 |     Obesidade grave   |    Muitíssimo elevado" + Environment.NewLine);

            for (int i = 0; i < pessoas.Length; i++)
            {
                CadastrarPessoa(pessoas, i);
            }
            for (int i = 0; i < pessoas.Length; i++)
            {
                imc = pessoas[i].CalculaIMC();
                Console.Write(Environment.NewLine + "O IMC de " + pessoas[i].Nome + " " + pessoas[i].Sobrenome + " ");
                Console.WriteLine(MensagemIMC(imc, pessoas[i].Sexo));
            }

            // comando = "" inicializa a variável
            // ToUpper passa para caixa alta
            // Equals serve para comparar strings
            // ! = diferente
            string comando = "";
            while (!comando.ToUpper().Equals("SAIR"))
            {
                Console.WriteLine(Environment.NewLine + " MENU DE OPÇÕES      |           AJUDA                       ");
                Console.WriteLine(Environment.NewLine + ">--------------------| -----------------------------------------------------------<");
                Console.WriteLine(Environment.NewLine + "       Resultados    |   para visualizar os resultados das pessoas informadas.");
                Console.WriteLine("       Pesquisar     |   para realizar pesquisa por pessoa informada.  ");
                Console.WriteLine("       Trocar        |   para trocar dados de pessoa informada. ");
                Console.WriteLine("       Sair          |   para encerrar o programa.");
                Console.WriteLine(Environment.NewLine + " >-------------------|------------------------------------------------------------<");
                Console.WriteLine("Informe a opção: ");
                comando = Console.ReadLine().ToUpper();
                if (comando.Equals("RESULTADOS"))
                {
                    for (int i = 0; i < pessoas.Length; i++)
                    {
                        imc = pessoas[i].CalculaIMC();
                        Console.Write(Environment.NewLine + "O IMC de " + pessoas[i].Nome + " " + pessoas[i].Sobrenome);
                        Console.WriteLine(MensagemIMC(imc, pessoas[i].Sexo));
                    }
                }
                else if (comando.Equals("TROCAR"))
                {
                    Console.WriteLine("Informe o nome da pessoa que deseja trocar:");
                    string pesquisa = Console.ReadLine();
                    int posicao = PesquisaPessoa(pesquisa, pessoas);
                    if (posicao == -1)
                    {
                        Console.WriteLine("Não encontrado");
                    }
                    else
                    {
                        CadastrarPessoa(pessoas, posicao);
                    }
                }
                else if (comando.Equals("PESQUISAR"))
                {
                    Console.WriteLine("Digite o nome da pessoa que deseja pesquisar:");
                    string pesquisa = Console.ReadLine();
                    int posicao = PesquisaPessoa(pesquisa, pessoas);
                    if (posicao == -1)
                    {
                        Console.WriteLine("Não encontrado");
                    }
                    else
                    {
                        Console.WriteLine("Nome: " + pessoas[posicao].Nome);
                        Console.WriteLine("Sobrenome: " + pessoas[posicao].Sobrenome);
                        Console.WriteLine("Idade: " + pessoas[posicao].Idade);
                        Console.WriteLine("Sexo: " + pessoas[posicao].Sexo);
                        Console.WriteLine("Peso: " + pessoas[posicao].Peso);
                        Console.WriteLine("Altura: " + pessoas[posicao].Altura);
                        Console.WriteLine("IMC : " + pessoas[posicao].CalculaIMC());
                    }
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

        public static string MensagemIMC(double imc, string sexo)
        {
            if (sexo.Equals("M"))
            {
                if (imc < 17.9)
                    return (" é: " + imc + " ele indica Magreza Grave");
                else if (imc <= 18.9)
                    return (" é: " + imc + " ele indica estar Magreza");
                else if (imc <= 24.9)
                    return (" é: " + imc + " ele indica Normal");
                else if (imc <= 27.7)
                    return (" é: " + imc + " ele indica Obesidade");
                else if (imc <= 27.8)
                    return (" é: " + imc + " ele indica Obesidade");
                else
                    return (" é: " + imc + " ele indica Obesidade Grave");
            }
            else
            {
                if (imc < 15)
                    return (" é: " + imc + " ele indica Magreza Grave");
                else if (imc <= 17.9)
                    return (" é: " + imc + " ele indica estar Magreza");
                else if (imc <= 24.4)
                    return (" é: " + imc + " ele indica estar Normal");
                else if (imc <= 27.2)
                    return (" é: " + imc + " ele indica Sobrepeso");
                else if (imc <= 27.3)
                    return (" é: " + imc + " ele indica Obesidade");
                else
                    return (" é: " + imc + " ele indica Obesidade Grave");
            }
        }

        public static int PesquisaPessoa(string pesquisa, ClassePessoa[] pessoas)
        {
            pesquisa = pesquisa.ToUpper();
            List<int> pessoasEncontradas = new List<int>();
            for (int i = 0; i < pessoas.Length; i++)
            {
                if (pessoas[i].Nome.ToUpper().Contains(pesquisa))
                {
                    if (!pessoasEncontradas.Contains(i))
                        pessoasEncontradas.Add(i);
                }
                else if ((pessoas[i].Nome.ToUpper() + " " + pessoas[i].Sobrenome.ToUpper()).Contains(pesquisa))
                {
                    if (!pessoasEncontradas.Contains(i))
                        pessoasEncontradas.Add(i);
                }
                else if (i.ToString().Contains(pesquisa))
                {
                    if (!pessoasEncontradas.Contains(i))
                        pessoasEncontradas.Add(i);
                }
            }
            if (pessoasEncontradas.Count == 0)
            {
                return -1;
            }
            else if (pessoasEncontradas.Count == 1)
            {
                return (pessoasEncontradas[0]);
            }
            else
            {
                Console.WriteLine("Existe mais uma pessoa com esse nome:");
                foreach (int posicao in pessoasEncontradas)
                {
                    Console.WriteLine("Posição: " + posicao + "| Nome: " + pessoas[posicao].Nome);
                }
                int posicaoEscolhida=0;
                bool valido = false;
                while (!valido)
                {
                    Console.WriteLine("Digite o número da pessoa que deseja escolher:");
                    posicaoEscolhida = Convert.ToInt16(Console.ReadLine());
                    if (pessoasEncontradas.Contains(posicaoEscolhida)){
                        valido = true;
                    }
                }
                

                return (posicaoEscolhida);
            }
        }

        public static void CadastrarPessoa(ClassePessoa[] pessoas, int posicao)
        {
            string nome = "";
            string sobrenome = "";
            double peso = 0;
            double altura = 0;
            int idade = 0;
            bool nomeIgual = true;
            while (nomeIgual)
            {
                nomeIgual = false;
                Console.WriteLine("Digite o nome da pessoa: ");
                nome = Console.ReadLine();
                Console.WriteLine("Digite o sobrenome de " + nome + ":");
                sobrenome = Console.ReadLine();
                for (int j = 0; j < pessoas.Length; j++)
                {
                    if (pessoas[j] == null) ;
                    else if (pessoas[j].Nome.Equals(nome) && pessoas[j].Sobrenome.Equals(sobrenome))
                    {
                        nomeIgual = true;
                        Console.WriteLine(Environment.NewLine + "Essa pessoa ja foi cadastrada " + Environment.NewLine);
                    }
                }
            }
            Console.WriteLine("Insira a idade de " + nome + " " + sobrenome + ":");
            string inputIdade = Console.ReadLine();
            if (int.TryParse(inputIdade, out idade) == false)
                idade = 0;
            while (idade < 20 || idade > 65)
            {
                Console.WriteLine(Environment.NewLine + "Este IMC é apenas para adultos entre 20 e 65 anos!" + Environment.NewLine);
                Console.WriteLine("Insira a idade de " + nome + " " + sobrenome + ":");
                inputIdade = Console.ReadLine();
                if (int.TryParse(inputIdade, out idade) == false)
                    idade = 0;
            }
            Console.WriteLine("Informe o sexo de " + nome + " " + sobrenome + " (M para masculino e F para feminino):");
            string sexo = Console.ReadLine();
            while (!sexo.ToUpper().Equals("M") && !sexo.ToUpper().Equals("F"))
            {
                Console.WriteLine("Informe o sexo de " + nome + " " + sobrenome + " (M para masculino e F para feminino):");
                sexo = Console.ReadLine();
            }
            ClassePessoa pessoa = new ClassePessoa(idade, nome, sobrenome, sexo);
            pessoas[posicao] = pessoa;
            Console.WriteLine("Insira o peso de " + nome + " " + sobrenome + ":");
            string inputPeso = Console.ReadLine();
            inputPeso = inputPeso.Replace(',', '.');
            if (double.TryParse(inputPeso, out peso) == false)
                peso = 0;
            while (peso > 300 || peso < 30)
            {
                Console.WriteLine(Environment.NewLine + "Este peso é inválido!" + Environment.NewLine);
                Console.WriteLine("Insira o peso de " + nome + " " + sobrenome + ":");
                inputPeso = Console.ReadLine();
                inputPeso = inputPeso.Replace(',', '.');
                if (double.TryParse(inputPeso, out peso) == false)
                    peso = 0;
            }
            pessoas[posicao].Peso = peso;
            Console.WriteLine("Insira a altura de " + nome + " " + sobrenome + ":");
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
            pessoas[posicao].Altura = altura;
        }
    }
}