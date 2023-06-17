using System;
using System.Collections.Generic;

namespace SyntaxCompiler
{
    class Program
    {
        private const string Caminho = "C:\xampp\\htdocs\\Compilador\\cavalo.txt";

        static void Main(string[] args)
        {
            string caminho = Caminho;
            /*
            try
            {
                using (StreamReader sr = new StreamReader(caminho))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            */
            Console.WriteLine("Enter a program to check its syntax:");
            string program = Console.ReadLine();

            if (VerificarSintaxe(program))
                Console.WriteLine("Syntax is correct.");
            else
                Console.WriteLine("Syntax is incorrect.");
        }

        static bool VerificarSintaxe(string program)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in program)
            {
                if (IsOpeningBracket(c))
                    stack.Push(c);
                else if (IsClosingBracket(c))
                {
                    if (stack.Count == 0 || !IsMatchingPair(stack.Pop(), c))
                        return false;
                }
            }

            return stack.Count == 0;
        }

        static bool IsOpeningBracket(char c)
        {
            return c == '(' || c == '[' || c == '{';
        }

        static bool IsClosingBracket(char c)
        {
            return c == ')' || c == ']' || c == '}';
        }

        static bool IsMatchingPair(char opening, char closing)
        {
            return (opening == '(' && closing == ')') ||
                   (opening == '[' && closing == ']') ||
                   (opening == '{' && closing == '}');
        }
    }
}
