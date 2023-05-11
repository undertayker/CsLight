using System;
using System.Collections.Generic;
using System.Linq;

namespace Т54
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stats stats = new Stats();
            stats.Work();
        }
    }

    class Stats
    {
       private List<Player> _players = new List<Player>();

        public Stats()
        {
            _players.Add(new Player("Андрей ", 158, 138));
            _players.Add(new Player("Александр ", 164, 134));
            _players.Add(new Player("Владимер ", 188, 149));
            _players.Add(new Player("Анаталий ", 295, 147));
            _players.Add(new Player("Давид ", 184, 170));
            _players.Add(new Player("Генадий ", 192, 265));
            _players.Add(new Player("Илья ", 238, 202));
            _players.Add(new Player("Виктор ", 340, 240));
            _players.Add(new Player("Евгений ", 168, 147));
            _players.Add(new Player("Роман ", 182, 164));
        }

        public void Work()
        {
            const string ShowAllPlayersCommand = "1";
            const string ShowTopLevelPlayersCommand = "2";
            const string ShowTopStrongPlayerCommand = "3";
            const string ExitCommand = "4";

            bool isWorkink = true;
            string userInput;

            Console.WriteLine("Добро пожаловать в информационный центр статистики игроков!!");

            while (isWorkink)
            {
                Console.WriteLine($"\n{ShowAllPlayersCommand} - Для просмотра всех игроков" +
                    $"\n{ShowTopLevelPlayersCommand} - Для просмотра топ 3 игроков по уровню" +
                    $"\n{ShowTopStrongPlayerCommand} - Для просмотра топ 3 игроков по силе" +
                    $"\n{ExitCommand} - Для выхода из информационного центра ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ShowAllPlayersCommand:
                        ShowInfos(_players);
                        break;

                    case ShowTopLevelPlayersCommand:
                        ShowSortAllPlayerByLevel();
                        break;

                    case ShowTopStrongPlayerCommand:
                        ShowSortAllPlayerByStrong();
                        break;

                    case ExitCommand:
                        isWorkink = false;
                        break;

                    default:
                        Console.WriteLine("Введи некорректные данные!!!");
                        break;
                }
            }
        }

        private void ShowSortAllPlayerByLevel()
        {
            var filteredPlayerByLevel = _players.OrderByDescending(player => player.Level).Take(3);

            ShowInfos(filteredPlayerByLevel);
        }

        private static void ShowInfos(IEnumerable<Player> filteredPlayerByLevel)
        {
            foreach (var player in filteredPlayerByLevel)
            {
                player.ShowInfo();
            }
        }

        private void ShowSortAllPlayerByStrong()
        {
            var filteredPlayerByStrong = _players.OrderByDescending(player => player.Strong).Take(3);

            ShowInfos(filteredPlayerByStrong);
        }
    }

    class Player
    {
        public Player(string name, int level, int strong)
        {
            Name = name;
            Level = level;
            Strong = strong;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Strong { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} | Уровень : {Level} | Сила : {Strong}");
        }
    }
}
