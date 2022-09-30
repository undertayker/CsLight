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
            Console.CursorVisible = false;

            bool isPlaing = true;
            int userX, userY;
            int userDx = 0, userDy = 1;

            char[,] map = ReadMap("Map", out userX, out userY);

            DrawMap(map);

            while (isPlaing)
            {
                Console.SetCursorPosition(userY, userX);
                Console.Write('@');

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    ChangeDirection(key, ref userDx, ref userDy);

                    if (map[userX + userDx, userY + userDy] != '#')
                    {
                        MapMovement(ref userX, ref userY, userDx, userDy);
                    }
                }
            }
        }

        static void MapMovement(ref int userX, ref int userY, int userDx, int userDy)
        {
            Console.SetCursorPosition(userY, userX);
            Console.Write(" ");

            userX += userDx;
            userY += userDy;

            Console.SetCursorPosition(userY, userX);
            Console.Write('@');
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int userDx, ref int userDy)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    userDx = -1; userDy = 0;
                    break;
                case ConsoleKey.DownArrow:
                    userDx = 1; userDy = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    userDx = 0; userDy = -1;
                    break;
                case ConsoleKey.RightArrow:
                    userDx = 0; userDy = 1;
                    break;
            }
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static char[,] ReadMap(string mapName, out int userX, out int userY)
        {
            userX = 0;
            userY = 0;
            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '@')
                    {
                        userX = i;
                        userY = j;
                    }
                }
            }

            return map;
        }
    }
}