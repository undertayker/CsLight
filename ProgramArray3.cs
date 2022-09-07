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
            int[] array = new int[30];
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 9);
                Console.Write(array[i] + " ");

                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }                  
            }

            Console.Write("Локальные максимумы: ");

            int localMaxCount = 1;
            bool repeatCheck = true;

            if (array[0] > array[1])
            {
                Console.Write(localMaxCount++ + ")" + array[0] + " ");
            }
                
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i] > array[i - 1] && array[i] > array[i + 1])
                {
                    Console.Write(localMaxCount + ")" + array[i] + " ");
                    localMaxCount++;
                    repeatCheck = true;
                }

                if ((localMaxCount - 1) % 10 == 0 && repeatCheck)
                {
                    Console.WriteLine();
                    repeatCheck = false;
                }
            }

            if (array[array.Length - 1] > array[array.Length - 2])
            {
                Console.Write(localMaxCount + ")" + array[array.Length - 1] + " ");
            }

            Console.WriteLine();
        }
    }
}






