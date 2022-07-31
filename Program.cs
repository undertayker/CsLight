using System;

namespace Exercise_7
{
    class Program6
    {
        static void Main(string[] args)
        {
            string name = " Андрей ";
            int age = 23;
            double weight = 70;
            object citizen = "Беларуси";
            long weather = -10;
            bool isEmployed = false;
            uint salary = 20000;
            ulong population = 9255524;
            byte regions = 7;
            ushort sister = 1;

            Console.WriteLine($"имя: {name} ");
            Console.WriteLine($"возрост: {age}");
            Console.WriteLine($"вес: {weight}");
            Console.WriteLine($"гражданин: {citizen}");
            Console.WriteLine($"погода: {weather}");
            Console.WriteLine($"на счет погоды {isEmployed}");
            Console.WriteLine($"зарплата: {salary}");
            Console.WriteLine($"население: {population}");
            Console.WriteLine($"районов: {regions}");
            Console.WriteLine($"сестра: {sister}");
        }
    }
} 
    
