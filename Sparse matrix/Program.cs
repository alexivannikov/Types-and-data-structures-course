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
            Console.WriteLine("Input quantity of rows:");
            int m = int.Parse(Console.ReadLine());

            Console.Write("\n");

            Console.WriteLine("Input quantity of columns:");
            int n = int.Parse(Console.ReadLine());

            Console.Write("\n");

            Matrix matr = new Matrix(m, n);
            Matrix A = new Matrix(m, n);
            Matrix B = new Matrix(m, n);
            Matrix C = new Matrix(m, n);

            matr.matrInput();
            matr.matrOutput();
            matr.CSR(A);
            matr.CSROutput();
            matr.Unpack(A);
            matr.unpackOutput();

            Console.ReadLine();
        }
    }
}