using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MetodosNumericos01
{
    internal class EliminacaoGauss : Gauss
    {

        public EliminacaoGauss(double[,] MatrixA, double[,] MatrixB) : base(MatrixA, MatrixB)
        {
            
        }
        public EliminacaoGauss(double[,] MatrixCompleta) : base(MatrixCompleta)
        {
            
        }
        
        public override double[,] resolver()
        {
            double[,] Resolvida = this.Matrix;
            //metodo de eliminacao de gauss 
            double mult;
            for (int i = 0; i < Resolvida.GetLength(0)-1; i++)
            {
                for(int i2 = i+1; i2 < Resolvida.GetLength(0); i2++)
                {
                    mult = Resolvida[i2,i] / Resolvida[i, i];
                    for(int j = 0; j < Resolvida.GetLength(1); j++)
                    {
                        Resolvida[i2, j] = Resolvida[i2, j] - (mult * Resolvida[i, j]);
                    }
                }
            }
            return Resolvida;
        }

    }
}
