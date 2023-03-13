using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class Newton : ZerosFuncao
    {
        //raiz = x0 - f(x0)/f'(x0)

        public Funcao funcaoDer { get; private set; }

        public Newton(String s, double a, double b) : base(s, a, b)
        {
            
        }
        public Newton(Funcao f, double a, double b) : base(f, a, b)
        {
            
        }

        public Newton() : base()
        { 
        
        }

        public override double calcRaiz(double e)
        {
            this.funcaoDer = funcao.derivarFuncao();
            double x = (a + b) / 2;
            this.qtdIteracoes = 0;
            double raiz;
            do
            {
                raiz = x - (F(x) / FDerivada(x));
                x = raiz;

                this.qtdIteracoes++;
            } while (Math.Abs(F(raiz)) > e);
            this.raiz = raiz;
            return raiz;
        }

        private double FDerivada(double x)
        {
            return funcaoDer.calculaY(x);
        }
    }
}

