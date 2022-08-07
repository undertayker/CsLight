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
            int startValue = 5;
            int lastValue = 96;
            int step = 7;

            for (int i = startValue; i < lastValue + step ; i += step)
            {
                Console.WriteLine(i);              
            }
        }
    }
}


