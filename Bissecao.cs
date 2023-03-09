using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class Bissecao
    {
        private double a;
        private double b;
        private Funcao funcao;
        private int qtdIteracoes;

        public Bissecao(String s, double i, double f)
        {
            this.funcao = new Funcao(s);
            this.a = i;
            this.b = f;
        }

        public Bissecao() { } 


        public void setFuncao(String s) { this.funcao = new Funcao(s); }
        public void setA(double i) { this.a = i; }
        public void setB(double f) { this.b = f; }
        public void getFuncao() { this.funcao.printFuncao(); }
        public double getA() { return this.a; }
        public double getB() { return this.b; }
        public int getQtdIteracoes() { return this.qtdIteracoes; }


        public double calcRaiz(double e)
        {
            this.qtdIteracoes = 0;
            double i = this.a;
            double f = this.b;
            double k = (i + f) / 2;

            while (Math.Abs(f - i) > e)
            {
                if (calcF(i) * calcF(k) < 0)
                    f = k;
                else
                    i = k;
                
                k = (i + f) / 2;
                this.qtdIteracoes++;
            }
            return k;
        }

        private double calcF(double x)
        {
            return funcao.calculaY(x);
        }
    }

    
    

    
}
