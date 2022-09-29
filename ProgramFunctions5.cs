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
            Stirring();
        }

        static void Stirring()
        {
            int[] stirringTheArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, };
            Random random = new Random();

            for (int i = stirringTheArray.Length - 1; i >= 1; i--)
            {
                int randomNumber = random.Next(i + 1);
                int shuffleIndex = stirringTheArray[randomNumber];
                stirringTheArray[randomNumber] = stirringTheArray[i];
                stirringTheArray[i] = shuffleIndex;
                Console.WriteLine(stirringTheArray[i]);
            }
        }
    }
}