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
            int[] array = new int[30];
            Random random = new Random();

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0,10);
                Console.WriteLine(array[i] + " ");
            }
            Console.WriteLine("Локальный максимум : ");

            for(int i = 1; i < array.Length - 1; i++)
            {
                if(array[i - 1] < array[i] && array[i] > array[i + 1])
                {
                    Console.WriteLine( array[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}






