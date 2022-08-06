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
            int tryCount = 1000;
            string exit = "exit";
            string userInput;

            Console.WriteLine("вы попали ко мне в лавушку, из нее нет выхода, только если вы не знаете секретного пароля");
            Console.WriteLine("Введите секретный пароль для выхода отсюда :");

            for (int i = 0; i < tryCount; i++)
            {
                
                userInput = Console.ReadLine();
                
                if(exit == userInput)
                {
                    Console.WriteLine("Нееет, как ты смог угадать ");
                    break;
                }
                else
                {
                    Console.WriteLine("ХА ХА ХА вам не удалось угадать, попробуйте еще раз :");
                }
            }
        }    
    }
}


