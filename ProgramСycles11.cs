using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            const char openedScope = '(';
            const char closingScope = ')';           
            int depth = 0;
            int maximumDepth = 0;

            Console.WriteLine("Введите любое количество символов '(' и ')' и программа посчитает\nявляется ли выражение корректным и посчитает глубину вложения : ");
            string userInput = Console.ReadLine();

            foreach (char currentChar in userInput)
            {
                if (currentChar == openedScope)
                {
                    depth++;

                    bool isValidCoutHighterDeep = (depth > maximumDepth);

                    if (isValidCoutHighterDeep == true)
                    {
                        maximumDepth = depth;
                    }
                }

                if (currentChar == closingScope)
                {
                    depth--;
                }

                if (depth < 0)
                {
                    break;
                }
            }

            if (depth == 0)
            {
                Console.WriteLine("Строка корректна.");
                Console.WriteLine("Максимальная глубина: " + maximumDepth);
            }
            else
            {
                Console.WriteLine("Строка некорректна.");
            }
        }
    }
}






