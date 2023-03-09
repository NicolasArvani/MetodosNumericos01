using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class FalsaPosicao
    {
        /* 
            raiz = (a * f(b) - b * f(a)) / (f(b)-f(a))
            se f(a) * f(raiz) < 0
                b = raiz
            senão
                a = raiz
        */

        private double a;
        private double b;
        private Funcao funcao;
        private int qtdIteracoes;

        public FalsaPosicao(String s, double a, double b)
        {
            this.funcao = new Funcao(s);
            this.a = a;
            this.b = b;
        }

        public FalsaPosicao() { } 

        public void setFuncao(String s){ this.funcao = new Funcao(s); }
        public void setA(double a){ this.a = a; }
        public double getA() { return this.a; }
        public void setB(double b){ this.b = b; }
        public double getB() { return this.b; }
        public int getQtdIteracoes() { return this.qtdIteracoes; }
        
        public double calcRaiz(double e)
        {
            double raiz;
            this.qtdIteracoes = 0;
            do
            {
                raiz = (a * calcF(b) - b * calcF(a)) / (calcF(b) - calcF(a));
                if (calcF(a) * calcF(raiz) < 0)
                    b = raiz;
                else
                    a = raiz;
                this.qtdIteracoes++;
            } while (Math.Abs(calcF(raiz)) > e);

            return raiz;
        }

        private double calcF(double x)
        {
            return funcao.calculaY(x);
        }
    }
}
        



