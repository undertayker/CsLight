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
            int[,] array = new int[10, 10];               
            int sum = 0;
            int productNumbers = 1;
            int selectedRow = 2;
            int selectedColumn = 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = random.Next(1,10);
                    Console.WriteLine(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                sum += array[selectedRow - 1 ,i];
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                productNumbers *= array[i, selectedColumn - 1];
            }

            Console.WriteLine($"Сумма {selectedRow} строки равна : {sum}");
            Console.WriteLine($"Произведение {selectedColumn} столбца равна : {productNumbers}");
        }
    }
}






