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
            int userPositionX;
            int userPositionY;
            int userDirectionX = 0;
            int userDirectionY = 1;
            char wallSymbol = '#';

            char[,] map = ReadMap("Map", out userPositionX, out userPositionY);

            DrawMap(map);

            while (isPlaing)
            {
                IsPlayerRendering( ref userPositionX, ref userPositionY);
               
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    ChangeDirection(key, out userDirectionX, out userDirectionY);

                    if (map[userPositionX + userDirectionX, userPositionY + userDirectionY] != wallSymbol)
                    {
                        IsMapMovement(ref userPositionX, ref userPositionY, userDirectionX, userDirectionY);
                    }
                }
            }
        }

        static bool IsPlayerRendering(ref int userPositionX, ref int userPositionY)
        {
            char playerSymbol = '@';       

            Console.SetCursorPosition(userPositionY, userPositionX);
            Console.Write(playerSymbol);

            return true;
        }

        static bool IsMapMovement(ref int userPositionX, ref int userPositionY, int userDirectionX, int userDirectionY)
        {
            IsPlayerRendering(ref userPositionX, ref userPositionY);

            Console.SetCursorPosition(userPositionY, userPositionX);
            Console.Write(" ");

            char playerSymbol = '@';
            userPositionX += userDirectionX;
            userPositionY += userDirectionY;
       
            Console.SetCursorPosition(userPositionY, userPositionX);
            Console.Write(playerSymbol);

            return true;
        }

        static void ChangeDirection(ConsoleKeyInfo key, out int userDirectionX, out int userDirectionY)
        {
            userDirectionX = 0;
            userDirectionY = 0;
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    userDirectionX = -1;
                    userDirectionY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    userDirectionX = 1;
                    userDirectionY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    userDirectionX = 0;
                    userDirectionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    userDirectionX = 0;
                    userDirectionY = 1;
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

        static char[,] ReadMap(string mapName, out int userPositionX, out int userPositionY)
        {
            char playerSymbol = '@';
            userPositionX = 0;
            userPositionY = 0;
            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == playerSymbol)
                    {
                        userPositionX = i;
                        userPositionY = j;
                    }
                }
            }

            return map;
        }
    }
}