using System.Numerics;

namespace MetodosNumericos01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //       ---> Programa Main está sendo utilizado para teste das classes por enquanto <---


            /* Codigo Teste para classe Funcao
            Funcao f = new Funcao("x^3-9x+5;");
            f.printDebug();
            f.printFuncao();
            Console.WriteLine("\r\nx=2:" + f.calculaY(2).ToString());
            */

            /* Codigo teste para classe Bissecao
            do {
                Console.WriteLine("Digite a função:");
                String s = Console.ReadLine();
                Console.WriteLine("Digite o intervalo inicial:");
                double i = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Digite o intervalo final:");
                double f = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Digite a precisão:");
                double e = Convert.ToDouble(Console.ReadLine());

                Bissecao b = new Bissecao(s, i, f);
                Console.WriteLine("Raiz: " + b.calcRaiz(e).ToString("N8"));
                Console.WriteLine("Deseja continuar? (s/n)");
            } while (Console.ReadLine() == "s");
        */

            /* Codigo teste para classe ConversorBase
            ConversorBase a = new ConversorBase(5, 3);
            Console.WriteLine("Base 5 -> Base 3: " + a.converterB1B2(230));
            Console.WriteLine("Base 3 -> Base 5: " + a.converterB2B1(2102));
            a.setBase1(10);
            Console.WriteLine("Valor na base 10: " + a.converterB2B1(2102));
            */

            //SomaDeRiemann sr = new SomaDeRiemann("");
            //sr.setInicio(0);
            //sr.setFim(2);

            //Console.WriteLine("Area c/ 5 divisoes: " + sr.calcArea(5).ToString("N8"));
            //Console.WriteLine("Area c/ 50 divisoes: " + sr.calcArea(50).ToString("N8"));
            //Console.WriteLine("Area c/ 500 divisoes: " + sr.calcArea(500).ToString("N8"));

            //Bissecao b = new Bissecao(";", 0, 2);
            //Console.WriteLine("Raiz: " + b.calcRaiz(0.00001).ToString("N8"));
            //

            FalsaPosicao fp = new FalsaPosicao();
            Bissecao bi = new Bissecao();
            fp.setFuncao("x^3-9x+5;");
            fp.setA(0);
            fp.setB(2);
            bi.setFuncao("x^3-9x+5;");
            bi.setA(0);
            bi.setB(2);

            Console.WriteLine("[Falsa Posicao] Raiz: " + fp.calcRaiz(0.000001).ToString("N8") + " com precisao de 0,000001, com total de " + fp.getQtdIteracoes() +" iteracoes");
            Console.WriteLine("[Bissecao] Raiz: " + bi.calcRaiz(0.000001).ToString("N8") + " com precisao de 0,000001, com total de " + bi.getQtdIteracoes() + " iteracoes");

        }
    }



    
}