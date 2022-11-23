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
            const string AddToFile = "1";
            const string FileData = "2";
            const string DeleteFile = "3";
            const string CommandExit = "4";

            Dictionary<string, string> dossiers = new Dictionary<string, string>();

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"\n{AddToFile}. Добавить досье \n{FileData}. Вывести все данные досье  \n{DeleteFile}. Удалить досье  \n{CommandExit}. Выход");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case AddToFile:
                        CreateDossier(dossiers);
                        break;
                    case FileData:
                        DataOutput(dossiers);
                        break;
                    case DeleteFile:
                        DeleteDossier(dossiers);
                        break;
                    case CommandExit:
                        isWork = false;
                        Console.WriteLine("Всего хорошего !");
                        break;
                }
            }
        }

        static void CreateDossier(Dictionary<string, string> dossiers)
        {
            Console.WriteLine("Введите вашу Фамилию : ");
            string surname = Console.ReadLine();
            Console.WriteLine("Введите вашу должность");
            string post = Console.ReadLine();

            if (dossiers.ContainsKey(surname))
            {
                Console.WriteLine("Досье " + surname + "-" + dossiers[surname] + " Уже существует!!");
            }
            else
            {
                Console.WriteLine("Досье добавлено " + surname + " - " + post);
                dossiers.Add(surname, post);
            }
        }

        static void DataOutput(Dictionary<string, string> dossiers)
        {
            foreach (var file in dossiers)
            {
                Console.WriteLine(file.Key + "-" + file.Value);
            }
        }

        static void DeleteDossier(Dictionary<string, string> dossiers)
        {
            Console.WriteLine("Укажите фамилию, которую хотите удалить из досье : ");
            string userInput = Console.ReadLine();

            if (dossiers.ContainsKey(userInput))
            {
                Console.WriteLine("Ваше досье удалено!");
                dossiers.Remove(userInput);
            }
            else
            {
                Console.WriteLine("Такого досье не существует!");
            }
        }
    }
}