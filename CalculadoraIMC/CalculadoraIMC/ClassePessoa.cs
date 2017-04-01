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
        //nome
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
        public ClassePessoa(int Idade,double Peso,double Altura)
        {
            this.Idade = Idade;
            this.Altura = Altura;
            this.Peso = Peso;    
        }
        public ClassePessoa(int Idade)
        {
            this.Idade = Idade;
        }
        public double CalculaIMC()
        {
            return Math.Round(Peso / (Altura * Altura), 1);
        }
    }
}
