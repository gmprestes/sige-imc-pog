using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalculadoraIMC
{
    public class ClassePessoa
    {
        public string Nome
        {
            get;
            set;
        }
        public string Sobrenome
        {
            get;
            set;
        }
        public int Idade
        {
            get;
            set;
        }
        public double Peso
        {
            get;
            set;
        }
        public double Altura
        {
            get;
            set;
        }
        public ClassePessoa(string nome, string sobrenome,int idade,double peso,double altura)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Idade = idade;
            this.Altura = altura;
            this.Peso = peso;    
        }
        public ClassePessoa(int idade,string nome,string sobrenome)
        {
            this.Idade = idade;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
        }
        public double CalculaIMC()
        {
            return Math.Round(Peso / (Altura * Altura), 1);
        }
    }
}
