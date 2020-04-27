using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Алгоритмы_умножения_матриц
{
    public class Matrix
    {
        private int [,] matr;
        public int rows, cols;

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matr = new int[this.rows, this.cols];
        }

        public int this[int index1, int index2]
        {
            get { return matr[index1, index2]; }
            set { matr[index1, index2] = value; }
        }
 
        public void matrInput()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matr[i, j] = Int32.Parse(Console.ReadLine());
                }
            }
            Console.Write("\n");
        }

        public void matrOutput()
        { 
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.Write("\n");
        }

       public Matrix Mult(Matrix A, Matrix B)
       {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            Matrix C = new Matrix(A.rows, B.cols);

            for (int i = 0; i < A.rows; i++)
            {
                for(int j = 0; j < B.cols; j++)
                {
                    C[i, j] = 0;

                    for (int k = 0; k < A.cols; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            C.matrOutput();
            sw.Stop();

            Console.Write("Elapsed time: " + sw.ElapsedMilliseconds + "ms" + "\n");

            return C;
       }

        public Matrix Winograd(Matrix A, Matrix B)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            Matrix C = new Matrix(A.rows, B.cols);

            int[] rowFactor = new int[100];
            int[] colFactor = new int[100];

            for (int i = 0; i < A.rows; i++)
            {
                for(int j = 0; j < A.cols/2 ; j++)
                {
                    rowFactor[i] = rowFactor[i] + (A[i, 2*j] * A[i, 2*j + 1]);                   
                }
            }

            for (int i = 0; i < B.rows; i++)
            {
                for (int j = 0; j < B.cols/2; j++)
                {
                    colFactor[i] = colFactor[i] + (B[j << 1, i] * B[2 * j + 1, i]);
                }
            }

                for (int i = 0; i < A.rows; i++)
                {
                    for (int j = 0; j < B.cols; j++)
                    {
                        C[i, j] = -rowFactor[i] - colFactor[j];

                        for (int k = 1; k < A.rows; k+=2)
                        {
                            C[i, j] = C[i, j] + ((A[i, k - 1] + B[k, j]) * (A[i, k] + B[k-1, j]));
                        }
                    }
                }
            if (A.rows % 2 == 1)
            {
                for (int i = 0; i < A.rows; ++i)
                {
                    for (int j = 0; j < B.cols; ++j)
                    {
                        C[i, j] = C[i, j] + (A[i, A.rows - 1] * B[B.cols - 1, j]);
                    }
                }
            }

            C.matrOutput();
            sw.Stop();

            Console.Write("Elapsed time: " + sw.ElapsedMilliseconds + "ms" + "\n");

            return C;
        }
    }
}


