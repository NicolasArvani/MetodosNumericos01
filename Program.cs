using System.Numerics;

namespace MetodosNumericos01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //teste do interpolador de lagrange
            double[] x = { -1, 0, 1, 2 };
            double[] y = { -2, 1, 4, 3 };
            InterpolacaoLinearLagrange interpoladorLagrange = new InterpolacaoLinearLagrange(x, y);
            InterpolacaoLinearNewton interpoladorNewton = new InterpolacaoLinearNewton(x, y);

            //teste com valor 1
            interpoladorLagrange.print();
            Console.WriteLine("y(1) = " + interpoladorLagrange.calcY(1));
            interpoladorNewton.print();
            Console.WriteLine("y(1) = " + interpoladorNewton.calcY(1));

        }
    }




}