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
        const string ShowAllPlayersCommand = "1";
        const string ShowTopLevelPlayersCommand = "2";
        const string ShowTopStrongPlayerCommand = "3";
        const string ExitCommand = "4";

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
            bool isWorkink = true;
            string userInput;

            Console.WriteLine("Добро пожаловать в информационный центр статистики играков!!");

            while (isWorkink)
            {
                Console.WriteLine($"\n{ShowAllPlayersCommand} - Для просмотра всех игроков" +
                    $"\n{ShowTopLevelPlayersCommand} - Для просмотра топ 3 играков по уровню" +
                    $"\n{ShowTopStrongPlayerCommand} - Для просмотра топ 3 играков по силе" +
                    $"\n{ExitCommand} - Для выхода из информационного центра ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ShowAllPlayersCommand:
                        ShowPlayer();
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
            var filteredPlayerByLevel = _players.Where(player => player.Level > 200).OrderByDescending(player => player.Level);

            foreach (var player in filteredPlayerByLevel)
            {
                player.ShowInfo();
            }
        }

        private void ShowSortAllPlayerByStrong()
        {
            var filteredPlayerByStrong = _players.Where(player => player.Strong > 200).OrderByDescending(player => player.Strong);

            foreach (var player in filteredPlayerByStrong)
            {
                player.ShowInfo();
            }
        }

        private void ShowPlayer()
        {
            foreach (var player in _players)
            {
                player.ShowInfo();
            }
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
