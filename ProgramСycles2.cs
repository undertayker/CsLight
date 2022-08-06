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
    
            string exit = "";

            Console.WriteLine("вы попали ко мне в лавушку, из нее нет выхода, только если вы не знаете секретного пароля");
            Console.WriteLine("Введите секретный пароль для выхода отсюда :");
            Console.ReadLine();

            while (exit != "exit")
            {
                Console.WriteLine("ХА ХА ХА, вы не угадали попробуйте еще раз");
                exit = Console.ReadLine();
            }
        }
    }
}


