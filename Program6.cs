using System;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeOfReceipt = 10;
            Console.WriteLine("Введите количество людей в очереди : ");
            int people = int.Parse(Console.ReadLine());
            int minutesInHour = 60;
            int allMinutes = timeOfReceipt * people;
            int waitInHour = allMinutes / minutesInHour;
            int waitInMinutes = allMinutes % minutesInHour;

            Console.WriteLine("Вы должны отстоять в очереди {0} часa и {1} минут ", waitInHour, waitInMinutes);
        } 
    }
}