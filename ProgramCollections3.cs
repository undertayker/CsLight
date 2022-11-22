using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string userInput;
            string sumCommand = "sum";
            string exitCommand = "exit";

            bool programmeWork = true;

            Console.WriteLine("Добро пожаловать в программу!");

            while (programmeWork)
            {
                Console.WriteLine($"\nДля суммы чисел введите команду : {sumCommand}\nДля выхода из программы введите команду : {exitCommand}\nВведите ваше число : ");
                userInput = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(userInput, out int result))
                {
                    numbers.Add(result);
                }
                else if (userInput == sumCommand)
                {
                    int sum = 0;

                    for (int i = 0; i < numbers.Count; i++)
                    {                       
                        sum += numbers[i];
                    }
                    Console.WriteLine("Ваше произведение чисел " + sum);
                    numbers.Clear();
                    Console.WriteLine("Лист с вашими числами очищен, введите числа занаво !");
                }
                else if (userInput == exitCommand)
                {
                    programmeWork = false;
                    Console.WriteLine("Всего хорошего!!");
                }

                Console.Write("Ваши введенные числа : ");
              
                foreach (int i in numbers)
                {
                    Console.Write(i + ",");
                }
            }
        }
    }
}