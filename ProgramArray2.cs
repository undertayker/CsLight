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
            int[] coordinates = new int[2];
            Console.WriteLine("Исходная  матрица : ");

            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    array[i, j] = random.Next(1, 100);
                    Console.WriteLine(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            int largestNumber = int.MinValue;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > largestNumber)
                    {
                        largestNumber = array[i, j];
                        coordinates[0] = i;
                        coordinates[1] = j;
                    }
                }
            }

            Console.WriteLine("Наибольший элемент матрицы : " + largestNumber);   
            
            Console.WriteLine("Измененная матрица : ");         
           
            for (int i = 0; i < array.GetLength(0); i++)
            {
               for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i,j] == largestNumber)
                    {
                        array[i,j] = 0;
                    }

                    Console.WriteLine(array[i,j] + " ");
                }
               
            }         
            Console.WriteLine();
        }
    }
}






