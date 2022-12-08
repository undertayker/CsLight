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
            Player player = new Player("Alex", 100, 50, 24);

            player.ShowStats();
        }
    }

    class Player
    {
        private string _name;
        private int _health;
        private int _armor;
        private int _damage;

        public Player(string name, int health, int armor, int damage)
        {
            _name = name;
            _health = health;
            _armor = armor;
            _damage = damage;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Имя - {_name}\nЖизни - {_health}\nБроня - {_armor}\nУрон - {_damage}");
        }
    }
}