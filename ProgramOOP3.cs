using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database dataPlayers = new Database();
            dataPlayers.Work();
        }
    }

    class Database
    {
        private int nextIdNumber = 100;
        private List<Player> _players = new List<Player>();

        public void Work()
        {
            const string ShowPlayersCommand = "1";
            const string AddNewPlayerCommand = "2";
            const string RemovePlayerCommand = "3";
            const string BanPlayerCommand = "4";
            const string UnbanPlayerCommand = "5";
            const string ExitCommand = "6";

            bool isWork = true;
            string userInput;

            while (isWork)
            {
                Console.Clear();

                Console.WriteLine(ShowPlayersCommand + " - Открыть базу данных." +
                    "\n" + AddNewPlayerCommand + " - Добавить игрока. " +
                    "\n" + RemovePlayerCommand + " - Удалить игрока." +
                    "\n" + BanPlayerCommand + " - Бан по ID." +
                    "\n" + UnbanPlayerCommand + " - Разбан по ID." +
                    "\n" + ExitCommand + " - Выход");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ShowPlayersCommand:
                        ShowAllPlayers();
                        break;

                    case AddNewPlayerCommand:
                        AddPlayer();
                        break;

                    case RemovePlayerCommand:
                        DeletePlayer();
                        break;

                    case BanPlayerCommand:
                        BanPlayer();
                        break;

                    case UnbanPlayerCommand:
                        UnbanPlayer();
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;
                }
            }
        }

        private void ShowAllPlayers()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].ShowInfo();
            }

            Console.ReadKey();
        }

        private int AddPlayer()
        {
            Console.WriteLine("Введите имя игрока :");
            string nameNewPlayer = Console.ReadLine();

            Console.WriteLine("Введите уровень игрока :");
            int levelNewPlayer = ReadInt();

            _players.Add(new Player(nextIdNumber, nameNewPlayer, levelNewPlayer, false));

            return nextIdNumber++;
        }

        private void DeletePlayer()
        {
            if (TryGetPlayer(out Player player))
            {
                _players.Remove(player);
                Console.WriteLine("Игрок успешно удалён!");
            }
        }

        private void BanPlayer()
        {
            if (TryGetPlayer(out Player player))
            {
                player.BanUser();
                Console.WriteLine("Игрок забанен!");
            }
        }

        private void UnbanPlayer()
        {
            if (TryGetPlayer(out Player player))
            {
                player.UnbanUser();
                Console.WriteLine("Игрок разбанен!");
            }
        }

        private int ReadInt()
        {
            bool isNumber = false;
            int result = 0;

            while (isNumber == false)
            {
                string userInput = Console.ReadLine();
                isNumber = int.TryParse(userInput, out int number);

                if (isNumber)
                {
                    result = number;
                }
                else
                {
                    Console.WriteLine("Введите число.");
                }
            }

            return result;
        }

        private bool TryGetPlayer(out Player player)
        {
            int idToFind;
            bool isUserInput;
            Console.WriteLine("Введите ID игрока.");
            isUserInput = int.TryParse(Console.ReadLine(), out idToFind);

            if (isUserInput)
            {
                for (int i = 0; i < _players.Count; i++)
                {
                    if (_players[i].Id == idToFind)
                    {
                        player = _players[i];

                        return true;
                    }
                }
            }

            Console.WriteLine("Такого игрока нет.");
            player = null;
            return false;

        }
    }

    class Player
    {
        private int _id;
        private string _name;
        private int _level;
        private bool _isBanned;

        public int Id => _id;

        public Player(int id, string name, int level, bool isBan)
        {
            _id = id;
            _name = name;
            _level = level;
            _isBanned = isBan;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Имя игрока : " + _name + " Уровень : " + _level + " ID : " + _id + " Забанен : " + _isBanned);
        }

        public void BanUser()
        {
            _isBanned = true;
        }

        public void UnbanUser()
        {
            _isBanned = false;
        }
    }
}