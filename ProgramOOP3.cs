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
            Database database = new Database();
            bool isWork = true;

            while (isWork == true)
            {
                Console.WriteLine($"\n1. Вывести данные всех игроков \n2. Добавить нового игрока \n3. Удалить игрока \n4. Забанить игрока \n5. Разбанить игрока \n6. Выход");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        database.ShowData();
                        break;
                    case "2":
                        database.AddPlayer();
                        break;
                    case "3":
                        database.DeletePlayer();
                        break;
                    case "4":
                        database.BanPlayer();
                        break;
                    case "5":
                        database.UnBanPlayer();
                        break;
                    case "6":
                        isWork = false;
                        break;
                }
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(string name, int level, bool isBanned)
        {
            Name = name;
            Level = level;
            IsBanned = isBanned;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя игрока: {Name} \nУровень игрока: {Level}");
            if (IsBanned == true)
            {
                Console.WriteLine("Есть у игрока бан: да");
            }
            else if (IsBanned == false)
            {
                Console.WriteLine("Есть у игрока бан: нет");
            }
        }

        public void Ban()
        {
            IsBanned = true;
        }

        public void UnBan()
        {
            IsBanned = false;
        }
    }

    class Database
    {
        private Dictionary<int, Player> _players = new Dictionary<int, Player>();
        private int _playerIndexInBase;

        public Database()
        {
            _playerIndexInBase = 0;
        }

        public void AddPlayer()
        {
            Console.WriteLine("\nВведите имя игрока: \n");
            string name = Console.ReadLine();

            Console.WriteLine("\nВведите уровень игрока: \n");
            bool isNumber = int.TryParse(Console.ReadLine(), out int level);

            if (isNumber == false)
            {
                PrintRedText("\nНеккоретный ввод. Уровень должен содержать только числа\n");
                return;
            }

            Console.WriteLine("\nИгрок забанен? (Да или Нет) \n");
            string input = Console.ReadLine();
            bool isBanned;

            if (input == "Да")
            {
                isBanned = true;
            }
            else if (input == "Нет")
            {
                isBanned = false;
            }
            else
            {
                PrintRedText("\nНеккоретный ввод. Попробуйте ещё раз\n");
                return;
            }

            _players.Add(_playerIndexInBase, new Player(name, level, isBanned));
            _playerIndexInBase++;

            PrintGreenText("\nИгрок добавлен!\n");
        }

        public void DeletePlayer()
        {
            Console.WriteLine("\nВведите уникальный номер игрока\n");
            bool isNumber = int.TryParse(Console.ReadLine(), out int input);

            if (isNumber == true & _players.ContainsKey(input) == true)
            {
                _players.Remove(input);
                PrintGreenText("\nИгрок удалён!\n");
            }
            else
            {
                PrintRedText("\nНеккоректный ввод или игрока с данным номером нет в базе\n");
            }
        }

        public void ShowData()
        {
            if (_players.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < _players.Count; i++)
                {
                    _players[i].ShowInfo();
                    Console.WriteLine($"Уникальный номер: {i}");
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
            else
            {
                PrintRedText("\nВ базе ещё нет игроков\n");
            }
        }

        public void BanPlayer()
        {
            Console.WriteLine("\nВведите уникальный номер игрока\n");
            bool isNumber = int.TryParse(Console.ReadLine(), out int input);

            if (isNumber == true & _players.ContainsKey(input) == true)
            {
                if (_players[input].IsBanned == false)
                {
                    _players[input].Ban();
                    PrintGreenText("\nИгрок забанен!\n");
                }
                else
                {
                    PrintRedText("\nИгрок уже забанен\n");
                }
            }
            else
            {
                PrintRedText("\nНеккоректный ввод или игрока с данным номером нет в базе\n");
            }
        }

        public void UnBanPlayer()
        {
            Console.WriteLine("\nВведите уникальный номер игрока\n");
            int input = int.Parse(Console.ReadLine());

            if (_players.ContainsKey(input) == true)
            {
                if (_players[input].IsBanned == true)
                {
                    _players[input].UnBan();
                    PrintGreenText("\nИгрок разабанен!\n");
                }
                else
                {
                    PrintRedText("\nУ игрока нет бана\n");
                }
            }
            else
            {
                PrintRedText("\nИгрока с данным номером нет в базе\n");
            }
        }

        public void PrintRedText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void PrintGreenText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}