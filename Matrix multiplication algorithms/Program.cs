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
            Console.WriteLine("Input quantity of rows matrix A:");
            int k = int.Parse(Console.ReadLine());

            Console.Write("\n");

            Console.WriteLine("Input quantity of columns matrix A:");
            int l = int.Parse(Console.ReadLine());

            Console.Write("\n");

            Matrix A = new Matrix(k, l);

            A.matrInput();
            A.matrOutput();

            Console.WriteLine("Input quantity of rows matrix B:");
            int m = int.Parse(Console.ReadLine());

            Console.Write("\n");

            Console.WriteLine("Input quantity of columns matrix B:");
            int n = int.Parse(Console.ReadLine());

            Console.Write("\n");

            Matrix B = new Matrix(m, n);

            B.matrInput();
            B.matrOutput();

            Matrix C = new Matrix(k, n);

            Console.Write("Standart algorithm:" + "\n");

            C.Mult(A, B);

            Console.Write("\n");
            Console.Write("Winograd algorithm:" + "\n");

            C.Winograd(A, B);

            Console.ReadLine();
        }
    }
}
