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
        public string Sexo
        {
            get;
            set;
        }
        public ClassePessoa(string nome, string sobrenome,int idade,double peso,double altura, string sexo)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Idade = idade;
            this.Altura = altura;
            this.Peso = peso;
            this.Sexo = sexo;
        }
        public ClassePessoa(int idade,string nome,string sobrenome, string sexo)
        {
            this.Idade = idade;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Sexo = sexo;
        }
        public double CalculaIMC()
        {
            return Math.Round(Peso / (Altura * Altura), 1);
        }
    }
}
