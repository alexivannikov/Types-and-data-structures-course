using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расстояние_Левенштейна
{
    class Program
    {
        static int Minimum(int a, int b)
        {
            if (a < b)
                return a;
            else
                return b;
        }

        static int Minimum(int a, int b, int c)
        {
            int d;

            if (a < b)
                d = a;
            else
                d = b;

            if (d < c)
                return d;
            else
                return c;
        }

        static int LevenshteinDistance(string s1, string s2)
        {
            int m = s1.Length + 1;
            int n = s2.Length + 1;
            int [,] matrixD = new int[m, n];

            int Wdelete = 1;
            int Winsert = 1;
            int Wreplace = 0;

            for (int i = 0; i < m; i++)
            {
                matrixD[i, 0] = i;
            }

            for (int j = 0; j < n; j++)
            {
                matrixD[0, j] = j;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        Wreplace = 0;
                    }
                    else
                    {
                        Wreplace = 1;
                    }

                    matrixD[i, j] = Minimum(matrixD[i - 1, j] + Wdelete,       
                                            matrixD[i, j - 1] + Winsert,       
                                            matrixD[i - 1, j - 1] + Wreplace); 
                }
            }

            return matrixD[m - 1, n - 1];
        }

        static int DamerauLevenshteinDistance(string s1, string s2)
        {
            int m = s1.Length + 1;
            int n = s2.Length + 1;
            int [,] matrixD = new int[m, n];

            int Wdelete = 1;
            int Winsert = 1;
            int Wreplace = 0;
            int Wtranspose = 1;

            for (int i = 0; i < m; i++)
            {
                matrixD[i, 0] = i;
            }

            for (int j = 0; j < n; j++)
            {
                matrixD[0, j] = j;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if(s1[i-1] == s2[j-1])
                    {
                        Wreplace = 0; 
                    }
                    else
                    {
                        Wreplace = 1;
                    }

                    matrixD[i, j] = Minimum(matrixD[i - 1, j] + Wdelete,  
                                            matrixD[i, j - 1] + Winsert,
                                            matrixD[i - 1, j - 1] + Wreplace); 

                    if (i > 1 && j > 1
                        && s1[i - 1] == s2[j - 2]
                        && s1[i - 2] == s2[j - 1])
                    {
                        matrixD[i, j] = Minimum(matrixD[i, j],
                                                matrixD[i - 2, j - 2] + Wtranspose); 
                    }
                }
            }

            return matrixD[m - 1, n - 1];
        }

        static void Main(string[] args)
        {
            Console.Write("Первое слово: ");
            string w1 = Console.ReadLine();

            Console.Write("Второе слово: ");
            string w2 = Console.ReadLine();

            Console.Write("\n");

            Console.Write("Расстояние Левенштейна: {0}", LevenshteinDistance(w1, w2));

            Console.Write("\n");

            Console.Write("Расстояние Дамерау-Левенштейна: {0}", DamerauLevenshteinDistance(w1, w2));

            Console.ReadLine();
        }
    }
}
