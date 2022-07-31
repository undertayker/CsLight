using System;

namespace Exercise1 
{
    class Program1
    {
        static void Main(string[] args)
        {
            string userName;
            string year;
            string zodiacSign;
            string work;

            Console.WriteLine("Введите ваше имя : ");
            userName = Console.ReadLine();
            Console.WriteLine("Сколько вам лет : ");
            year = Console.ReadLine();
            Console.WriteLine("Ваш знак зодиака : ");
            zodiacSign = Console.ReadLine();
            Console.WriteLine("Где вы работаете : ");
            work = Console.ReadLine();
            Console.WriteLine("Вас зовут : " + userName);
            Console.WriteLine("Вам : " + year + "год");
            Console.WriteLine("Вы : " + zodiacSign);
            Console.WriteLine("Вы работаете : " + work);
        }
    }
} 
    
