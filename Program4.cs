using System;

namespace Exercise 
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Козловский";
            string secondName = "Андрей";
            Console.WriteLine("До : ");
            Console.WriteLine(name);
            Console.WriteLine(secondName);
            Console.WriteLine();

            string swapp;
            swapp = name;
            name = secondName;
            secondName = swapp;
            Console.WriteLine("После : ");
            Console.WriteLine(name);
            Console.WriteLine(secondName);
        }
    }
} 
    
