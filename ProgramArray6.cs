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
            int[] array = { 1, 4, 3, 8, 6, 5, 2, 7, 9, 10 };

            int sorting = 0;
            
            for(int i = 0; i < array.Length; i++)
            {

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        sorting = array[i];
                        array[i] = array[j];
                        array[j] = sorting;
                    }
                }
            }
            Console.WriteLine("Отсортированный массив : ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);    
            }
        }
    }
}






