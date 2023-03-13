using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class Bissecao : ZerosFuncao
    {
        public Bissecao(String s, double i, double f) : base(s, i, f)
        {

        }
        public Bissecao(Funcao s, double i, double f) : base(s, i, f)
        {

        }

        public Bissecao() { } 

    
        public override double calcRaiz(double e)
        {
            this.qtdIteracoes = 0;
            double i = this.a;
            double f = this.b;
            double k = (i + f) / 2;

            while (Math.Abs(f - i) > e)
            {
                if (F(i) * F(k) < 0)
                    f = k;
                else
                    i = k;
                
                k = (i + f) / 2;
                this.qtdIteracoes++;
            }
            this.raiz = k;
            return k;
        }


    }

    
    

    
}
