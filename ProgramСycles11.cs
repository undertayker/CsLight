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
            Console.WriteLine("Введите любое количество символов '(' и ')' и программа посчитает\nявляется ли выражение корректным и посчитает глубину вложения : ");
            string userInput = Console.ReadLine();
            int length = userInput.Length;         

            if (length == 0)
            {
                Console.WriteLine("Ошибка!");
                return;
            }

            int depth = 0;
            int maximumDepth = 0;

            for (int i = 0; i < length; i++)
            {
                if (userInput[i] == '(')
                {
                    depth++;
                }

                if (userInput[i] == ')')
                {
                    maximumDepth++;

                }

            }
            if (maximumDepth == depth)
            {
                Console.WriteLine("Ваше выражение не корректно ! ");
            }

            if (maximumDepth != depth)
            {
                
                Console.WriteLine("Ваше выражение корректно ! ");
                Console.WriteLine("Максимальная глубина : " + maximumDepth);

            }
        }
    }
}







