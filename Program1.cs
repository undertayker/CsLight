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
            Player player = new Player("Alex", 100, 50, 130);
            player.ShowStats();
        }
    }

    class Player 
    {
        public string Name;
        public int Health;
        public int Armor;
        public int Damage;

        public Player(string name, int health, int armor, int damage)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Имя - {Name}\nЖизни - {Health}\nБроня - {Armor}\nУрон - {Damage} ");
        }
    }
}