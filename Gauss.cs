﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MetodosNumericos01
{
    internal abstract class Gauss
    {
        public double[,] MatrixA;
        public double[,] MatrixB;
        protected double[,] Matrix;
        public Gauss(double[,] MatrixA, double[,] MatrixB)
        {
            if (MatrixA.GetLength(0) != MatrixB.GetLength(0))
                throw new Exception("Matrizes com numero de linhas diferentes!");

            this.MatrixA = MatrixA;
            this.MatrixB = MatrixB;

            Matrix = new double[MatrixA.GetLength(0), MatrixA.GetLength(1) + 1];


            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (j < MatrixA.GetLength(1))
                        Matrix[i, j] = MatrixA[i, j];
                    else
                        Matrix[i, j] = MatrixB[i, 0];
                }
            }

        }
        public Gauss(double[,] Completa)
        {
            this.Matrix = Completa;
        }

        public static void printMatrix(double[,] Matrix)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0:0.00}", Matrix[i, j]) + " ");
                }
                Console.Write("\n");
            }
        }

        public abstract double[,] resolver();        
    }   
}
