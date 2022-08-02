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
            int userInput = 10;
            int countOfRepetitions;

            Console.WriteLine("Введите кол-во повторений вашего сообщения: ");
            countOfRepetitions = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < countOfRepetitions ; i ++ )
            {
                Console.WriteLine("Введите ваше сообщение: ");
                userMessage = Console.ReadLine();
            }                                                       
        }
    }
}


