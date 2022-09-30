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
            int health = 0;
            int maxHealth = 10;
            int mana = 0;
            int maxMana = 10;

            bool isWork = true;

            while (isWork)
            {
                DrawBar(health, maxHealth, ConsoleColor.Red, 0, '_');
                DrawBar(mana, maxMana, ConsoleColor.Blue, 1, '_');

                Console.SetCursorPosition(0, 3);

                Console.Write("Введите количество ваших жизней : ");
                health = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите количество вашей маны : ");
                mana = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
            }
        }

        static void DrawBar(int value, int maxValue, ConsoleColor color, int position, char symbol = ' ')
        {
            ConsoleColor defoultColor = Console.BackgroundColor;
            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += symbol;
            }

            Console.SetCursorPosition(0, position);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defoultColor;

            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += symbol;
            }
            Console.Write(bar + ']');
        }
    }
}