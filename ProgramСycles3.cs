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

            int beginning = 5;
            int end = 100;
            int step = 7;

            for (int i = beginning; i < end; i += step)
            {
                Console.WriteLine(i);
            }
        }
    }
}


