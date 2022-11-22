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
            string sumCommand = "sum";
            string exitCommand = "exit";

            bool isProgrammeWork = true;

            Console.WriteLine("Добро пожаловать в программу!");

            while (isProgrammeWork)
            {
                Console.WriteLine($"\nДля суммы чисел введите команду : {sumCommand}\nДля выхода из программы введите команду : {exitCommand}\nВведите ваше число : ");
                string userInput = Console.ReadLine();
                Console.Clear();

                if (int.TryParse(userInput, out int result))
                {         
                    numbers.Add(result);
                    Console.Write("Ваши введенные числа : ");
                }
                else if (userInput == sumCommand)
                {
                    Sum(numbers);             
                }
                else if(userInput == exitCommand)
                {
                    isProgrammeWork = false;
                    Console.WriteLine("Всего хорошего!!");                   
                }

                foreach (int number  in numbers)
                {
                    Console.Write(number  + ",");
                }
            }
        }

        static void Sum(List<int> numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine($"Ваше произведение чисел " + sum);
            numbers.Clear();
            Console.WriteLine("Лист с вашими числами очищен, введите числа занаво !");
        }
    }
}