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

            int maximumNaturalNumber = 999;
            int minimumNaturalNumber = 100;
            int minimalNumber = 1;
            int maximumNamber = 27;
            int numberOfNaturalNumbers = 0;

            Random random = new Random();
            int randomNumbers = random.Next(minimalNumber, maximumNamber);

            for (int i = 0; i < maximumNaturalNumber; i += randomNumbers)
            {
                if (i >= minimumNaturalNumber)
                {
                    numberOfNaturalNumbers++;
                }
            }

            Console.WriteLine($"Количество трехзначных натуральных чисел, кратных {randomNumbers}, будет :{numberOfNaturalNumbers} ");
            Console.ReadLine();

        }
    }
}


