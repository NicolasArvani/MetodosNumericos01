using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal abstract class ZerosFuncao
    {
        public Funcao funcao { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double raiz { get; protected set; }
        public int qtdIteracoes { get; protected set; }

        public ZerosFuncao(String s, double a, double b)
        {
            this.funcao = new Funcao(s);
            this.a = a;
            this.b = b;
        }
        public ZerosFuncao(Funcao f, double a, double b)
        {
            this.funcao = f;
            this.a = a;
            this.b = b;
        }
        public ZerosFuncao() { }
        

        public abstract double calcRaiz(double e);

        
        protected double F(double x)
        {
            return funcao.calculaY(x);
        }
        

    }
}
