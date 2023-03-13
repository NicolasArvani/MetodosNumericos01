using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class Secante : ZerosFuncao
    {
        
        public Secante(String s, double a, double b) : base(s, a, b)
        {

        }
        public Secante(Funcao f, double a, double b) : base(f, a, b)
        {

        }
        public Secante() 
        {
        
        }
        

        public override double calcRaiz(double e)
        {
            this.qtdIteracoes = 0;
            double a = this.a;
            double b = this.b;
            double raiz;
            do
            {
                raiz = b - (F(b) * (b - a)) / (F(b) - F(a));
                a = b;
                b = raiz;

                this.qtdIteracoes++;
            } while (Math.Abs(F(raiz)) > e);
            this.raiz = raiz;
            return raiz;
        }


    }
}
