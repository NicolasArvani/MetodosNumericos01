using System.Numerics;

namespace MetodosNumericos01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //teste regressao linear
            double[] x = { 0, 1, -1, 0 };
            double[] y = { 0, 1, 2, 2 };


            RegressaoLinear rl = new RegressaoLinear(x, y);
            rl.print();
            Console.WriteLine("Equação da reta: " + rl.getEquacaoReta());


        }
    }




}