using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos01
{
    internal class interpretadorDeFuncao
    {
        string funcaoTexto;

        public interpretadorDeFuncao(string funcaoTexto)
        {
            this.funcaoTexto = funcaoTexto;
        }

    }

    public class Funcao
    {
        private List<char> FuncaoList;
        private List<int> Constantes = new List<int>();
        private List<int> Elevados = new List<int>();


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

            bool elevado = false;
            bool num = false;
            bool negative = false;
            for (int i = 0; i < FuncaoList.Count; i++)
            {
                if (isNumber(FuncaoList[i])) //Verifica se é um numero, caso seja, coloca a bool num = true e adiciona o char na lista de numeros para depois converter em int
                {
                    num = true;
                    number.Add(FuncaoList[i]);
                }
                else if (FuncaoList[i] == 'x') //se for x, entao ja temos os numeros na lista
                {
                    if (num) //caso haja numeros na lista de char, converte para int
                    {
                        String s = new String(number.ToArray());
                        //Console.WriteLine("Convertendo: " + s);
                        int n = Convert.ToInt32(s);
                        if (negative) //se for negativo, apenas multiplica por -1
                        {
                            n *= -1;
                            negative = false;
                        }
                        Constantes.Add(n); //adiciona na lista de constantes
                        number.Clear(); //limpa a lista de chars para reutilizar
                        num = false; //reseta a variavel controle
                    }
                    else
                    {
                        //caso nao haja numeros na lista, entao o x esta sendo multiplicando por 1 ou -1
                        if (negative)
                        {
                            Constantes.Add(-1);
                            negative = false;
                        }
                        else
                        {
                            Constantes.Add(1);
                        }
                    }
                }
                else if (FuncaoList[i] == '^') //variavel de controle de elevado eh ativada
                {
                    elevado = true;
                }
                else if (FuncaoList[i] == '-' || FuncaoList[i] == '+') //se for mais ou menos, o bloco de x acabou, portanto podemos elevar o numero
                {
                    if (elevado) //se houve sinal de elevado, converte o numero da lista para int e adiciona  na lista de Elevados
                    {
                        String s = new String(number.ToArray());
                        //Console.WriteLine("Convertendo: " + s);
                        int n = Convert.ToInt32(s);
                        if (negative)
                        {
                            n *= -1;
                            negative = false;
                        }
                        Elevados.Add(n);
                        number.Clear();
                        elevado = false;
                        num = false;
                    }
                    else //caso a variavel controle de elevado esteja falsa, entao o x eh elevado a 1
                    {
                        Elevados.Add(1);
                    }
                    if (FuncaoList[i] == '-')//caso seja -, o proximo numero sera multiplicado por -1 la em cima
                    {
                        negative = true;
                    }
                }
                else if (FuncaoList[i] == ';') //sinal de finalizacao da funcao, portanto o x sera elevado a 0
                {
                    if (num)
                    {
                        String s = new String(number.ToArray());
                        //Console.WriteLine("Convertendo: " + s);
                        int n = Convert.ToInt32(s);
                        if (negative)
                        {
                            n *= -1;                        
                           negative = false;
                        }
                        Constantes.Add(n);
                        Elevados.Add(0);
                        number.Clear();
                        break;                    
                    }
                }
                else if (!isAcceptable(FuncaoList[i]))
                {
                    throw new Exception("Função com Formato ou Caracteres Inválidos");
                }
            }   
        }


        public double calculaY(int x)
        {
            double y=0;

            for(int i = 0; i < Constantes.Count(); i++)
            {
                y += (Constantes[i] * (Math.Pow(x, Elevados[i])));
            }

            return y;
        }
        
        public double calculaY(double x)
        {
            double y=0;

            for(int i = 0; i < Constantes.Count(); i++)
            {
                y += (Constantes[i] * (Math.Pow(x, Elevados[i])));
            }

            return y;
        }



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
                Console.Write(Constantes[i] + "*x^" + Elevados[i]);
            }
        }

        private String listToString(List<char> l)
        {
            String s = new String(l.ToArray());
            return s;
        }
        
        private void printIntList(List<int> l)
        {
            
            for(int i = 0; i < l.Count(); i++)
            {
                Console.Write(i + ":[" + l[i].ToString() + "] / ");
            }
            Console.WriteLine();
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
                ' '
            };

            return acceptable.Contains(c);
        }

    }

}
