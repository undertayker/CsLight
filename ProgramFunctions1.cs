using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] surnames = new string[0];
            string[] posts = new string[0];
            bool isWork = true;
            const string AddToFile = "1";
            const string FileData = "2";
            const string DeleteFile = "3";
            const string SearchFor= "4";
            const string CommandExit = "5";


            while (isWork == true)
            {
                Console.WriteLine($"\n{AddToFile}. Добавить досье \n{FileData}. Вывести все данные досье  \n{DeleteFile}. Удалить досье  \n{SearchFor}. Поиск по фамилии  \n{CommandExit}. Выход");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddToFile :
                        CreateDossier(ref surnames, ref posts);
                        break;
                    case FileData:
                        OutputInfoDossier(surnames, posts);
                        break;
                    case DeleteFile:
                        DeleteDossier(ref surnames, ref posts);
                        break;
                    case SearchFor:
                        SearchDossier(surnames, posts);
                        break;
                    case CommandExit:
                        isWork = false;
                        break;
                }
            }
        }

        static void CreateDossier(ref string[] surnames, ref string[] posts)
        {
            Console.WriteLine("Введите фамилию : ");
            string surname = Console.ReadLine();
            ExpandArray(surname, ref surnames);
            Console.WriteLine("Введите должность : ");
            string post = Console.ReadLine();
            ExpandArray(post, ref posts);

            Console.WriteLine("Данные добавлены! ");
        }

        static void DeleteDossier(ref string[] firstArray, ref string[] secondArray)
        {
            if (firstArray.Length != 0)
            {
                Console.WriteLine("Введите номер досье для удаления : ");
                int numberDelete = int.Parse(Console.ReadLine());
                ReduceArray(numberDelete, ref firstArray);
                ReduceArray(numberDelete, ref secondArray);

                Console.WriteLine("Данные удалены ! ");
            }
            else
            {
                Console.WriteLine("В досье еще нет данных ");
            }
        }

        static void ExpandArray(string word, ref string[] array)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[tempArray.Length - 1] = word;
            array = tempArray;
        }

        static void OutputInfoDossier(string[] firstArray, string[] secondArray)
        {
            if (firstArray.Length != 0)
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {firstArray[i]} - {secondArray[i]}");
                }
            }
            else
            {
                Console.WriteLine("В досье еще нет данных!");
            }
        }

        static void ReduceArray(int numberDelete, ref string[] array)
        {
            if (array.Length != 0)
            {
                string[] tempArray = new string[array.Length - 1];
                int position = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (i != (numberDelete - 1))
                    {
                        tempArray[position] = array[i];
                        position++;
                    }
                }

                array = tempArray;

            }
            else
            {
                Console.WriteLine("В досье еще нет данных !");
            }
        }

        static void SearchDossier(string[] firstArray, string[] secondArray)
        {
            if (firstArray.Length != 0)
            {
                Console.WriteLine("Введите фамилию : ");
                string surnameSearch = Console.ReadLine();
                bool theFollowingWasFound = false;
                bool noDossierFound = true;

                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] == surnameSearch)
                    {
                        if (theFollowingWasFound == false)
                        {
                            Console.WriteLine("Найдено следующее : ");
                            theFollowingWasFound = true;
                        }
                        Console.WriteLine($"{i + 1}. {firstArray[i]}-{secondArray[i]}");
                        noDossierFound = false;
                    }
                }

                if (noDossierFound == true)
                {
                    Console.WriteLine("Фамилия не найдена! ");
                }
            }
            else
            {
                Console.WriteLine("В досье еще нет данных! ");
            }
        }
    }
}