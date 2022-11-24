using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = { 1, 1, 1, 2, 3, 3, 3 };
            int[] secondArray = { 2, 3, 3, 3, 4, 5, 5 };

            List<int> numbers = new List<int>();

            AddInclusiveElements(numbers, firstArray);
            AddInclusiveElements(numbers, secondArray);

            Show(numbers);
        }

        static void AddInclusiveElements(List<int> numbers, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (numbers.Contains(array[i]) == false)
                {
                    numbers.Add(array[i]);
                }
            }
        }

        static void Show(List<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}