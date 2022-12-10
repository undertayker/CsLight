using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            database.Work();
        }
    }

    class Database
    {
        private bool _isWork = true;
        private List<Player> _players = new List<Player>();

        private void AddPlayer()
        {
            string name;
            string level;
            int result;
            bool isStringNumber;

            Console.Write("Введите никнейм игрока: ");
            name = Console.ReadLine();
            Console.Write("Какой у него уровень: ");
            isStringNumber = CheckString(out level, out result);

            if (isStringNumber)
            {
                _players.Add(new Player(name, result));
            }
            else
            {
                GetMessege("Введите корректные данные");
            }
            Console.Clear();
        }

        private void GetMessege(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
            Console.Clear();
        }

        private bool CheckString(out string userInput, out int result)
        {
            userInput = " ";
            result = 0;
            bool isStringNumber;

            userInput = Console.ReadLine();
            isStringNumber = int.TryParse(userInput, out result);
            return isStringNumber;
        }

        private void ShowInfo()
        {
            Console.WriteLine("База данных игроков:");

            for (int i = 0; i < _players.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _players[i].ShowDetails();
            }
            Console.ReadKey();
            Console.Clear();
        }

        private void RemovePlayer()
        {
            string userInput;
            int result;
            bool isStringNumber;

            if (_players.Count > 0)
            {
                ShowInfo();
                Console.Write("Какого игрока удалить из базы данных, ведите порядковый номер: ");
                isStringNumber = CheckString(out userInput, out result);

                if (isStringNumber)
                {
                    _players.RemoveAt(result - 1);
                    Console.Clear();
                }
                else
                {
                    GetMessege("Не корректный ввод");
                }
            }
            else
            {
                GetMessege("База данных пуста");
            }
        }

        private void BanPlayer()
        {
            string userInput;
            int result;
            bool isConsoleBanActive = false;

            if (_players.Count > 0)
            {
                ShowInfo();
                Console.Write("Введите порядковый номер игрока, которого хотите забанить: ");
                isConsoleBanActive = CheckString(out userInput, out result);
                Console.Clear();

                if (isConsoleBanActive)
                {
                    if (_players[result - 1].IsBanned == false)
                    {
                        _players[result - 1].AddToBan();
                    }
                    Console.Clear();
                }
                else
                {
                    GetMessege("Данные не корректны");
                }
            }
            else
            {
                GetMessege("Ваш сервер пустой");
            }
        }

        private void UnbanPlayer()
        {
            string userInput;
            int result;
            bool isConsoleBanActive = false;

            if (_players.Count > 0)
            {
                ShowInfo();
                Console.Write("Введите порядковый номер игрока, которого хотите разбанить: ");
                isConsoleBanActive = CheckString(out userInput, out result);
                Console.Clear();

                if (isConsoleBanActive)
                {
                    if (_players[result - 1].IsBanned == true)
                    {
                        _players[result - 1].RemoveFromBan();
                    }
                    Console.Clear();
                }
                else
                {
                    GetMessege("Данные не корректны");
                }
            }
            else
            {
                GetMessege("Ваш сервер пустой");
            }
        }

        public void Work()
        {
            string userInput;

            while (_isWork)
            {
                Console.WriteLine("Добро пожаловать, это меню базы данных.");
                Console.WriteLine("1 - Добавить игрока.\n2 - Список игроков.\n3 - Забанить игрока.\n4 - Разбанить игрока.\n5 - Удалить игрока.\n6 - Выход.");
                Console.Write("Выберите команду: ");
                userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        AddPlayer();
                        break;
                    case "2":
                        ShowInfo();
                        break;
                    case "3":
                        BanPlayer();
                        break;
                    case "4":
                        UnbanPlayer();
                        break;
                    case "5":
                        RemovePlayer();
                        break;
                    case "6":
                        _isWork = false;
                        break;
                    default:
                        Console.WriteLine("Не корректный ввод");
                        break;
                }
            }
        }
    }

    class Player
    {
        private string _name;
        private int _level;
        private string _flag;
        public bool IsBanned { get; private set; }

        public Player(string name, int level)
        {
            _name = name;
            _level = level;
            IsBanned = false;
        }

        public void RemoveFromBan()
        {
            IsBanned = false;
        }

        public void AddToBan()
        {
            IsBanned = true;
        }

        public void ShowDetails()
        {
            if (IsBanned == false)
            {
                _flag = "не забанен";
            }
            else
            {
                _flag = "забанен";
            }
            Console.WriteLine($"Ник персонажа - {_name}, уровень - {_level}, статус бана - {_flag}");
        }
    }
}