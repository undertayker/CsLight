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

            Dictionary<string, string> data = new Dictionary<string, string>();

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"\n{AddToFile}. Добавить досье \n{FileData}. Вывести все данные досье  \n{DeleteFile}. Удалить досье  \n{CommandExit}. Выход");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput) 
                {
                    case AddToFile:
                        CreateDossier(data);
                        break;
                    case FileData:
                        DataOutput(data);
                        break;
                    case DeleteFile:
                        DeleteTheDossier(data);
                        break;
                    case CommandExit:
                        isWork = false;
                        Console.WriteLine("Всего хорошего !");
                        break;
                }
            }
        }

        static void CreateDossier(Dictionary<string,string> data)
        {
            Console.WriteLine("Введите вашу Фамилию : ");
            string surnames = Console.ReadLine();
            Console.WriteLine("Введите вашу должность");
            string posts = Console.ReadLine();
            
            if (data.ContainsKey(surnames))
            {
                Console.WriteLine("Досье " + surnames + "-" + data[surnames] + " Уже существует!!" );
            }
            else
            {
                Console.WriteLine("Досье добавлено " + surnames + " - " + posts );
                data.Add(surnames, posts);
            }
        }

        static void DataOutput(Dictionary<string,string> data)
        {
            foreach (var file in data)
            {
                Console.WriteLine(file.Key + "-" + file.Value);
            }
        }

        static void DeleteTheDossier(Dictionary<string,string> data)
        {
            Console.WriteLine("Укажите фамилию, которую хотите удалить из досье : ");
            string userInput = Console.ReadLine();

            if (data.ContainsKey(userInput))
            {
                Console.WriteLine("Ваше досье удалено!");
                data.Remove(userInput);
            }
            else
            {
                Console.WriteLine("Такого досье не существует!");
            }       
        }
    }
}