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

            int minNumber = 0;
            int maxNumber = 100;
            int degree = 0;
            int graduation = 2;
            int finalNumber = 0;

            int number = random.Next(minNumber, maxNumber);

            while (Math.Pow(graduation,degree) <= number)
            {
                degree++;
                finalNumber = Convert.ToInt32(Math.Pow(graduation, degree));
            }

            Console.WriteLine("Слуайное число : " + number);
            Console.WriteLine("Cтепень двойки : " + degree);
            Console.WriteLine("Число в найенной степени : " + finalNumber); 
        }
    }
}


