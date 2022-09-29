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
            Console.WriteLine($"Ты успешно конвертировал число " + GetNumber () + "\nВсего хорошего!!");
        }

        static int GetNumber()
        {
            bool isNumberEntered = false;
            int number = 0;

            while (isNumberEntered == false)
            {
                Console.Clear();
                Console.WriteLine("Введите число : ");

                string userInput = Console.ReadLine();

                isNumberEntered = int.TryParse(userInput, out number);
                Console.WriteLine(number);
            }
            return number;
        }
    }
}    