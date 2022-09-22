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
            string text = "Ехал Грека через реку видит Грека в реке рак";
            string[] proposalConclusion = text.Split(' ');

            foreach (string space in proposalConclusion)
            {
                Console.WriteLine(space);
            }
        }
    }
}