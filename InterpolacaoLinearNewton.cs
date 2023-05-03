using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class InterpolacaoLinearNewton
    {
        private double[] x;
        private double[] y;
        private double[] diferencaDividida;

        public InterpolacaoLinearNewton(double[] x, double[] y)
        {
            this.x = x;
            this.y = y;
            this.diferencaDividida = new double[x.Length];
            this.calcDiferencaDividida();
        }

        public double calcY(double x)
        {
            double y = 0;
            for (int i = 0; i < this.x.Length; i++)
            {
                double l = 1;
                for (int j = 0; j < i; j++)
                {
                    l *= (x - this.x[j]);
                }
                y += l * this.diferencaDividida[i];
            }
            return y;
        }

        public void print()
        {
            Console.WriteLine("x\t| y\t| Diferenca Dividida");
            for (int i = 0; i < this.x.Length; i++)
            {
                Console.WriteLine(this.x[i] + "\t| " + this.y[i] + "\t| " + this.diferencaDividida[i]);
            }
        }

        private void calcDiferencaDividida()
        {
            for (int i = 0; i < this.x.Length; i++)
            {
                this.diferencaDividida[i] = this.y[i];
            }
            for (int i = 1; i < this.x.Length; i++)
            {
                for (int j = this.x.Length - 1; j >= i; j--)
                {
                    this.diferencaDividida[j] = (this.diferencaDividida[j] - this.diferencaDividida[j - 1]) / (this.x[j] - this.x[j - i]);
                }
            }
        }
    }
}