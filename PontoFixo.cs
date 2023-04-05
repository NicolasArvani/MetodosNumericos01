using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class PontoFixo : ZerosFuncao
    {
        private FuncaoPhi fPhi;

        public PontoFixo(String s, double a, double b) : base(s, a, b)
        {
            this.fPhi = new FuncaoPhi(s);
            fPhi.printPhi();
        }
        public PontoFixo(Funcao f, double a, double b) : base(f, a, b)
        {
            this.fPhi = new FuncaoPhi(this.funcao.getStringFuncao());
            fPhi.printPhi();
        }

        private double F(double x)
        {
            return this.funcao.calculaY(x);
        }
        
        private double phi(double x)
        {
            return this.fPhi.calcPhi(x);
        }

        public override double calcRaiz(double e)
        {
            this.qtdIteracoes = 0;
            double x = (b + a) / 2;
            do
            {
                x = phi(x);
                this.qtdIteracoes++;
            } while (Math.Abs(F(x)) > e);
            
            return x;
        }

    }
}
