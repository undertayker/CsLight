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
            bool programWork = true;
            int[] array = new int[] { 1, 2, 3, 4 };
            Console.WriteLine("Добро пожаловать в программу по сдвигу массива");

            while (programWork)
            {
                Console.WriteLine("Для выхода из программы нажмите клавишу : ENTER");
                Console.WriteLine($"Ваш массив : ");

                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i]);
                }

                Console.Write($"Для сдвига массива введите число на которое хотите сдвинуть массив : ");
                int valueShift = int.Parse(Console.ReadLine());

                Console.Clear();

                for (int i = 0; i < valueShift; i++)
                {
                    for (int j = array.Length - 2; j > -1; j--)
                    {
                        int tempNumber = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = tempNumber;
                    }
                }
            }
        }
    }
}