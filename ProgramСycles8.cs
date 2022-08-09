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
            string password = "0258";
            string userInput;
            int tryCount = 3;

            Console.WriteLine("Добро пожаловать в тайное хранилище\nДля открытия секретного сундука введите пароль : ");

            for (int i = 0; i < tryCount; i++)
            {
                userInput = Console.ReadLine();

                if (password == userInput)
                {
                    Console.WriteLine("Ура вы открыли сундук, на ваш счет зачисленно 1000000000$");
                    break;
                }
                else
                {
                    Console.WriteLine("К сожалению вы не угадали ");
                    Console.WriteLine("У вас осталось " + (tryCount - i -1) + " попытки ");
                    
                }
            }  
        }
    }
}


