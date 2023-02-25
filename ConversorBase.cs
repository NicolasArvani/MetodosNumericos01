using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MetodosNumericos01
{
    internal class ConversorBase
    {
        private int base1;
        private int base2;

        public ConversorBase(int base1, int base2) //base original, base para converter
        {
            this.base1 = base1;
            this.base2 = base2;
        }

        public ConversorBase(int base2) //se nao for especificada a 1 base, leva-se em conta como base 10
        {
            this.base1 = 10;
            this.base2 = base2;
        }

        public void setBase1(int base1){ this.base1 = base1; }
        public void setBase2(int base2){ this.base2 = base2; }

        /*------------------------------------------------------------*/

        public String converterB1B2(String numero)
        {
            return converter(numero, this.base1, this.base2);
        }
        public String converterB1B2(int numero)
        {
            return converter(numero.ToString(), this.base1, this.base2);
        }
        public String converterB2B1(String numero)
        {
            return converter(numero, this.base2, this.base1);
        }
        public String converterB2B1(int numero)
        {
            return converter(numero.ToString(), this.base2, this.base1);
        }


        /*------------------------------------------------------------*/

        private String converter(String numero, int b1, int b2)
        {
            String resultado = "";
            int numeroInt = Convert.ToInt32(convBase10(numero, b1));
            do
            {
                resultado = (numeroInt % b2).ToString() + resultado;
                numeroInt = numeroInt / b2;
            } while (numeroInt > b2);
            if(numeroInt > 0)
            {
                resultado = (numeroInt % b2).ToString() + resultado;
            }

            return resultado;
        }

        private String convBase10(String original, int baseOriginal)
        {
            int resultado = 0;
            int expoente = original.Length-1;
            for (int i = 0; i < original.Length; i++)
            {
                int num = Convert.ToInt32(original[i].ToString());
                resultado += Convert.ToInt32(num * Math.Pow(baseOriginal, expoente--));
            }

            return resultado.ToString();
        }
    
    }
}
