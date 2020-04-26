using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Обратная_польская_запись
{
    class RPN
    {
        static private bool isDelimeter(char s)
        {
            if ((" =".IndexOf(s) != -1))
            {
                return true;
            }

            return false;
        }

        static private bool isOperator(char s)
        {
            if (("+-/*^()".IndexOf(s) != -1))
            {
                return true;
            }

            return false;
        }

        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }

        static public double Calculate(string input)
        {
            string output = getExpression(input);
            double result = Counting(output); 

            return result;
        }

        static private string getExpression(string input)
        {
            string output = string.Empty; 

            Stack<char> opStack = new Stack<char>(); 

            for (int i = 0; i < input.Length; i++) 
            {

                if (isDelimeter(input[i]))
                {
                    continue;
                }


                if (Char.IsDigit(input[i])) 
                {
                    while (!isDelimeter(input[i]) && !isOperator(input[i]))
                    {
                        output += input[i]; 

                        i++;

                        if (i == input.Length)
                        {
                            break;
                        }
                    }

                    output += " ";

                    i--; 
                }

                if (isOperator(input[i])) 
                {
                    if (input[i] == '(')
                    {
                        opStack.Push(input[i]);
                    }
                    else if (input[i] == ')') 
                    {
                        char s = opStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + " ";
                            s = opStack.Pop();
                        }
                    }
                    else 
                    {
                        if (opStack.Count > 0)
                        {
                            if (GetPriority(input[i]) <= GetPriority(opStack.Peek()))
                            {
                                output += opStack.Pop().ToString() + " ";
                            }
                        }

                        opStack.Push(char.Parse(input[i].ToString())); 
                    }
                }
            }

            while (opStack.Count > 0)
            {
                output += opStack.Pop() + " ";
            }

            Console.Write(output + "\n");

            return output;
        }

        static private double Counting(string input)
        {
            double result = 0; 

            Stack<double> temp = new Stack<double>();

            for (int i = 0; i < input.Length; i++) 
            {
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!isDelimeter(input[i]) && !isOperator(input[i])) 
                    {
                        a += input[i];

                        i++;

                        if (i == input.Length)
                        {
                            break;
                        }
                    }

                    temp.Push(double.Parse(a));

                    i--;
                }
                else if (isOperator(input[i])) 
                {
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i]) 
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                    }
                    temp.Push(result); 
                }
            }
            return temp.Peek(); 
        }
    }
}


