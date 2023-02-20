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
        private double inicio;
        private double fim;
        private Funcao funcao;

        public Bissecao(String s, double i, double f)
        {
            this.funcao = new Funcao(s);
            this.inicio = i;
            this.fim = f;
        }

        public Bissecao() { } //construtor vazio


        public void setFuncao(String s) { this.funcao = new Funcao(s); }
        public void setInicio(double i) { this.inicio = i; }
        public void setFim(double f) { this.fim = f; }
        public void getFuncao() { this.funcao.printFuncao(); }
        public double getInicio() { return this.inicio; }
        public double getFim() { return this.fim; }


        public double calcRaiz(double e)
        {
            double i = this.inicio;
            double f = this.fim;
            double k = (i + f) / 2;

            while (Math.Abs(f - i) > e)
            {
                if (calcF(i) * calcF(k) < 0)
                {
                    f = k;
                }
                else
                {
                    i = k;
                }
                k = (i + f) / 2;
            }
            return k;
        }

        private double calcF(double x)
        {
            return funcao.calculaY(x);
        }
    }

    
    

    
}
