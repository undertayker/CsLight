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

            database.SelectAction();
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();
        private bool _isWorking = true;

        public void SelectAction()
        {
            while (_isWorking)
            {
                Console.WriteLine("1 - Добавить игрока\n2 - Забанить игрока\n3 - Разбанить игрока\n4 - Удалить игрока\n5 - Выход");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        SetDataForAccount();
                        break;
                    case "2":
                        BanById();
                        break;
                    case "3":
                        UnbanById();
                        break;
                    case "4":
                        RemoveById();
                        break;
                    case "5":
                        _isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Ошибочный ввод. Повторите попытку!");
                        break;
                }
            }
        }

        private void SetDataForAccount()
        {
            Console.Write("Введите ID игрока: ");
            int id = ReadNumber();

            Console.Write("Введите имя игрока: ");
            string name = Console.ReadLine();

            Console.Write("Введите уровень игрока: ");
            int level = ReadNumber();

            bool isBanned = false;

            AddPlayerToDatabase(new Player(isBanned, name, level, id));
            Console.Clear();
        }

        private void AddPlayerToDatabase(Player player)
        {
            _players.Add(player);
        }

        private int ReadNumber()
        {
            bool isWorking = true;
            int result = 0;

            while (isWorking)
            {
                string number = Console.ReadLine();

                if (int.TryParse(number, out result))
                {
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Ошибка, повторите ввод: ");
                }
            }

            return result;
        }

        private void BanById()
        {
            if (_players.Count > 0)
            {
                int indexSaved = -1;

                ShowInfo();

                Console.Write("Введите ID игрока для бана: ");
                int idForBan = ReadNumber();

                if (TryToFindPlayer(idForBan, ref indexSaved) == true)
                {
                    _players[indexSaved].Ban();
                    Console.WriteLine("Игрок забанен!");
                }
                else
                {
                    Console.WriteLine("Игрок с указанным ID не найден!");
                }
            }
            else
            {
                Console.WriteLine("База данных пуста!");
            }
        }

        private void UnbanById()
        {
            if (_players.Count > 0)
            {
                int indexSaved = -1;
                ShowInfo();

                Console.Write("Введите ID игрока для разбана: ");
                int idForUnban = ReadNumber();

                if (TryToFindPlayer(idForUnban, ref indexSaved) == true)
                {
                    _players[indexSaved].Unban();
                    Console.WriteLine("Игрок разбанен!");
                }
                else
                {
                    Console.WriteLine("Игрок с указанным ID не найден!");
                }
            }
            else
            {
                Console.WriteLine("База данных пуста!");
            }
        }

        private void RemoveById()
        {
            if (_players.Count > 0)
            {
                int indexSaved = -1;
                ShowInfo();

                Console.Write("Введите ID игрока для удаления: ");
                int idForRemove = ReadNumber();

                if (TryToFindPlayer(idForRemove, ref indexSaved) == true)
                {
                    _players.RemoveAt(indexSaved);
                    Console.WriteLine("Игрок удален!");
                }
                else
                {
                    Console.WriteLine("Игрок с указанным ID не найден!");
                }
            }
            else
            {
                Console.WriteLine("База данных пуста!");
            }
        }

        private bool TryToFindPlayer(int idForSearch, ref int indexSaved)
        {
            int indexFound = -1;

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Id == idForSearch)
                {
                    indexFound = i;
                }
            }

            if (indexFound == -1)
            {
                return false;
            }
            else
            {
                indexSaved = indexFound;
                return true;
            }
        }

        private void ShowInfo()
        {
            foreach (var player in _players)
            {
                Console.Write($"Мой id - {player.Id}. Меня зовут - {player.Nickname}. Мой уровень - {player.Level}.");

                if (player.IsBanned == true)
                {
                    Console.Write(" Я в бане.");
                }
                else
                {
                    Console.Write(" Я не в бане.");
                }

                Console.WriteLine("\n");
            }
        }
    }

    class Player
    {
        public string Nickname { get; private set; }
        public bool IsBanned { get; private set; }
        public int Level { get; private set; }
        public int Id { get; private set; }

        public Player(bool isBanned, string nickname, int level, int id)
        {
            Nickname = nickname;
            IsBanned = isBanned;
            Level = level;
            Id = id;
        }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }
    }
}