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
            Secante se = new Secante();
            Newton ne = new Newton();
            
            
            Funcao f = new Funcao("x^3-9x+5;");
            fp.funcao = bi.funcao = se.funcao = ne.funcao = f;
            fp.a = bi.a = se.a = ne.a = 0;
            fp.b = bi.b = se.b = ne.b = 2;
            
            double precisao = 0.0000001;


            Console.WriteLine("[Falsa Posicao] Raiz: " + fp.calcRaiz(precisao).ToString("N8") + " com precisao de " + precisao + ", com total de " + fp.qtdIteracoes + " iteracoes");
            Console.WriteLine("[Bissecao] Raiz: " + bi.calcRaiz(precisao).ToString("N8") + " com precisao de " + precisao + ", com total de " + bi.qtdIteracoes + " iteracoes");
            Console.WriteLine("[Secante] Raiz: " + se.calcRaiz(precisao).ToString("N8") + " com precisao de " + precisao + ", com total de " + se.qtdIteracoes + " iteracoes");
            Console.WriteLine("[Newton] Raiz: " + ne.calcRaiz(precisao).ToString("N8") + " com precisao de " + precisao + ", com total de " + ne.qtdIteracoes + " iteracoes");

            //Funcao f = new Funcao("3x^2+2x+5;");

            //Funcao fd = f.derivarFuncao();

            //Console.WriteLine("Funcao original: " + f.getStringFuncao());
            //Console.WriteLine("Funcao derivada: " + fd.getStringFuncao());






        }
    }



    
}