using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            ShuffleArray(array);
        }

        static void ShuffleArray(int[] array)
        {
            Random random = new Random();
            int randomIndex;
            int shuffledEllement;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                randomIndex = random.Next(i);
                shuffledEllement = array[randomIndex];
                array[randomIndex] = array[i];
                array[i] = shuffledEllement;

                Console.WriteLine(shuffledEllement + " ");
            }
        }
    }
}