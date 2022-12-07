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
            Renderer renderer = new Renderer();
            Player player = new Player(3,3);

            renderer.DrawPlayer(player.PositionX,player.PositionY);
        }
    }

    class Renderer
    {
        public void DrawPlayer(int positionX, int positionY, char symbol = '@')
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(symbol);
        }
    }

    class Player 
    {
        public int PositionX { get; private set; }

        public int PositionY { get; private set; }

        public Player(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}