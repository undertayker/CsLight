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

            int theDepth = 0;
            int maximumDepth = 0;

            for (int i = 0; i < length; i++)
            {
                if (userInput[i] == '(')
                {
                    theDepth++;
                }
                else if (userInput[i] == ')')
                {
                    maximumDepth++;
                }
                if (maximumDepth == theDepth)
                {
                    maximumDepth = theDepth;
                                  
                }
                if (maximumDepth == theDepth)
                {
                    maximumDepth--;
                    Console.WriteLine("Ваше выражение корректно ! " );
                }
               else if (maximumDepth != theDepth)
                {
                    Console.WriteLine("Ваше выражение не корректно ! ");
                }
                Console.WriteLine("Максимальная глубина : " + maximumDepth);
            }
        }
    }
}







