namespace MetodosNumericos01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Funcao f = new Funcao("x^3-9x+5;");
            //f.printDebug();
            //f.printFuncao();
            //Console.WriteLine("\r\nx=2:" + f.calculaY(2).ToString());

            Bissecao bi = new Bissecao();

            bi.setFuncao("x^3+x^2-9x+5;");
            bi.setInicio(2);
            bi.setFim(4);
            Double erro = 0.0001;
            Console.WriteLine("Raiz: " + bi.calcRaiz(erro).ToString() + "\r\nErro: " + erro.ToString());


        }
    }



    
}