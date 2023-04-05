using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class FuncaoPhi
    {

        private int divisor;
        private int expoente;
        private Funcao phi;

        private Funcao _funcao;
        public Funcao funcao {
            get { return this._funcao ?? throw new Exception("Funcao nula"); }
            set { _funcao = value; makePhi(); }
        }

        public FuncaoPhi(String s)
        {
            this.funcao = new Funcao(s);
        }

        public FuncaoPhi(Funcao funcao)
        {
            this.funcao = new Funcao(funcao.getStringFuncao());
        }
        

        public FuncaoPhi()
        {
            
        }

        public double calcPhi(double x)
        {
            //this.printPhi();
            double a = this.phi.calculaY(x);
            //Console.WriteLine(a);
            a /= this.divisor;
            //Console.WriteLine(a);
            a = Math.Pow(a, 1 / this.expoente);
            //Console.WriteLine(a);
            return a;
        }
        
        public void printPhi()
        {
            Console.WriteLine("Phi: " + this.phi.getStringFuncao());
            Console.WriteLine("Divisor: " + this.divisor + " | Expoente: " + this.expoente);
        }


        /*------------- Calculo de phi (Metodo do ponto fixo) ---------------*/


        public void makePhi()
        {
            
            List<int> Constantes = this._funcao.Constantes;
            List<int> Elevados = this._funcao.Elevados;

            int escolhido = 0;
            for (int i = 0; i < Constantes.Count(); i++)
            {
                if (Elevados[i] > 0 && Elevados[i] < Elevados[escolhido])
                {
                    escolhido = i;
                }
            }

            if (Constantes[escolhido] == 0 || escolhido == int.MaxValue)
            {
                throw new Exception("Não foi possivel escolher o X");
            }

            for (int i = 0; i < Constantes.Count(); i++)
            {
                if (i != escolhido)
                {
                    Constantes[i] *= -1;
                }
            }

            this.divisor = Constantes[escolhido];
            this.expoente = Elevados[escolhido];

            Constantes.RemoveAt(escolhido);
            Elevados.RemoveAt(escolhido);
            
            this.phi = new Funcao(Constantes, Elevados);

        }


    }
}
