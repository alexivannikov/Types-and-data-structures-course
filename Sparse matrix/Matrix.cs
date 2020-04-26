using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Реализация_разреженной_матрицы
{
    public class Matrix
    {
        private int[,] matr;
        public int rows, cols;

        int[] IA = new int[100];
        int[] JA = new int[100];
        int[] AN = new int[100];
        int[] JC = new int[100];

        int k, count;

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

        public void CSR(Matrix A)
        {
            count = 0;

            for (int i = 0; i < rows; i++)
            {
                IA[0] = 0;

                for (int j = 0; j < cols; j++)
                {
                    if (matr[i, j] != 0)
                    {
                        count++;
                    }
                }
                IA[i + 1] = count;
            }

            k = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matr[i, j] != 0)
                    {
                        JA[k] = j;

                        k++;
                    }
                }
            }

            k = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matr[i, j] != 0)
                    {
                        AN[k] = matr[i, j];

                        k++;
                    }
                }
            }
        }

        public void CSROutput()
        {
            Console.Write("CSR Format:" + "\n" + "IA = ");

            for (int i = 0; i <= rows; i++)
            {
                Console.Write(IA[i] + "\t");
            }

            Console.Write("\n" + "JA = ");

            for (int i = 0; i < k; i++)
            {
                Console.Write(JA[i] + "\t");
            }

            Console.Write("\n" + "AN = ");

            for (int i = 0; i < k; i++)
            {
                Console.Write(AN[i] + "\t");
            }
        }

        public Matrix Unpack(Matrix A)
        {
            Matrix B = new Matrix(A.rows, A.cols);

            int[] strInd = new int[100]; //Масссив индексов по строке
            int str = 0; //Индекс текущей строки
            int j = 0;
            int cntEl = 0; //Счетчик количества элементов в строке

            CSR(A);

            Console.Write("\n" + "JC = ");

            for (int i = 0; i < rows & j < count; i++)
            {
                if (IA[i] != IA[i + 1])
                {
                    while (cntEl != IA[i + 1])
                    {
                        strInd[j] = str;
                        Console.Write(strInd[j] + "\t");
                        JC[i] = str;
                        cntEl++;
                        j++;
                    }
                }
                str++;
            }

            for (int i = 0; i < A.rows; i++)
            {
                for (j = 0; j < A.cols; j++)
                {
                    B[i, j] = 0;
                }
            }

            for (int k = 0, m = 0, n = 0; k < count; k++, m++, n++)
            {
                B[strInd[k], JA[m]] = AN[n];

            }

            return B;
        }

        public void unpackOutput()
        {
            Console.Write("\n" + "\n" + "Unpacked matrix:" + "\n");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matr[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }
    }
}


