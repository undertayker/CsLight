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
            int[] array = new int[0];
            string userInput;           
            string sumOfNumbers = "sum";
            string exit = "exit";

            bool programmeWork = true;

            Console.WriteLine("Добро пожаловать в программу!");

            while (programmeWork)
            {              
                int numberInArray;
               
                Console.WriteLine("Введите ваше число : ");
                numberInArray = Convert.ToInt32(Console.ReadLine());
                int[] tempArray = new int[array.Length + 1];
                Console.Write("Ваши введенные числа : ");
                
                for (int i = 0; i < array.Length; i++)
                {
                    tempArray[i] = array[i];
                }

                tempArray[array.Length] = numberInArray;
                array = tempArray;

                foreach (int number in array)
                {
                    Console.Write(number + ", ");
                }

                Console.WriteLine($"\nДля суммы чисел введите команду : {sumOfNumbers}\nДля выхода из программы введите команду : {exit}\nДля продолжения ввода чисел нажмите любую клавишу ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                   
                    case "sum":
                        int sum = 0;

                        for (int j = 0; j < array.Length; j++)
                        {
                            sum += array[j];
                        }

                        Console.WriteLine($"Сумма ваших чисел равна : {sum}");
                        break;
                    case "exit":
                        programmeWork = false;
                        Console.WriteLine("Спасибо что пользовались нашей программой, возвращайтесь снова! ");
                        break;

                }
            }
        }
    }
}






