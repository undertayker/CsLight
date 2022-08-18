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
            string userInput;
            int symbolToTheLeftSide = 0;
            int symbolToTheRightSide = 0;
            int counter1 = 0;
            int counter2 = 0;
            int final = 0;
            int count = 0;

            Console.WriteLine("Введите любое количество символов '(' и ')' и программа посчитает\nявляется ли выражение корректным и посчитает глубину вложения : ");
            userInput = Console.ReadLine();

            if (userInput.Length == 0)
            {
                Console.WriteLine("Ошибка!!!");
            }

            for (int i = 0; i < userInput.Length; i++)
            {

                if (userInput[i] == '(')
                {
                    symbolToTheLeftSide++;
                }
                else if (userInput[i] == ')')
                {
                    if (i != userInput.Length - 1 && userInput[i + 1] != '(')
                    {
                        count++;
                        symbolToTheLeftSide--;
                    }
                }
                if (userInput[i] == '(')
                {
                    symbolToTheLeftSide++;
                }
                if (userInput[i] == ')')
                {
                    symbolToTheRightSide++;
                }
            }

            if (symbolToTheLeftSide != symbolToTheRightSide)
            {
                Console.WriteLine("Ваша строка корректна ! ");
            }
            else if (symbolToTheLeftSide == symbolToTheRightSide)
            {
                Console.WriteLine("Ваша строка не корректна ! ");
            }

            for (int i = 0; i < userInput.Length; i++)
            {
                if (userInput[i] == ')')
                {
                    counter1++;
                }
                else
                {
                    counter1 = 0;
                }
                if (counter1 > 0)
                {
                    if (counter2 <= counter1)
                    {
                        counter2 = counter1;
                        final = counter2 + 1;
                    }
                }
            }
            Console.WriteLine("Максимальная глубина скобок : " + final);
        }
    }
}




