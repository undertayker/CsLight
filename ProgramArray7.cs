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
            string text = "Ехал Грека через реку видит Грека в реке рак ";
            string[] proposalConclusion = text.Split(' ');

            Console.WriteLine(proposalConclusion[0]);
            Console.WriteLine(proposalConclusion[1]);
            Console.WriteLine(proposalConclusion[2]);
            Console.WriteLine(proposalConclusion[3]);
            Console.WriteLine(proposalConclusion[4]);
            Console.WriteLine(proposalConclusion[5]);
            Console.WriteLine(proposalConclusion[6]);
            Console.WriteLine(proposalConclusion[7]);
            Console.WriteLine(proposalConclusion[8]);
        }
    }
}