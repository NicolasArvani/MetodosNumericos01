using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class InterpolacaoLinearLagrange
    {
      
        private double[] x;
        private double[] y;

        public InterpolacaoLinearLagrange(double[] x, double[] y)
        {
            this.x = x;
            this.y = y;
        }

        public double calcY(double x)
        {
            double y = 0;
            for (int i = 0; i < this.x.Length; i++)
            {
                double l = 1;
                for (int j = 0; j < this.x.Length; j++)
                {
                    if (i != j)
                    {
                        l *= (x - this.x[j]) / (this.x[i] - this.x[j]);
                    }
                }
                y += l * this.y[i];
            }
            return y;
        }

        public void print()
        {
            Console.WriteLine("x\t| y");
            for (int i = 0; i < this.x.Length; i++)
            {
                Console.WriteLine(this.x[i] + "\t| " + this.y[i]);
            }
        }

        

    }

}