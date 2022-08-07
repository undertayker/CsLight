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
            int multiple1 = 3;
            int multiple2 = 5;
            int amount = 0;
            Console.WriteLine("Числа кратные " + multiple1 + " или " + multiple2 );

            for (int i = 0; i < number; i++)
                if (i % multiple1 == 0 || i % multiple2 == 0)
                {
                    Console.WriteLine(i);
                    amount += i;
                }

            Console.WriteLine("После суммы всех чисел мы получили : " + amount);
        }
    }
}


