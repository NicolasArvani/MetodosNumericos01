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
        List<char> FuncaoList;
        List<char> VariavelList;
        List<int> Constantes = new List<int>();
        List<int> Elevados = new List<int>();
        

        public Funcao(string funcaoString)
        {
            this.FuncaoList = funcaoString.ToList<char>();
            List<char> number = new List<char>();

            bool elevado = false;
            bool num = false;
            bool negative = false;
            for (int i = 0; i < FuncaoList.Count; i++)
            {
                if (isNumber(FuncaoList[i]))
                {
                    num = true;
                    number.Add(FuncaoList[i]);
                }
                else if (FuncaoList[i] == 'x')
                {
                    if (num)
                    {
                        String s = new String(number.ToArray());
                        Console.WriteLine("Convertendo: " + s);
                        int n = Convert.ToInt32(s);
                        if (negative)
                        {
                            n *= -1;
                            negative = false;
                        }
                        Constantes.Add(n);
                        number.Clear();
                        num = false;
                    }
                    else
                    {
                        Constantes.Add(1);
                    }
                }
                else if (FuncaoList[i] == '^')
                {
                    elevado = true;
                }
                else if (FuncaoList[i] == '-' || FuncaoList[i] == '+')
                {
                    if (elevado)
                    {
                        String s = new String(number.ToArray());
                        Console.WriteLine("Convertendo: " + s);
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
                    else
                    {
                        Elevados.Add(1);
                    }
                    if (FuncaoList[i] == '-')
                    {
                        negative = true;
                    }
                }
                else if (FuncaoList[i] == ';')
                {
                    String s = new String(number.ToArray());
                    Console.WriteLine("Convertendo: " + s);
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
