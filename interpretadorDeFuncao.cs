using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    public class Funcao
    {
        private List<char> FuncaoList;
        public List<int> Constantes { get; private set; } = new List<int>();
        public List<int> Elevados { get; private set; } = new List<int>();


        /*
        Lógica aplicada utilizando o seguinte conceito:

        C[0]*x^E[0] + C[1]*x^E[1] + ... + C[n]*x^E[n];
        Onde: C = List<int> Constantes, E = List<int> Elevados 

        Exemplo:
        A funçao x^3 + x^2 - 9x + 5 = 0 deverá ser inserida como string da seguinte forma:
        x^3+x^2-9x+5;

        Será interpretado assim:

        1*x^3 + 1*x^2 - 9*x^1 + 5*x^0;
        As listas ficarao:
        Constantes: 1, 1, -9, 5;
        Elevados: 3, 2, 1, 0;
         
        */



        public Funcao(string funcaoString)
        {

            this.FuncaoList = funcaoString.ToList<char>();
            List<char> number = new List<char>();
            interpretador(this.FuncaoList);
        }

        public Funcao(List<int> c, List<int> e)
        {
            this.Constantes = c;
            this.Elevados = e;
        }

        public Funcao()
        {
            
        }

        public void setFuncao(String funcao)
        {
            this.FuncaoList = funcao.ToList<char>();
            interpretador(this.FuncaoList);
        }


        /*------------------ Métodos para interpretação ------------------*/


        private void interpretador(List<char> Funcao) //v3 do interpretador
        {
            for (int i = 0; i < Funcao.Count(); i++) //verifica se tem algum caracter invalido
            {
                if (!isAcceptable(Funcao[i]) && !isNumber(Funcao[i]))
                {
                    throw new Exception("Função com Formato ou Caracteres Inválidos: " + Funcao[i]);
                }
            }

            this.Constantes.Clear();
            this.Elevados.Clear();


            //logica utilizada de acordo com o fluxograma
            //https://i.imgur.com/bjOxjSY.png

            List<char> numChar = new List<char>();
            bool num = false;
            bool elevado = false;
            bool neg = false;
            bool x = false;

            for (int i = 0; i < Funcao.Count(); i++)
            {
                if (isNumber(Funcao[i]))
                {
                    numChar.Add(Funcao[i]);
                    num = true;
                }
                else if (Funcao[i] == 'x')
                {
                    x = true;
                    if (num)
                    {
                        this.Constantes.Add(numCharToInt(ref numChar, ref neg));
                        num = false;
                    }
                    else
                    {
                        int n = 1;
                        if (neg)
                        {
                            n *= -1;
                            neg = false;
                        }
                        this.Constantes.Add(n);

                    }
                }
                else if (Funcao[i] == '^')
                {
                    elevado = true;
                }
                else if (Funcao[i] == '+' || Funcao[i] == '-' || Funcao[i] == ';')
                {
                    if (x)
                    {
                        if (elevado)
                        {
                            this.Elevados.Add(numCharToInt(ref numChar, ref neg));
                            elevado = false;
                            num = false;
                        }
                        else
                        {
                            this.Elevados.Add(1);
                        }
                        x = false;
                    }
                    else
                    {
                        if (num)
                        {
                            this.Constantes.Add(numCharToInt(ref numChar, ref neg));
                            this.Elevados.Add(0);
                            num = false;
                        }
                    }
                    if (Funcao[i] == '-')
                    {
                        neg = true;
                    }
                }
            }
        }

        private int numCharToInt(ref List<char> numChar, ref bool neg)
        {
            String s = new String(numChar.ToArray());
            int n = Convert.ToInt32(s);
            if (neg)
            {
                n *= -1;
                neg = false;
            }
            numChar.Clear();
            return n;
        }

        private bool isNumber(char c)
        {
            return (c >= 48 && c <= 57);
        }

        private bool isAcceptable(char c)
        {
            char[] acceptable = new char[] {
                '+',
                '-',
                'x',
                ';',
                ' ',
                '*',
                '^'
            };

            return acceptable.Contains(c);
        }


        /*------------- Calculo do f(x) ---------------*/

        public double calculaY(object X)
        {
            if (this.Constantes.Any() && this.Elevados.Any())
            {
                double x = Convert.ToDouble(X);
                double y = 0;

                for (int i = 0; i < Constantes.Count(); i++)
                {
                    y += (Constantes[i] * (Math.Pow(x, Elevados[i])));
                }
                return y;
            }
            else //se a funcao for vazia, retorna NaN
            {
                return double.NaN;
            }
        }


        public static double calculaY(String funcao, object x) //calculo de f(x) estatico
        {
            Funcao f = new Funcao(funcao);
            return f.calculaY(x);
        }

        /*------------- Derivada ---------------*/

        public Funcao derivarFuncao()
        {
            List<int> newConst = new List<int>();
            List<int> newElev = new List<int>();
            //(x^n)' = n*x^n-1;
            for (int i = 0; i < this.Constantes.Count(); i++)
            {
                if (this.Elevados[i] != 0)
                {
                    newConst.Add(this.Elevados[i] * this.Constantes[i]);
                    newElev.Add(this.Elevados[i] - 1);
                }
            }
            return new Funcao(newConst, newElev);
        }

        public static Funcao derivarFuncao(String f)
        {
            return new Funcao(f).derivarFuncao();
        }


        
        /*------------- Funcoes diversas ---------------*/

        public void printDebug()
        {
            Console.WriteLine("Função: " + listToString(FuncaoList));
            Console.Write("Constantes: ");
            printIntList(Constantes);
            Console.Write("Elevados: ");
            printIntList(Elevados);
        }

        public void printFuncao()
        {
            for(int i = 0; i < Elevados.Count(); i++)
            {
                if(i != 0 && Constantes[i] >= 0)
                {
                    Console.Write("+");
                }
                if (Elevados[i] == 1)
                    Console.Write(Constantes[i] + "*x");
                else if (Elevados[i] != 0)
                    Console.Write(Constantes[i] + "*x^" + Elevados[i]);
                else
                    Console.Write(Constantes[i]);
            }
            Console.Write("\n");
        }

        public String getStringFuncao()
        {
            String result = "";
            for (int i = 0; i < Elevados.Count(); i++)
            {
                if (i != 0 && Constantes[i] >= 0)
                {
                    result += "+";
                }
                if (Elevados[i] == 1)
                    result += Constantes[i].ToString() + "*x";
                else if (Elevados[i] != 0)
                    result += Constantes[i].ToString() + "*x^" + Elevados[i].ToString();
                else
                    result += Constantes[i].ToString();
            }
            result += ";";
            return result;
        }

        private String listToString(List<char> l)
        {
            return new String(l.ToArray());
        }
        
        private void printIntList(List<int> l)
        {
            
            for(int i = 0; i < l.Count(); i++)
            {
                Console.Write(i + ":[" + l[i].ToString() + "] / ");
            }
            Console.WriteLine();
        }

        

        

    }

    
}
