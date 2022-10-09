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
            string userInput;

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Компьютер", "это — устройство или система, способная автоматически выполнять заданную, изменяемую последовательность операций.");
            dictionary.Add("Процессор", "это - Центральная часть компьютера, выполняющая заданные программой преобразования информации и осуществляющая управление всем вычислительным процессом.");
            dictionary.Add("Оперативная память", "это - в большинстве случаев энергозависимая часть системы компьютерной памяти, в которой во время работы компьютера хранится выполняемый машинный код");

            Console.WriteLine("Добро пожаловать в мой небольшой словарь,в нем ты можешь узнать что такое :\nКомпьютер\nПроцессор\nОперативная память\nДля этого просто введи слово которое тебе интерестно :");

            WordEntry(out userInput);

            Console.Clear();

            FindWord(dictionary, userInput);
        }

        static void WordEntry(out string userInput)
        {
            userInput = Console.ReadLine();
        }

        static void FindWord(Dictionary<string, string> dictionary, string userInput)
        {
            bool isWork = false;

            foreach (var word in dictionary)
            {
                if (userInput == word.Key)
                {
                    Console.WriteLine(dictionary[userInput]);
                    isWork = true;
                }
            }

            if (isWork == false)
            {
                Console.WriteLine("Данного слова в словаре нет!\nВсего хорошего, возвращайтесь к нам снова");
            }
        }
    }
}