using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Реализация_разреженной_матрицы
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrA = new int[100, 100];
            int[,] matrB = new int[100, 100];

            /*Ввод матрицы A и матрицы B*/
            Console.Write("Input quantity of matrix A rows:" + "\n");

            int rowsA = int.Parse(Console.ReadLine());

            Console.Write("\n" + "Input quantity of matrix A columns:" + "\n");

            int colsA = int.Parse(Console.ReadLine());

            Console.Write("\n" + "Input matrix A elements:" + "\n");

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    matrA[i, j] = Int32.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\n" + "Input quantity of matrix B rows:");

            int rowsB = int.Parse(Console.ReadLine());

            Console.WriteLine("\n" + "Input quantity of matrix B columns:");

            int colsB = int.Parse(Console.ReadLine());

            Console.Write("\n" + "Input matrix B elements:" + "\n");

            for (int i = 0; i < rowsB; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    matrB[i, j] = Int32.Parse(Console.ReadLine());
                }
            }

            /*Вывод матрицы A и матрицы B на экран*/
            Console.Write("\n" + "Matrix A" + "\n");

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    Console.Write(matrA[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.Write("\n" + "Matrix B" + "\n");

            for (int i = 0; i < rowsB; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    Console.Write(matrB[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            /*Упаковка матрицы A и матрицы B в формат CSR*/
            int[] IA_A = new int[100];
            int[] JC_A = new int[100];
            int[] AN_A = new int[100];

            int[] IA_B = new int[100];
            int[] JC_B = new int[100];
            int[] AN_B = new int[100];

            int kA, countA;

            countA = 0;

            for (int i = 0; i < rowsA; i++)
            {
                IA_A[0] = 0;

                for (int j = 0; j < colsA; j++)
                {
                    if (matrA[i, j] != 0)
                    {
                        countA++;
                    }
                }
                IA_A[i + 1] = countA;
            }

            kA = 0;

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    if (matrA[i, j] != 0)
                    {
                        JC_A[kA] = j;

                        kA++;
                    }
                }
            }

            kA = 0;

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    if (matrA[i, j] != 0)
                    {
                        AN_A[kA] = matrA[i, j];

                        kA++;
                    }
                }
            }

            Console.Write("Matrix A CSR format:" + "\n" + "IA = ");

            for (int i = 0; i <= rowsA; i++)
            {
                Console.Write(IA_A[i] + "\t");
            }

            Console.Write("\n" + "AN = ");

            for (int i = 0; i < kA; i++)
            {
                Console.Write(AN_A[i] + "\t");
            }

            int[] JR_A = new int[100]; //Масссив индексов по строке

            int str = 0; //Индекс текущей строки
            int q = 0;
            int cntEl = 0; //Счетчик количества элементов в строке

            Console.Write("\n" + "JR = ");

            for (int i = 0; i < rowsA & q < countA; i++)
            {
                if (IA_A[i] != IA_A[i + 1])
                {
                    while (cntEl != IA_A[i + 1])
                    {
                        JR_A[q] = str;
                        Console.Write(JR_A[q] + "\t");
                        cntEl++;
                        q++;
                    }
                }
                str++;
            }

            Console.Write("\n" + "JC = ");

            for (int i = 0; i < kA; i++)
            {
                Console.Write(JC_A[i] + "\t");
            }

            int kB, countB;

            countB = 0;

            for (int i = 0; i < rowsB; i++)
            {
                IA_B[0] = 0;

                for (int j = 0; j < colsB; j++)
                {
                    if (matrB[i, j] != 0)
                    {
                        countB++;
                    }
                }
                IA_B[i + 1] = countB;
            }

            kB = 0;

            for (int i = 0; i < rowsB; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    if (matrB[i, j] != 0)
                    {
                        JC_B[kB] = j;

                        kB++;
                    }
                }
            }

            kB = 0;

            for (int i = 0; i < rowsB; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    if (matrB[i, j] != 0)
                    {
                        AN_B[kB] = matrB[i, j];

                        kB++;
                    }
                }
            }

            Console.Write("\n" + "\n" + "Matrix B CSR format:" + "\n" + "IA = ");

            for (int i = 0; i <= rowsB; i++)
            {
                Console.Write(IA_B[i] + "\t");
            }

            Console.Write("\n" + "AN = ");

            for (int i = 0; i < kB; i++)
            {
                Console.Write(AN_B[i] + "\t");
            }

            int[] JR_B = new int[100];

            str = 0; 
            q = 0;
            cntEl = 0;

            Console.Write("\n" + "JR = ");

            for (int i = 0; i < rowsB & q < countB; i++)
            {
                if (IA_B[i] != IA_B[i + 1])
                {
                    while (cntEl != IA_B[i + 1])
                    {
                        JR_B[q] = str;
                        Console.Write(JR_B[q] + "\t");
                        cntEl++;
                        q++;
                    }
                }
                str++;
            }

            Console.Write("\n" + "JC = ");

            for (int i = 0; i < kB; i++)
            {
                Console.Write(JC_B[i] + "\t");
            }

            /*Сложение упакованных матриц*/
            int[] AN_C = new int[100];
            int[] JR_C = new int[100];
            int[] JC_C = new int[100];

            int k = 0, m = 0, temp = 0, n = 0;

            for (; k < countA & m < countB;)
            {
                /*Если координаты элементов равны*/
                if (JR_A[k] == JR_B[m] && JC_A[k] == JC_B[m])
                {
                    temp = AN_A[k] + AN_B[m];

                    if (temp != 0)
                    {
                        AN_C[n] = temp;
                        JR_C[n] = JR_A[k];
                        JC_C[n] = JC_A[k];

                        n++;
                        k++;
                        m++;
                    }
                    else
                    {
                        k++;
                        m++;
                    }
                }
                /*Если элементы находятся в одной строке, но в разных столбцах*/
                else if (JR_A[k] == JR_B[m] && JC_A[k] < JC_B[m])
                {
                    AN_C[n] = AN_A[k];
                    JR_C[n] = JR_A[k];
                    JC_C[n] = JC_A[k];

                    n++;
                    k++;
                }
                else if (JR_A[k] == JR_B[m] && JC_A[k] > JC_B[m])
                {
                    AN_C[n] = AN_B[m];
                    JR_C[n] = JR_B[m];
                    JC_C[n] = JC_B[m];

                    n++;
                    m++;
                }
                /*Если элементы находятся в разных строках*/
                else if (JR_A[k] < JR_B[m])
                {
                    AN_C[n] = AN_A[k];
                    JR_C[n] = JR_A[k];
                    JC_C[n] = JC_A[k];

                    n++;
                    k++;
                }
                else if (JR_A[k] > JR_B[m])
                {
                    AN_C[n] = AN_B[m];
                    JR_C[n] = JR_B[m];
                    JC_C[n] = JC_B[m];

                    n++;
                    m++;
                }
            }

            if (k == countA)
            {
                for (int i = m; i < countB; i++)
                {
                    AN_C[n] = AN_B[i];
                    JR_C[n] = JR_B[i];
                    JC_C[n] = JC_B[i];
                    
                    n++;
                }
            }
            else if (m == countB)
            {
                for (int i = k; i < countA; i++)
                {
                    AN_C[n] = AN_A[i];
                    JR_C[n] = JR_A[i];
                    JC_C[n] = JC_A[i];

                    n++;
                }
            }

            Console.Write("\n" + "\n" + "Sum matrix CSR format:" + "\n" + "AN = ");

            for (int i = 0; i < n; i++)
            {
                Console.Write(AN_C[i] + " ");
            }

            Console.Write("\n" + "JR = ");

            for (int i = 0; i < n; i++)
            {
                Console.Write(JR_C[i] + " ");
            }

            Console.Write("\n" + "JC = ");

            for (int i = 0; i < n; i++)
            {
                Console.Write(JC_C[i] + " ");
            }

            int[,] matrC = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    matrC[i, j] = 0;
                }
            }

            for(int i = 0; i < n; i++)
            {
                matrC[JR_C[i], JC_C[i]] = matrC[JR_C[i], JC_C[i]] + AN_C[i];
            }

            Console.Write("\n" + "\n" + "Unpacked sum matrix:" + "\n");

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    Console.Write(matrC[i, j] + "\t");
                }
                Console.WriteLine();
            }
       
            /*Сложение распакованных матриц*/

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                { 
                    matrC[i, j] = matrA[i, j] + matrB[i, j];
                }
            }

            Console.Write("\n" + "\n" + "Unpacked Matrix Adding sum Matrix:" + "" + "\n");

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    Console.Write(matrC[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}