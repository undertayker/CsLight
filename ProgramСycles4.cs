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
            Random random = new Random();

            int number = random.Next(0, 100);
            int minimumMultiple = 3;
            int maximumMultiple = 5;
            int amount = 0;
            Console.WriteLine("Числа кратные 3 или 5 : ");

            for (int i = 0; i < 100; i++)
                if (i % 3 == 0 || i % 5 == 0)
                {
                    Console.WriteLine(i);
                    amount += i;
                }

            Console.WriteLine("После суммы всех чисел мы получили : " + amount);
        }
    }
}


