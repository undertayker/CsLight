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
            int storeBill = 0;
            bool isWork = true;
            Queue<int> purchaseAmount = new Queue<int>();

            purchaseAmount.Enqueue(200);
            purchaseAmount.Enqueue(400);
            purchaseAmount.Enqueue(630);
            purchaseAmount.Enqueue(2204);
            purchaseAmount.Enqueue(3400);

            while (isWork)
            {
                foreach (var amount in purchaseAmount)
                {
                    Console.WriteLine("Покупатель набрал на сумму " + amount + " рублей ");
                }

                storeBill += purchaseAmount.Peek();

                Console.WriteLine("Сейчас в очереди покупатель который набрал продуктов на сумму " + purchaseAmount.Dequeue() + " Рублей ");
                Console.WriteLine("Cчет магазина составляет " + storeBill + " рублей ");
                Console.ReadKey();
            }           
        }
    }
}