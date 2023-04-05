using System.Numerics;

namespace MetodosNumericos01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PontoFixo pf = new PontoFixo("x^3-9x+5;", 0.5, 1);
            Funcao f = new Funcao("x^3-9x+5;");
            double res = pf.calcRaiz(0.001);
            Console.WriteLine(res);
            Console.WriteLine("F(x) = " + f.calculaY(res));
            

            /*
             
             Metodo main apenas para testes
             
             */







        }
    }



    
}