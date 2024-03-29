﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class FalsaPosicao : ZerosFuncao
    {
        public FalsaPosicao(String s, double a, double b) : base(s, a ,b)
        {

        }
        public FalsaPosicao(Funcao f, double a, double b) : base(f, a ,b)
        {

        }
        public FalsaPosicao() { }         

        public override double calcRaiz(double e)
        {
            double a = this.a;
            double b = this.b;
            double raiz;
            this.qtdIteracoes = 0;
            do
            {
                raiz = (a * F(b) - b * F(a)) / (F(b) - F(a));
                if (F(a) * F(raiz) < 0)
                    b = raiz;
                else
                    a = raiz;
                this.qtdIteracoes++;
            } while (Math.Abs(F(raiz)) > e);
            this.raiz = raiz;
            return raiz;
        }

        
    }
}
        



