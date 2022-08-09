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
            string userName;
            string characterInput = "";
            string simbol;
            int additionToLength = 2;

            Console.WriteLine("Введите ваше имя : ");
            userName = Console.ReadLine();
            Console.WriteLine("Введите символ : ");
            simbol = Console.ReadLine();
            Console.WriteLine("Ваше имя : ");
            Console.WriteLine(userName);
            Console.WriteLine("Ваш символ : ");
            Console.WriteLine(simbol);
           
            for (int i = 1; i <= (userName.Length + additionToLength + additionToLength); i += 1)
            {
                characterInput += simbol;
            }
            Console.WriteLine("Ваша картинка : ");
            Console.WriteLine(characterInput);
            Console.WriteLine(simbol + " " + userName + " " + simbol);
            Console.WriteLine(characterInput);
        }
    }
}


