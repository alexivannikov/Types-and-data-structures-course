using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Обратная_польская_запись
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) { 
                Console.Write("Введите выражение: ");
                Console.WriteLine(RPN.Calculate(Console.ReadLine())); 
            }
        }
    }
}
