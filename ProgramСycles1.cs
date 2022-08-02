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

            string userMessage;
            int userInput;
            int numberOfRepetitions;

            Console.WriteLine("Введите ваше сообщение: ");
            userMessage = Console.ReadLine();
            Console.WriteLine("Введите кол-во повторений вашего сообщения: ");
            numberOfRepetitions = Convert.ToInt32(Console.ReadLine());

            while (numberOfRepetitions > 0 )
            {
                Console.WriteLine(userMessage);
                numberOfRepetitions--;               
            }
        }
    }
}


